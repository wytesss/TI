using System.Text;

namespace lab2
{
    /// <summary>
    /// Потоковое шифрование/дешифрование файла побитовым XOR с LFSR.
    /// </summary>
    public static class FileCryptoService
    {
        private const int BufferSize = 4096;

        /// <summary>
        /// Нормализует строку состояния: только 0/1; меньше 26 — дополнение слева нулями; больше — первые 26 после фильтрации.
        /// </summary>
        public static uint ParseLfsrState(string? raw)
        {
            if (string.IsNullOrEmpty(raw))
                return 0;

            var sb = new StringBuilder(32);
            foreach (char c in raw)
            {
                if (c is '0' or '1')
                    sb.Append(c);
            }

            string s = sb.ToString();
            if (s.Length > 26)
                s = s.Substring(0, 26);
            else
                s = s.PadLeft(26, '0');

            uint state = 0;
            for (int i = 0; i < 26; i++)
                state = (state << 1) | (uint)(s[i] - '0');

            return state & 0x03FFFFFFU;
        }

        /// <summary>Ввод содержит только цифры 0/1 и пробельные символы.</summary>
        public static bool IsValidLfsrInput(string? raw)
        {
            if (string.IsNullOrEmpty(raw))
                return true;
            foreach (char c in raw)
            {
                if (c is not ('0' or '1') && !char.IsWhiteSpace(c))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// XOR файла с ключевым потоком LFSR. Биты байта обрабатываются от старшего к младшему (7 … 0).
        /// </summary>
        public static void ProcessXor(
            string inputPath,
            string outputPath,
            uint initialState,
            out string plainBits,
            out string cipherBits,
            out string keyPreview)
        {
            long fileLen = new FileInfo(inputPath).Length;
            if (fileLen * 8L > int.MaxValue)
                throw new InvalidOperationException("Файл слишком большой для отображения полной битовой строки в памяти.");

            int totalBits = checked((int)(fileLen * 8));

            var gen = new LFSRGenerator(initialState);
            var plainSb = new StringBuilder(totalBits);
            var cipherSb = new StringBuilder(totalBits);

            var first15 = new StringBuilder(15);
            var last15Ring = new char[15];
            int ringPos = 0;

            using var input = new FileStream(inputPath, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize, FileOptions.SequentialScan);
            using var output = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None, BufferSize, FileOptions.SequentialScan);

            var buffer = new byte[BufferSize];
            long bitIndex = 0;

            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                for (int i = 0; i < read; i++)
                {
                    byte b = buffer[i];
                    plainSb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));

                    byte outByte = 0;
                    for (int bit = 7; bit >= 0; bit--)
                    {
                        int dataBit = (b >> bit) & 1; 
                        int keyBit = gen.NextBit();
                        int cBit = dataBit ^ keyBit; // xor 
                        outByte |= (byte)(cBit << bit); // задвигаем влево до заполнения байта

                        AppendKeyPreview(totalBits, bitIndex, keyBit, first15, last15Ring, ref ringPos);
                        bitIndex++;
                    }

                    cipherSb.Append(Convert.ToString(outByte, 2).PadLeft(8, '0'));
                    output.WriteByte(outByte);
                }
            }

            plainBits = plainSb.ToString();
            cipherBits = cipherSb.ToString();
            keyPreview = BuildKeyPreviewString(totalBits, first15, last15Ring, ringPos);
        }
            /// <summary>
            /// Составляет первые и последние 15 бит ключа.
            /// </summary>
            private static void AppendKeyPreview(
                int totalBits,
                long bitIndex,
                int keyBit,
                StringBuilder first15,
                char[] last15Ring,
                ref int ringPos)
            {
                char ch = keyBit == 1 ? '1' : '0';

                if (totalBits <= 30)
                {
                    first15.Append(ch);
                    return;
                }

                if (bitIndex < 15)
                    first15.Append(ch);

                last15Ring[ringPos] = ch;
                ringPos = (ringPos + 1) % 15;
            }
            /// <summary>
            /// Генерирует отображаемую строку из первых и последних бит ключа.
            /// </summary>
            private static string BuildKeyPreviewString(
                int totalBits,
                StringBuilder first15,
                char[] last15Ring,
                int ringPos)
            {
                if (totalBits <= 30)
                    return first15.ToString();

                var last = new StringBuilder(15);
                for (int k = 0; k < 15; k++)
                    last.Append(last15Ring[(ringPos + k) % 15]);

                return first15.ToString() + " ... " + last.ToString();
            }
    }
}
