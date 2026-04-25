using System.Numerics;
using System.Text;

namespace lab3_Rabin
{
    /// <summary>
    /// Сервис, содержащий реализацию криптосистемы Рабина:
    /// проверку параметров, шифрование, дешифрование и вспомогательные математические методы.
    /// </summary>
    public static class RabinCryptoService
    {
        /// <summary>
        /// Проверяет корректность параметров p, q, b для работы алгоритма.
        /// </summary>
        /// <param name="p">Простое число p, должно быть сравнимо с 3 по модулю 4.</param>
        /// <param name="q">Простое число q, должно быть сравнимо с 3 по модулю 4.</param>
        /// <param name="b">Параметр b, должен быть в диапазоне (0, n).</param>
        /// <param name="error">Текст ошибки при неуспешной проверке.</param>
        /// <returns>true, если параметры корректны; иначе false.</returns>
        public static bool TryValidateParameters(BigInteger p, BigInteger q, BigInteger b, out string error)
        {
            // Здесь проверяются все ограничения из постановки задания до старта шифрования/дешифрования.
            error = string.Empty;
            BigInteger n = p * q;

            if (p == q)
            {
                error = "Числа p и q должны быть разными.";
                return false;
            }

            if (!IsPrime(p) || !IsPrime(q))
            {
                error = "p и q должны быть простыми числами.";
                return false;
            }

            if (p % 4 != 3 || q % 4 != 3)
            {
                error = "p и q должны удовлетворять условию p mod 4 = 3 и q mod 4 = 3.";
                return false;
            }

            if (n <= 256)
            {
                error = "Должно выполняться условие n = p*q > 256.";
                return false;
            }

            if (b <= 0 || b >= n)
            {
                error = "Должно выполняться условие 0 < b < n.";
                return false;
            }

            if (n > uint.MaxValue)
            {
                error = "Для формата 4 байта требуется n <= 4294967295.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Шифрует файл побайтно по формуле Рабина и сохраняет шифротекст блоками по 4 байта.
        /// </summary>
        /// <param name="inputPath">Путь к исходному файлу.</param>
        /// <param name="outputPath">Путь к файлу шифротекста.</param>
        /// <param name="b">Параметр b.</param>
        /// <param name="n">Модуль n = p*q.</param>
        public static void EncryptFile(string inputPath, string outputPath, BigInteger b, BigInteger n)
        {
            using FileStream input = new(inputPath, FileMode.Open, FileAccess.Read);
            using FileStream output = new(outputPath, FileMode.Create, FileAccess.Write);
            using BinaryReader reader = new(input);
            using BinaryWriter writer = new(output);

            while (input.Position < input.Length)
            {
                // Исходный файл читается строго по 1 байту.
                byte m = reader.ReadByte();
                // Формула шифрования Рабина: c = m * (m + b) mod n.
                BigInteger c = Mod(m * (m + b), n);
                // Каждый блок шифротекста пишем ровно в 4 байта (UInt32, little-endian).
                writer.Write((uint)c);
            }
        }

        /// <summary>
        /// Дешифрует файл шифротекста (по 4 байта на блок) и восстанавливает исходный байтовый поток.
        /// </summary>
        /// <param name="inputPath">Путь к зашифрованному файлу.</param>
        /// <param name="outputPath">Путь к файлу для расшифрованных данных.</param>
        /// <param name="p">Простое число p.</param>
        /// <param name="q">Простое число q.</param>
        /// <param name="b">Параметр b.</param>
        /// <param name="n">Модуль n = p*q.</param>
        public static void DecryptFile(string inputPath, string outputPath, BigInteger p, BigInteger q, BigInteger b, BigInteger n)
        {
            using FileStream input = new(inputPath, FileMode.Open, FileAccess.Read);
            using FileStream output = new(outputPath, FileMode.Create, FileAccess.Write);
            using BinaryReader reader = new(input);
            using BinaryWriter writer = new(output);

            if (input.Length % 4 != 0)
            {
                throw new InvalidOperationException("Длина зашифрованного файла не кратна 4 байтам.");
            }

            while (input.Position < input.Length)
            {
                // Каждый блок шифротекста занимает 4 байта.
                uint block = reader.ReadUInt32();
                // Для каждого c восстанавливаем ровно 1 исходный байт m.
                byte m = DecryptByte(block, p, q, b, n);
                // После дешифрования снова пишем обычный байт исходного файла.
                writer.Write(m);
            }
        }

        /// <summary>
        /// Читает зашифрованный файл и возвращает его содержимое как список десятичных значений блоков.
        /// </summary>
        /// <param name="filePath">Путь к зашифрованному файлу.</param>
        /// <returns>Строка со списком блоков в формате "индекс: значение".</returns>
        public static string ReadEncryptedContent(string filePath)
        {
            using FileStream input = new(filePath, FileMode.Open, FileAccess.Read);
            using BinaryReader reader = new(input);
            StringBuilder sb = new();

            if (input.Length % 4 != 0)
            {
                throw new InvalidOperationException("Файл не является корректным шифротекстом (длина не кратна 4).");
            }

            int index = 0;
            while (input.Position < input.Length)
            {
                uint block = reader.ReadUInt32();
                sb.AppendLine($"{index}: {block}");
                index++;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Дешифрует один блок c и восстанавливает соответствующий исходный байт.
        /// </summary>
        /// <param name="c">Блок шифротекста.</param>
        /// <param name="p">Простое число p.</param>
        /// <param name="q">Простое число q.</param>
        /// <param name="b">Параметр b.</param>
        /// <param name="n">Модуль n = p*q.</param>
        /// <returns>Восстановленный байт сообщения.</returns>
        private static byte DecryptByte(BigInteger c, BigInteger p, BigInteger q, BigInteger b, BigInteger n)
        {
            // D = (b^2 + 4c) mod n
            BigInteger d = Mod(b * b + 4 * c, n);
            // Корни по p и q для простых вида 4k+3.
            // ВНИМАНИЕ: степень вычисляется не "в лоб", а через ModPow (быстрое возведение в степень).
            BigInteger mp = ModPow(d, (p + 1) / 4, p);
            BigInteger mq = ModPow(d, (q + 1) / 4, q);

            // Коэффициенты CRT: yp*p + yq*q = 1.
            // Это коэффициенты для КТО (китайской теоремы об остатках).
            ExtendedGcd(p, q, out BigInteger yp, out BigInteger yq, out _);

            // Сборка 4 корней по модулю n через КТО.
            BigInteger d1 = Mod(yp * p * mq + yq * q * mp, n);
            BigInteger d2 = Mod(n - d1, n);
            BigInteger d3 = Mod(yp * p * mq - yq * q * mp, n);
            BigInteger d4 = Mod(n - d3, n);

            BigInteger[] roots = [d1, d2, d3, d4];
            List<byte> candidates = [];
            foreach (BigInteger root in roots)
            {
                // Восстанавливаем кандидат m из корня квадратного уравнения.
                BigInteger candidate = GetMessageFromRoot(root, b, n);
                if (candidate >= 0 && candidate < 256)
                {
                    byte asByte = (byte)candidate;
                    // Дополнительная верификация: кандидат обязан давать исходный c.
                    BigInteger check = Mod(asByte * (asByte + b), n);
                    if (check == c && !candidates.Contains(asByte))
                    {
                        candidates.Add(asByte);
                    }
                }
            }

            // При корректных параметрах n > 256 должен остаться ровно один байт-кандидат.
            if (candidates.Count != 1)
            {
                throw new InvalidOperationException(
                    "Не удалось однозначно определить исходный байт. Проверьте p, q, b, целостность файла и единый порядок байт.");
            }

            return candidates[0];
        }

        /// <summary>
        /// Восстанавливает кандидат m из одного корня квадратного уравнения d_i.
        /// </summary>
        /// <param name="root">Один из корней d_i по модулю n.</param>
        /// <param name="b">Параметр b.</param>
        /// <param name="n">Модуль n = p*q.</param>
        /// <returns>Кандидат на исходное сообщение m по модулю n.</returns>
        private static BigInteger GetMessageFromRoot(BigInteger root, BigInteger b, BigInteger n)
        {
            // Из уравнения x^2 + b*x - c = 0: m = (-b + d_i) / 2 (mod n).
            BigInteger numerator = root - b;
            if (numerator % 2 != 0)
            {
                // Приводим к четному числителю, чтобы деление на 2 по модулю было корректным.
                numerator += n;
            }

            // Деление по модулю выполняем как умножение на обратный элемент 2^{-1} mod n.
            BigInteger inv2 = ModInverse(2, n);
            return Mod(numerator * inv2, n);
        }

        /// <summary>
        /// Быстрое возведение в степень по модулю (binary exponentiation).
        /// </summary>
        /// <param name="value">Основание степени.</param>
        /// <param name="exponent">Показатель степени.</param>
        /// <param name="modulus">Модуль.</param>
        /// <returns>Значение value^exponent mod modulus.</returns>
        private static BigInteger ModPow(BigInteger value, BigInteger exponent, BigInteger modulus)
        {
            // Быстрое возведение в степень по модулю (binary exponentiation).
            // Это и есть реализация "алгоритма быстрого возведения в степень".
            BigInteger result = 1;
            BigInteger baseValue = Mod(value, modulus);
            BigInteger exp = exponent;

            while (exp > 0)
            {
                // Если младший бит степени = 1, домножаем результат на текущую базу.
                if ((exp & 1) == 1)
                {
                    result = Mod(result * baseValue, modulus);
                }

                // Квадрат базы и переход к следующему биту степени.
                baseValue = Mod(baseValue * baseValue, modulus);
                exp >>= 1;
            }

            return result;
        }

        /// <summary>
        /// Расширенный алгоритм Евклида: находит x, y и gcd такие, что a*x + b*y = gcd.
        /// </summary>
        /// <param name="a">Первое число.</param>
        /// <param name="b">Второе число.</param>
        /// <param name="x">Коэффициент при a.</param>
        /// <param name="y">Коэффициент при b.</param>
        /// <param name="gcd">Наибольший общий делитель a и b.</param>
        private static void ExtendedGcd(BigInteger a, BigInteger b, out BigInteger x, out BigInteger y, out BigInteger gcd)
        {
            // Расширенный алгоритм Евклида: находим x,y и gcd такие, что ax + by = gcd.
            if (b == 0)
            {
                x = 1;
                y = 0;
                gcd = a;
                return;
            }

            ExtendedGcd(b, a % b, out BigInteger x1, out BigInteger y1, out gcd);
            // Обратный ход рекурсии.
            x = y1;
            y = x1 - (a / b) * y1;
        }

        /// <summary>
        /// Находит мультипликативный обратный элемент value^{-1} по модулю modulus.
        /// </summary>
        /// <param name="value">Число, для которого ищется обратный элемент.</param>
        /// <param name="modulus">Модуль.</param>
        /// <returns>Обратный элемент по модулю.</returns>
        private static BigInteger ModInverse(BigInteger value, BigInteger modulus)
        {
            ExtendedGcd(value, modulus, out BigInteger x, out _, out BigInteger gcd);
            if (gcd != 1)
            {
                throw new InvalidOperationException("Обратный элемент не существует.");
            }

            // Нормализуем обратный элемент в диапазон [0, modulus).
            return Mod(x, modulus);
        }

        /// <summary>
        /// Возвращает нормализованный остаток от деления в диапазоне [0, modulus).
        /// </summary>
        /// <param name="value">Число для взятия по модулю.</param>
        /// <param name="modulus">Модуль.</param>
        /// <returns>Нормализованный остаток.</returns>
        private static BigInteger Mod(BigInteger value, BigInteger modulus)
        {
            // Нормализованный остаток: всегда в диапазоне [0, modulus).
            BigInteger result = value % modulus;
            return result < 0 ? result + modulus : result;
        }

        /// <summary>
        /// Учебная проверка числа на простоту перебором нечетных делителей до sqrt(n).
        /// </summary>
        /// <param name="value">Проверяемое число.</param>
        /// <returns>true, если число простое; иначе false.</returns>
        private static bool IsPrime(BigInteger value)
        {
            // Учебный тест простоты: перебор нечетных делителей до sqrt(n).
            if (value < 2) return false;
            if (value == 2 || value == 3) return true;
            if (value % 2 == 0) return false;

            for (BigInteger i = 3; i * i <= value; i += 2)
            {
                if (value % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
