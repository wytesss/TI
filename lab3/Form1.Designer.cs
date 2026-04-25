namespace lab3_Rabin
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblP = new Label();
            lblQ = new Label();
            lblB = new Label();
            txtP = new TextBox();
            txtQ = new TextBox();
            txtB = new TextBox();
            grpEncrypt = new GroupBox();
            btnEncrypt = new Button();
            btnBrowseEncryptOutput = new Button();
            btnBrowseEncryptInput = new Button();
            txtEncryptOutput = new TextBox();
            txtEncryptInput = new TextBox();
            lblEncryptOutput = new Label();
            lblEncryptInput = new Label();
            grpDecrypt = new GroupBox();
            btnDecrypt = new Button();
            btnBrowseDecryptOutput = new Button();
            btnBrowseDecryptInput = new Button();
            txtDecryptOutput = new TextBox();
            txtDecryptInput = new TextBox();
            lblDecryptOutput = new Label();
            lblDecryptInput = new Label();
            grpView = new GroupBox();
            btnShowContent = new Button();
            btnBrowseViewInput = new Button();
            txtViewInput = new TextBox();
            lblViewInput = new Label();
            txtOutput = new TextBox();
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            grpEncrypt.SuspendLayout();
            grpDecrypt.SuspendLayout();
            grpView.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // lblP
            // 
            lblP.AutoSize = true;
            lblP.Location = new Point(18, 21);
            lblP.Name = "lblP";
            lblP.Size = new Size(21, 20);
            lblP.TabIndex = 0;
            lblP.Text = "p:";
            // 
            // lblQ
            // 
            lblQ.AutoSize = true;
            lblQ.Location = new Point(240, 21);
            lblQ.Name = "lblQ";
            lblQ.Size = new Size(21, 20);
            lblQ.TabIndex = 1;
            lblQ.Text = "q:";
            // 
            // lblB
            // 
            lblB.AutoSize = true;
            lblB.Location = new Point(462, 21);
            lblB.Name = "lblB";
            lblB.Size = new Size(21, 20);
            lblB.TabIndex = 2;
            lblB.Text = "b:";
            // 
            // txtP
            // 
            txtP.Location = new Point(41, 17);
            txtP.Margin = new Padding(3, 4, 3, 4);
            txtP.Name = "txtP";
            txtP.Size = new Size(182, 27);
            txtP.TabIndex = 3;
            // 
            // txtQ
            // 
            txtQ.Location = new Point(263, 17);
            txtQ.Margin = new Padding(3, 4, 3, 4);
            txtQ.Name = "txtQ";
            txtQ.Size = new Size(182, 27);
            txtQ.TabIndex = 4;
            // 
            // txtB
            // 
            txtB.Location = new Point(485, 17);
            txtB.Margin = new Padding(3, 4, 3, 4);
            txtB.Name = "txtB";
            txtB.Size = new Size(182, 27);
            txtB.TabIndex = 5;
            // 
            // grpEncrypt
            // 
            grpEncrypt.Controls.Add(btnEncrypt);
            grpEncrypt.Controls.Add(btnBrowseEncryptOutput);
            grpEncrypt.Controls.Add(btnBrowseEncryptInput);
            grpEncrypt.Controls.Add(txtEncryptOutput);
            grpEncrypt.Controls.Add(txtEncryptInput);
            grpEncrypt.Controls.Add(lblEncryptOutput);
            grpEncrypt.Controls.Add(lblEncryptInput);
            grpEncrypt.Location = new Point(18, 67);
            grpEncrypt.Margin = new Padding(3, 4, 3, 4);
            grpEncrypt.Name = "grpEncrypt";
            grpEncrypt.Padding = new Padding(3, 4, 3, 4);
            grpEncrypt.Size = new Size(882, 155);
            grpEncrypt.TabIndex = 6;
            grpEncrypt.TabStop = false;
            grpEncrypt.Text = "Шифрование";
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(713, 99);
            btnEncrypt.Margin = new Padding(3, 4, 3, 4);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(153, 40);
            btnEncrypt.TabIndex = 6;
            btnEncrypt.Text = "Зашифровать";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // btnBrowseEncryptOutput
            // 
            btnBrowseEncryptOutput.Location = new Point(774, 64);
            btnBrowseEncryptOutput.Margin = new Padding(3, 4, 3, 4);
            btnBrowseEncryptOutput.Name = "btnBrowseEncryptOutput";
            btnBrowseEncryptOutput.Size = new Size(93, 31);
            btnBrowseEncryptOutput.TabIndex = 5;
            btnBrowseEncryptOutput.Text = "Сохранить";
            btnBrowseEncryptOutput.UseVisualStyleBackColor = true;
            btnBrowseEncryptOutput.Click += btnBrowseEncryptOutput_Click;
            // 
            // btnBrowseEncryptInput
            // 
            btnBrowseEncryptInput.Location = new Point(774, 27);
            btnBrowseEncryptInput.Margin = new Padding(3, 4, 3, 4);
            btnBrowseEncryptInput.Name = "btnBrowseEncryptInput";
            btnBrowseEncryptInput.Size = new Size(93, 31);
            btnBrowseEncryptInput.TabIndex = 4;
            btnBrowseEncryptInput.Text = "Обзор";
            btnBrowseEncryptInput.UseVisualStyleBackColor = true;
            btnBrowseEncryptInput.Click += btnBrowseEncryptInput_Click;
            // 
            // txtEncryptOutput
            // 
            txtEncryptOutput.Location = new Point(203, 64);
            txtEncryptOutput.Margin = new Padding(3, 4, 3, 4);
            txtEncryptOutput.Name = "txtEncryptOutput";
            txtEncryptOutput.Size = new Size(563, 27);
            txtEncryptOutput.TabIndex = 3;
            // 
            // txtEncryptInput
            // 
            txtEncryptInput.Location = new Point(203, 27);
            txtEncryptInput.Margin = new Padding(3, 4, 3, 4);
            txtEncryptInput.Name = "txtEncryptInput";
            txtEncryptInput.Size = new Size(563, 27);
            txtEncryptInput.TabIndex = 2;
            // 
            // lblEncryptOutput
            // 
            lblEncryptOutput.AutoSize = true;
            lblEncryptOutput.Location = new Point(14, 68);
            lblEncryptOutput.Name = "lblEncryptOutput";
            lblEncryptOutput.Size = new Size(164, 20);
            lblEncryptOutput.TabIndex = 1;
            lblEncryptOutput.Text = "Куда сохранить шифр:";
            // 
            // lblEncryptInput
            // 
            lblEncryptInput.AutoSize = true;
            lblEncryptInput.Location = new Point(14, 31);
            lblEncryptInput.Name = "lblEncryptInput";
            lblEncryptInput.Size = new Size(171, 20);
            lblEncryptInput.TabIndex = 0;
            lblEncryptInput.Text = "Файл для шифрования:";
            // 
            // grpDecrypt
            // 
            grpDecrypt.Controls.Add(btnDecrypt);
            grpDecrypt.Controls.Add(btnBrowseDecryptOutput);
            grpDecrypt.Controls.Add(btnBrowseDecryptInput);
            grpDecrypt.Controls.Add(txtDecryptOutput);
            grpDecrypt.Controls.Add(txtDecryptInput);
            grpDecrypt.Controls.Add(lblDecryptOutput);
            grpDecrypt.Controls.Add(lblDecryptInput);
            grpDecrypt.Location = new Point(18, 229);
            grpDecrypt.Margin = new Padding(3, 4, 3, 4);
            grpDecrypt.Name = "grpDecrypt";
            grpDecrypt.Padding = new Padding(3, 4, 3, 4);
            grpDecrypt.Size = new Size(882, 155);
            grpDecrypt.TabIndex = 7;
            grpDecrypt.TabStop = false;
            grpDecrypt.Text = "Дешифрование";
            // 
            // btnDecrypt
            // 
            btnDecrypt.Location = new Point(713, 99);
            btnDecrypt.Margin = new Padding(3, 4, 3, 4);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(153, 40);
            btnDecrypt.TabIndex = 7;
            btnDecrypt.Text = "Расшифровать";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // btnBrowseDecryptOutput
            // 
            btnBrowseDecryptOutput.Location = new Point(774, 64);
            btnBrowseDecryptOutput.Margin = new Padding(3, 4, 3, 4);
            btnBrowseDecryptOutput.Name = "btnBrowseDecryptOutput";
            btnBrowseDecryptOutput.Size = new Size(93, 31);
            btnBrowseDecryptOutput.TabIndex = 6;
            btnBrowseDecryptOutput.Text = "Сохранить";
            btnBrowseDecryptOutput.UseVisualStyleBackColor = true;
            btnBrowseDecryptOutput.Click += btnBrowseDecryptOutput_Click;
            // 
            // btnBrowseDecryptInput
            // 
            btnBrowseDecryptInput.Location = new Point(774, 27);
            btnBrowseDecryptInput.Margin = new Padding(3, 4, 3, 4);
            btnBrowseDecryptInput.Name = "btnBrowseDecryptInput";
            btnBrowseDecryptInput.Size = new Size(93, 31);
            btnBrowseDecryptInput.TabIndex = 5;
            btnBrowseDecryptInput.Text = "Обзор";
            btnBrowseDecryptInput.UseVisualStyleBackColor = true;
            btnBrowseDecryptInput.Click += btnBrowseDecryptInput_Click;
            // 
            // txtDecryptOutput
            // 
            txtDecryptOutput.Location = new Point(203, 64);
            txtDecryptOutput.Margin = new Padding(3, 4, 3, 4);
            txtDecryptOutput.Name = "txtDecryptOutput";
            txtDecryptOutput.Size = new Size(563, 27);
            txtDecryptOutput.TabIndex = 4;
            // 
            // txtDecryptInput
            // 
            txtDecryptInput.Location = new Point(203, 27);
            txtDecryptInput.Margin = new Padding(3, 4, 3, 4);
            txtDecryptInput.Name = "txtDecryptInput";
            txtDecryptInput.Size = new Size(563, 27);
            txtDecryptInput.TabIndex = 3;
            // 
            // lblDecryptOutput
            // 
            lblDecryptOutput.AutoSize = true;
            lblDecryptOutput.Location = new Point(14, 68);
            lblDecryptOutput.Name = "lblDecryptOutput";
            lblDecryptOutput.Size = new Size(191, 20);
            lblDecryptOutput.TabIndex = 2;
            lblDecryptOutput.Text = "Куда сохранить результат:";
            // 
            // lblDecryptInput
            // 
            lblDecryptInput.AutoSize = true;
            lblDecryptInput.Location = new Point(14, 31);
            lblDecryptInput.Name = "lblDecryptInput";
            lblDecryptInput.Size = new Size(170, 20);
            lblDecryptInput.TabIndex = 1;
            lblDecryptInput.Text = "Зашифрованный файл:";
            // 
            // grpView
            // 
            grpView.Controls.Add(btnShowContent);
            grpView.Controls.Add(btnBrowseViewInput);
            grpView.Controls.Add(txtViewInput);
            grpView.Controls.Add(lblViewInput);
            grpView.Location = new Point(18, 392);
            grpView.Margin = new Padding(3, 4, 3, 4);
            grpView.Name = "grpView";
            grpView.Padding = new Padding(3, 4, 3, 4);
            grpView.Size = new Size(882, 83);
            grpView.TabIndex = 8;
            grpView.TabStop = false;
            grpView.Text = "Просмотр байт шифротекста в десятичном представлнеии";
            // 
            // btnShowContent
            // 
            btnShowContent.Location = new Point(713, 32);
            btnShowContent.Margin = new Padding(3, 4, 3, 4);
            btnShowContent.Name = "btnShowContent";
            btnShowContent.Size = new Size(153, 31);
            btnShowContent.TabIndex = 8;
            btnShowContent.Text = "Показать содержимое";
            btnShowContent.UseVisualStyleBackColor = true;
            btnShowContent.Click += btnShowContent_Click;
            // 
            // btnBrowseViewInput
            // 
            btnBrowseViewInput.Location = new Point(614, 32);
            btnBrowseViewInput.Margin = new Padding(3, 4, 3, 4);
            btnBrowseViewInput.Name = "btnBrowseViewInput";
            btnBrowseViewInput.Size = new Size(93, 31);
            btnBrowseViewInput.TabIndex = 2;
            btnBrowseViewInput.Text = "Обзор";
            btnBrowseViewInput.UseVisualStyleBackColor = true;
            btnBrowseViewInput.Click += btnBrowseViewInput_Click;
            // 
            // txtViewInput
            // 
            txtViewInput.Location = new Point(167, 32);
            txtViewInput.Margin = new Padding(3, 4, 3, 4);
            txtViewInput.Name = "txtViewInput";
            txtViewInput.Size = new Size(439, 27);
            txtViewInput.TabIndex = 1;
            // 
            // lblViewInput
            // 
            lblViewInput.AutoSize = true;
            lblViewInput.Location = new Point(14, 36);
            lblViewInput.Name = "lblViewInput";
            lblViewInput.Size = new Size(143, 20);
            lblViewInput.TabIndex = 0;
            lblViewInput.Text = "Файл шифротекста:";
            // 
            // txtOutput
            // 
            txtOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtOutput.Location = new Point(18, 483);
            txtOutput.Margin = new Padding(3, 4, 3, 4);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(882, 171);
            txtOutput.TabIndex = 9;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip.Location = new Point(0, 675);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(918, 26);
            statusStrip.TabIndex = 10;
            statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(121, 20);
            lblStatus.Text = "Готово к работе";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(918, 701);
            Controls.Add(statusStrip);
            Controls.Add(txtOutput);
            Controls.Add(grpView);
            Controls.Add(grpDecrypt);
            Controls.Add(grpEncrypt);
            Controls.Add(txtB);
            Controls.Add(txtQ);
            Controls.Add(txtP);
            Controls.Add(lblB);
            Controls.Add(lblQ);
            Controls.Add(lblP);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Криптосистема Рабина";
            grpEncrypt.ResumeLayout(false);
            grpEncrypt.PerformLayout();
            grpDecrypt.ResumeLayout(false);
            grpDecrypt.PerformLayout();
            grpView.ResumeLayout(false);
            grpView.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.Label lblQ;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.TextBox txtQ;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.GroupBox grpEncrypt;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnBrowseEncryptOutput;
        private System.Windows.Forms.Button btnBrowseEncryptInput;
        private System.Windows.Forms.TextBox txtEncryptOutput;
        private System.Windows.Forms.TextBox txtEncryptInput;
        private System.Windows.Forms.Label lblEncryptOutput;
        private System.Windows.Forms.Label lblEncryptInput;
        private System.Windows.Forms.GroupBox grpDecrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnBrowseDecryptOutput;
        private System.Windows.Forms.Button btnBrowseDecryptInput;
        private System.Windows.Forms.TextBox txtDecryptOutput;
        private System.Windows.Forms.TextBox txtDecryptInput;
        private System.Windows.Forms.Label lblDecryptOutput;
        private System.Windows.Forms.Label lblDecryptInput;
        private System.Windows.Forms.GroupBox grpView;
        private System.Windows.Forms.Button btnShowContent;
        private System.Windows.Forms.Button btnBrowseViewInput;
        private System.Windows.Forms.TextBox txtViewInput;
        private System.Windows.Forms.Label lblViewInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}
