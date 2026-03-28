using System.Text;

namespace lab1
{

    public partial class Form1 : Form
    {
        // Русский алфавит с Ё (33 буквы)
        private const string Alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        // Нормализует текст: переводит в верхний регистр, убирает все символы не из алфавита
        private string NormalizeText(string text)
        {
            if (text == null) return string.Empty;

            var upper = text.ToUpperInvariant();
            var sb = new StringBuilder(upper.Length);
            foreach (char c in upper)
            {
                if (Alphabet.Contains(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }

        // Возвращает индекс буквы в алфавите
        private int GetIndex(char c) => Alphabet.IndexOf(c);

        // Проверка, что числа a и m взаимно просты (их НОД = 1)
        // Алгоритм Евклида для нахождения НОД (наибольшего общего делителя)
        private bool IsCoprime(int a, int m)
        {
            int x = a, y = m; 
            while (y != 0)          // Пока второе число не станет равным нулю
            {
                int t = x % y;      // Вычисляем остаток от деления x на y
                x = y;              // Присваиваем x значение y
                y = t;              // Присваиваем y полученный остаток
            }
            return x == 1;
        }

        // Поиск мультипликативного обратного к a по модулю m (a * x mod m = 1)
        private int MultiplicativeInverse(int a, int m)
        {
            a = ((a % m) + m) % m; // коррекция отрицательных ключей
            for (int x = 1; x < m; x++)
            {
                if ((a * x) % m == 1)
                    return x;
            }
            throw new InvalidOperationException("Обратный элемент не найден.");
        }

        // Шифрование методом децимации c = (k * i)mod n
        private string DecimationEncrypt(string plain, int key)
        {
            plain = NormalizeText(plain);
            int m = Alphabet.Length;

            if (!IsCoprime(key, m))
                throw new ArgumentException("Ключ децимации должен быть взаимно прост с длиной алфавита.");

            var sb = new StringBuilder(plain.Length);
            foreach (char c in plain)
            {
                int i = GetIndex(c);              // ищем индекс символа в алфавите
                int j = (key * i) % m;            // децимация
                sb.Append(Alphabet[j]);           // получаем зашифрованный символ
            }
            return sb.ToString();
        }

        // Расшифрование методом децимации i = (k−1 * c)mod n
        private string DecimationDecrypt(string cipher, int key)
        {
            cipher = NormalizeText(cipher);
            int m = Alphabet.Length;

            if (!IsCoprime(key, m))
                throw new ArgumentException("Ключ децимации должен быть взаимно прост с длиной алфавита.");

            int inv = MultiplicativeInverse(key, m); // обратный ключ

            var sb = new StringBuilder(cipher.Length);
            foreach (char c in cipher)
            {
                int j = GetIndex(c);
                int i = (inv * j) % m;
                sb.Append(Alphabet[i]);      // получаем расшифрованный символ
            }
            return sb.ToString();
        }

        // Привести ключ к нормализованному виду (оставить только буквы алфавита)
        private string NormalizeKey(string key)
        {
            key = NormalizeText(key);
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Ключ должен содержать хотя бы одну букву алфавита.");
            return key;
        }

        // Извлечь число из строки ключа децимации (только цифры, лишние символы игнорируются)
        private static string ExtractDigits(string text)
        {
            if (text == null) return string.Empty;
            var sb = new StringBuilder(text.Length);
            foreach (char c in text)
            {
                if (char.IsDigit(c) || (c == '-' && sb.Length == 0))
                    sb.Append(c);
            }
            return sb.ToString();
        }

        // Шифрование Виженера с автоключом: добавляем к пользовательскому ключу исходный текст и обрезаем до нужной длины
        private string VigenerAutoEncrypt(string plain, string userKey)
        {
            plain = NormalizeText(plain);
            if (plain.Length == 0) return string.Empty;

            userKey = NormalizeKey(userKey);
            // автоключ = ключ + часть исходного текста
            string autoKey = (userKey + plain).Substring(0, plain.Length);

            var sb = new StringBuilder(plain.Length);
            int m = Alphabet.Length;

            for (int i = 0; i < plain.Length; i++)
            {
                int p = GetIndex(plain[i]);
                int k = GetIndex(autoKey[i]);
                int c = (p + k) % m;              // основной шаг Виженера c = (p + k)mod m
                sb.Append(Alphabet[c]);
            }
            return sb.ToString();
        }

        // Расшифрование автоключа: по ходу, восстанавливаем открытый текст и увеличиваем ключ
        private string VigenerAutoDecrypt(string cipher, string userKey)
        {
            cipher = NormalizeText(cipher);
            if (cipher.Length == 0) return string.Empty;

            userKey = NormalizeKey(userKey);
            var keyBuilder = new StringBuilder(userKey); // копим ключ (сначала пользовательский)

            var sb = new StringBuilder(cipher.Length);
            int m = Alphabet.Length;

            for (int i = 0; i < cipher.Length; i++)
            {
                int c = GetIndex(cipher[i]);
                int k = GetIndex(keyBuilder[i]); // текущий символ автоключа
                int p = (c - k + m) % m;         // шаг расшифровки p = (c – k + m)mod m
                char plainChar = Alphabet[p];
                sb.Append(plainChar);
                // автоключ пополняется найденной буквой исходного текста+
                keyBuilder.Append(plainChar);
            }
            return sb.ToString();
        }

        // Получить папку, где находится исполняемый файл приложения
        private string GetProjectPath()
        {
            // Папка с exe (bin\Debug\...)
            return Application.StartupPath;
        }

        // Пути по умолчанию для входного, зашифрованного и расшифрованного файлов
        private string InputFilePath => Path.Combine(GetProjectPath(), "input.txt");
        private string EncryptedFilePath => Path.Combine(GetProjectPath(), "encrypted.txt");
        private string DecryptedFilePath => Path.Combine(GetProjectPath(), "decrypted.txt");

        // Загрузить текст из файла (если отмечено), иначе из поля для ввода
        private string LoadTextIfNeeded()
        {
            if (!LoadFromFileCheckBox.Checked)
                return PlainTextBox.Text;

            if (!File.Exists(InputFilePath))
                throw new FileNotFoundException("Входной файл не найден.", InputFilePath);

            return File.ReadAllText(InputFilePath, Encoding.UTF8);
        }

        // Сохранить результат в файл, если выбрана соответствующая опция
        private void SaveResultIfNeeded(string result, bool encryptMode)
        {
            if (!SaveToFileCheckBox.Checked) return;

            string path = encryptMode ? EncryptedFilePath : DecryptedFilePath;
            File.WriteAllText(path, result, Encoding.UTF8);
            MessageBox.Show($"Файл сохранён:\n{path}", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Обработчик нажатия кнопки "Зашифровать"
        private void EncryptButton_Click(object? sender, EventArgs e)
        {
            try
            {
                string sourceText = LoadTextIfNeeded();   // получаем исходный текст
                string keyText = KeyTextBox.Text;         // получаем ключ

                string result;
                if (DecimalChoice.Checked)                // выбран метод децимации?
                {
                    string keyDigits = ExtractDigits(keyText);
                    if (!int.TryParse(keyDigits, out int k))
                    {
                        MessageBox.Show("Для метода децимаций ключ должен быть целым числом.");
                        return;
                    }
                    result = DecimationEncrypt(sourceText, k);
                }
                else if (VigenerChoice.Checked)           // выбран метод Виженера?
                {
                    result = VigenerAutoEncrypt(sourceText, keyText);
                }
                else
                {
                    MessageBox.Show("Выберите метод шифрования.");
                    return;
                }

                CipherTextBox.Text = result;              // выводим результат в поле
                SaveResultIfNeeded(result, encryptMode: true); // сохраняем в файл, если нужно
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик нажатия кнопки "Расшифровать"
        private void DecryptButton_Click(object? sender, EventArgs e)
        {
            try
            {
                string sourceText = LoadTextIfNeeded();   // берем текст из файла или поля
                if (!string.IsNullOrWhiteSpace(CipherTextBox.Text) && !LoadFromFileCheckBox.Checked)
                    sourceText = CipherTextBox.Text;      // приоритет поля "зашифрованный текст", если не из файла

                string keyText = KeyTextBox.Text;         // получаем ключ

                string result;
                if (DecimalChoice.Checked)                // децимация?
                {
                    string keyDigits = ExtractDigits(keyText);
                    if (!int.TryParse(keyDigits, out int k))
                    {
                        MessageBox.Show("Для метода децимаций ключ должен быть целым числом.");
                        return;
                    }
                    result = DecimationDecrypt(sourceText, k);
                }
                else if (VigenerChoice.Checked)           // Виженер?
                {
                    result = VigenerAutoDecrypt(sourceText, keyText);
                }
                else
                {
                    MessageBox.Show("Выберите метод шифрования.");
                    return;
                }

                CipherTextBox.Text = result;               // вывод результата
                SaveResultIfNeeded(result, encryptMode: false); // сохраняем, если нужно
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Конструктор формы — инициализация компонентов WinForms
        public Form1()
        {
            InitializeComponent();
        }
    }
}
