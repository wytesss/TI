namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            txtLfsrState.Text = new string('1', 26);
        }

        private void TxtLfsrState_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;
            if (e.KeyChar is not ('0' or '1'))
                e.Handled = true;
        }

        private void BtnSelectFile_Click(object? sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title = "Выберите файл",
                Filter = "Все файлы (*.*)|*.*",
                CheckFileExists = true
            };
            if (dlg.ShowDialog(this) == DialogResult.OK)
                txtFilePath.Text = dlg.FileName;
        }

        private async void BtnEncrypt_Click(object? sender, EventArgs e)
        {
            if (!ValidateInputs(out uint state))
                return;

            string inputPath = txtFilePath.Text.Trim();
            string outputPath = inputPath + ".enc";

            try
            {
                SetBusy(true, "Шифрование…");
                string plain = "";
                string cipher = "";
                string key = "";
                await Task.Run(() =>
                    FileCryptoService.ProcessXor(inputPath, outputPath, state, out plain, out cipher, out key));

                txtPlainBits.Text = plain;
                txtCipherBits.Text = cipher;
                txtKeyPreview.Text = key;
                toolStripStatusLabel.Text = "Зашифровано: " + outputPath;
            }
            catch (Exception ex)
            {
                toolStripStatusLabel.Text = "Ошибка: " + ex.Message;
                MessageBox.Show(this, ex.Message, "Ошибка шифрования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetBusy(false, null);
            }
        }

        private async void BtnDecrypt_Click(object? sender, EventArgs e)
        {
            if (!ValidateInputs(out uint state))
                return;

            string inputPath = txtFilePath.Text.Trim();
            if (!inputPath.EndsWith(".enc", StringComparison.OrdinalIgnoreCase))
            {
                toolStripStatusLabel.Text = "Для расшифровки выберите файл с расширением .enc";
                MessageBox.Show(this, "Выберите зашифрованный файл (*.enc).", "Расшифровка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string? dir = Path.GetDirectoryName(inputPath);
            if (string.IsNullOrEmpty(dir))
            {
                toolStripStatusLabel.Text = "Некорректный путь к файлу.";
                return;
            }

            string nameWithoutEnc = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(dir, nameWithoutEnc);

            try
            {
                SetBusy(true, "Расшифрование…");
                string plain = "";
                string cipher = "";
                string key = "";
                await Task.Run(() =>
                    FileCryptoService.ProcessXor(inputPath, outputPath, state, out plain, out cipher, out key));

                txtPlainBits.Text = cipher;
                txtCipherBits.Text = plain;
                txtKeyPreview.Text = key;
                toolStripStatusLabel.Text = "Расшифровано: " + outputPath;
            }
            catch (Exception ex)
            {
                toolStripStatusLabel.Text = "Ошибка: " + ex.Message;
                MessageBox.Show(this, ex.Message, "Ошибка расшифровки", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetBusy(false, null);
            }
        }

        private bool ValidateInputs(out uint state)
        {
            state = 0;
            if (string.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                toolStripStatusLabel.Text = "Выберите файл.";
                MessageBox.Show(this, "Укажите файл.", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!File.Exists(txtFilePath.Text.Trim()))
            {
                toolStripStatusLabel.Text = "Файл не найден.";
                MessageBox.Show(this, "Файл не существует.", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!FileCryptoService.IsValidLfsrInput(txtLfsrState.Text))
            {
                toolStripStatusLabel.Text = "В состоянии LFSR допустимы только 0 и 1.";
                MessageBox.Show(this, "Введите только символы 0 и 1.", "Состояние LFSR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            state = FileCryptoService.ParseLfsrState(txtLfsrState.Text);
            return true;
        }

        private void SetBusy(bool busy, string? statusText)
        {
            btnEncrypt.Enabled = !busy;
            btnDecrypt.Enabled = !busy;
            btnSelectFile.Enabled = !busy;
            txtLfsrState.Enabled = !busy;
            if (statusText != null)
                toolStripStatusLabel.Text = statusText;
            Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
            UseWaitCursor = busy;
        }
    }
}
