using System.Numerics;

namespace lab3_Rabin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Инициализация всех контролов WinForms (создаются в Designer).
            InitializeComponent();
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки шифрования: валидирует параметры и пути, затем запускает шифрование файла.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем математические параметры перед любыми файловыми операциями.
                if (!TryGetParameters(out BigInteger p, out BigInteger q, out BigInteger b, out BigInteger n, out string error))
                {
                    ShowError(error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEncryptInput.Text) || !File.Exists(txtEncryptInput.Text))
                {
                    ShowError("Выберите корректный исходный файл для шифрования.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEncryptOutput.Text))
                {
                    ShowError("Выберите путь для сохранения зашифрованного файла.");
                    return;
                }

                // Сервис шифрует исходный файл побайтно и записывает каждый c в 4-байтовый блок.
                RabinCryptoService.EncryptFile(txtEncryptInput.Text, txtEncryptOutput.Text, b, n);
                SetStatus("Шифрование завершено успешно.");
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка шифрования: {ex.Message}");
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки дешифрования: валидирует параметры и пути, затем запускает дешифрование файла.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                // Для дешифрования должны быть заданы те же p, q, b, что использовались при шифровании.
                if (!TryGetParameters(out BigInteger p, out BigInteger q, out BigInteger b, out BigInteger n, out string error))
                {
                    ShowError(error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDecryptInput.Text) || !File.Exists(txtDecryptInput.Text))
                {
                    ShowError("Выберите корректный зашифрованный файл.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDecryptOutput.Text))
                {
                    ShowError("Выберите путь для сохранения расшифрованного файла.");
                    return;
                }

                // Сервис читает шифротекст по 4 байта, восстанавливает 1 байт и пишет в выходной файл.
                RabinCryptoService.DecryptFile(txtDecryptInput.Text, txtDecryptOutput.Text, p, q, b, n);
                SetStatus("Дешифрование завершено успешно.");
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка дешифрования: {ex.Message}");
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки просмотра содержимого шифротекста в виде десятичных 4-байтовых блоков.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnShowContent_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtViewInput.Text) || !File.Exists(txtViewInput.Text))
                {
                    ShowError("Выберите корректный зашифрованный файл для просмотра.");
                    return;
                }

                // Показываем десятичные значения 4-байтовых блоков шифротекста.
                txtOutput.Text = RabinCryptoService.ReadEncryptedContent(txtViewInput.Text);
                SetStatus("Содержимое файла отображено.");
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка чтения файла: {ex.Message}");
            }
        }

        /// <summary>
        /// Считывает и проверяет параметры p, q, b из полей формы.
        /// </summary>
        /// <param name="p">Простое число p (выход).</param>
        /// <param name="q">Простое число q (выход).</param>
        /// <param name="b">Параметр b (выход).</param>
        /// <param name="n">Модуль n = p*q (выход).</param>
        /// <param name="error">Текст ошибки при неуспешной валидации.</param>
        /// <returns>true, если параметры корректны; иначе false.</returns>
        private bool TryGetParameters(out BigInteger p, out BigInteger q, out BigInteger b, out BigInteger n, out string error)
        {
            p = BigInteger.Zero;
            q = BigInteger.Zero;
            b = BigInteger.Zero;
            n = BigInteger.Zero;
            error = string.Empty;

            if (!BigInteger.TryParse(txtP.Text.Trim(), out p) || p <= 0)
            {
                error = "Некорректное значение p.";
                return false;
            }

            if (!BigInteger.TryParse(txtQ.Text.Trim(), out q) || q <= 0)
            {
                error = "Некорректное значение q.";
                return false;
            }

            if (!BigInteger.TryParse(txtB.Text.Trim(), out b))
            {
                error = "Некорректное значение b.";
                return false;
            }

            // n используется и в проверках, и в формулах Рабина.
            n = p * q;
            // Подробные математические проверки вынесены в сервис.
            return RabinCryptoService.TryValidateParameters(p, q, b, out error);
        }

        /// <summary>
        /// Показывает сообщение об ошибке и обновляет статусную строку.
        /// </summary>
        /// <param name="message">Текст сообщения об ошибке.</param>
        private void ShowError(string message)
        {
            // Ошибку показываем и в статусе, и через диалог, чтобы пользователь точно увидел причину.
            SetStatus(message);
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Обновляет текст статусной строки формы.
        /// </summary>
        /// <param name="message">Новый текст статуса.</param>
        private void SetStatus(string message)
        {
            lblStatus.Text = message;
        }

        /// <summary>
        /// Открывает диалог выбора исходного файла для шифрования.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnBrowseEncryptInput_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new() { Title = "Выберите файл для шифрования", Filter = "Все файлы|*.*" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtEncryptInput.Text = dialog.FileName;
                if (string.IsNullOrWhiteSpace(txtEncryptOutput.Text))
                {
                    // Дефолт: добавляем .rabin к исходному имени.
                    txtEncryptOutput.Text = dialog.FileName + ".rabin";
                }
            }
        }

        /// <summary>
        /// Открывает диалог выбора пути сохранения зашифрованного файла.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnBrowseEncryptOutput_Click(object sender, EventArgs e)
        {
            using SaveFileDialog dialog = new()
            {
                Title = "Куда сохранить зашифрованный файл",
                Filter = "Rabin files|*.rabin|Все файлы|*.*",
                FileName = string.IsNullOrWhiteSpace(txtEncryptInput.Text)
                    ? "encrypted.rabin"
                    : Path.GetFileName(txtEncryptInput.Text) + ".rabin"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtEncryptOutput.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// Открывает диалог выбора входного шифротекста для дешифрования.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnBrowseDecryptInput_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new() { Title = "Выберите зашифрованный файл", Filter = "Rabin files|*.rabin|Все файлы|*.*" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtDecryptInput.Text = dialog.FileName;
                // Подставляем тот же файл и в блок просмотра содержимого шифротекста.
                txtViewInput.Text = dialog.FileName;
                if (string.IsNullOrWhiteSpace(txtDecryptOutput.Text))
                {
                    // Для файла вида image.png.rabin по умолчанию получим image.png.
                    string baseName = Path.GetFileNameWithoutExtension(dialog.FileName);
                    txtDecryptOutput.Text = Path.Combine(Path.GetDirectoryName(dialog.FileName) ?? string.Empty,
                        baseName);
                }
            }
        }

        /// <summary>
        /// Открывает диалог выбора пути сохранения расшифрованного файла.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnBrowseDecryptOutput_Click(object sender, EventArgs e)
        {
            using SaveFileDialog dialog = new()
            {
                Title = "Куда сохранить расшифрованный файл",
                Filter = "Все файлы|*.*",
                FileName = string.IsNullOrWhiteSpace(txtDecryptInput.Text)
                    ? "decrypted.bin"
                    : Path.GetFileNameWithoutExtension(txtDecryptInput.Text)
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtDecryptOutput.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// Открывает диалог выбора шифрованного файла для просмотра содержимого блоков.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnBrowseViewInput_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new() { Title = "Выберите зашифрованный файл", Filter = "Rabin files|*.rabin|Все файлы|*.*" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtViewInput.Text = dialog.FileName;
            }
        }
    }
}
