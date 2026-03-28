namespace lab2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblFile = new Label();
            txtFilePath = new TextBox();
            btnSelectFile = new Button();
            lblLfsr = new Label();
            txtLfsrState = new TextBox();
            btnEncrypt = new Button();
            btnDecrypt = new Button();
            lblPlainBits = new Label();
            txtPlainBits = new TextBox();
            lblCipherBits = new Label();
            txtCipherBits = new TextBox();
            lblKeyPreview = new Label();
            txtKeyPreview = new TextBox();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            splitContainer = new SplitContainer();
            panelTop = new TableLayoutPanel();
            panelBits = new TableLayoutPanel();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            panelTop.SuspendLayout();
            panelBits.SuspendLayout();
            SuspendLayout();
            // 
            // lblFile
            // 
            lblFile.AutoSize = true;
            lblFile.Dock = DockStyle.Fill;
            lblFile.Location = new Point(3, 0);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(154, 43);
            lblFile.TabIndex = 0;
            lblFile.Text = "Исходный файл:";
            lblFile.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtFilePath
            // 
            txtFilePath.Dock = DockStyle.Fill;
            txtFilePath.Location = new Point(163, 4);
            txtFilePath.Margin = new Padding(3, 4, 3, 4);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.PlaceholderText = "Не выбран";
            txtFilePath.ReadOnly = true;
            txtFilePath.Size = new Size(818, 27);
            txtFilePath.TabIndex = 1;
            // 
            // btnSelectFile
            // 
            btnSelectFile.AutoSize = true;
            btnSelectFile.Location = new Point(987, 4);
            btnSelectFile.Margin = new Padding(3, 4, 3, 4);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(135, 35);
            btnSelectFile.TabIndex = 2;
            btnSelectFile.Text = "Выбрать файл";
            btnSelectFile.Click += BtnSelectFile_Click;
            // 
            // lblLfsr
            // 
            lblLfsr.AutoSize = true;
            lblLfsr.Dock = DockStyle.Fill;
            lblLfsr.Location = new Point(3, 43);
            lblLfsr.Name = "lblLfsr";
            lblLfsr.Size = new Size(154, 43);
            lblLfsr.TabIndex = 3;
            lblLfsr.Text = "Начальное состояние LFSR-26:";
            lblLfsr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtLfsrState
            // 
            panelTop.SetColumnSpan(txtLfsrState, 2);
            txtLfsrState.Dock = DockStyle.Fill;
            txtLfsrState.Location = new Point(163, 47);
            txtLfsrState.Margin = new Padding(3, 4, 3, 4);
            txtLfsrState.MaxLength = 64;
            txtLfsrState.Name = "txtLfsrState";
            txtLfsrState.Size = new Size(959, 27);
            txtLfsrState.TabIndex = 4;
            txtLfsrState.KeyPress += TxtLfsrState_KeyPress;
            // 
            // btnEncrypt
            // 
            btnEncrypt.AutoSize = true;
            btnEncrypt.Location = new Point(3, 90);
            btnEncrypt.Margin = new Padding(3, 4, 3, 4);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(130, 40);
            btnEncrypt.TabIndex = 5;
            btnEncrypt.Text = "Зашифровать";
            btnEncrypt.Click += BtnEncrypt_Click;
            // 
            // btnDecrypt
            // 
            btnDecrypt.AutoSize = true;
            btnDecrypt.Location = new Point(163, 90);
            btnDecrypt.Margin = new Padding(3, 4, 3, 4);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(121, 40);
            btnDecrypt.TabIndex = 6;
            btnDecrypt.Text = "Расшифровать";
            btnDecrypt.Click += BtnDecrypt_Click;
            // 
            // lblPlainBits
            // 
            lblPlainBits.AutoSize = true;
            lblPlainBits.Dock = DockStyle.Fill;
            lblPlainBits.Location = new Point(3, 0);
            lblPlainBits.Name = "lblPlainBits";
            lblPlainBits.Size = new Size(1119, 29);
            lblPlainBits.TabIndex = 0;
            lblPlainBits.Text = "Исходный файл (биты):";
            // 
            // txtPlainBits
            // 
            txtPlainBits.Dock = DockStyle.Fill;
            txtPlainBits.Font = new Font("Consolas", 9F);
            txtPlainBits.Location = new Point(3, 33);
            txtPlainBits.Margin = new Padding(3, 4, 3, 4);
            txtPlainBits.Multiline = true;
            txtPlainBits.Name = "txtPlainBits";
            txtPlainBits.ReadOnly = true;
            txtPlainBits.ScrollBars = ScrollBars.Vertical;
            txtPlainBits.Size = new Size(1119, 182);
            txtPlainBits.TabIndex = 1;
            txtPlainBits.WordWrap = false;
            // 
            // lblCipherBits
            // 
            lblCipherBits.AutoSize = true;
            lblCipherBits.Dock = DockStyle.Fill;
            lblCipherBits.Location = new Point(3, 219);
            lblCipherBits.Name = "lblCipherBits";
            lblCipherBits.Size = new Size(1119, 29);
            lblCipherBits.TabIndex = 2;
            lblCipherBits.Text = "Зашифрованный файл (биты):";
            // 
            // txtCipherBits
            // 
            txtCipherBits.Dock = DockStyle.Fill;
            txtCipherBits.Font = new Font("Consolas", 9F);
            txtCipherBits.Location = new Point(3, 252);
            txtCipherBits.Margin = new Padding(3, 4, 3, 4);
            txtCipherBits.Multiline = true;
            txtCipherBits.Name = "txtCipherBits";
            txtCipherBits.ReadOnly = true;
            txtCipherBits.ScrollBars = ScrollBars.Vertical;
            txtCipherBits.Size = new Size(1119, 182);
            txtCipherBits.TabIndex = 3;
            txtCipherBits.WordWrap = false;
            // 
            // lblKeyPreview
            // 
            lblKeyPreview.AutoSize = true;
            lblKeyPreview.Dock = DockStyle.Fill;
            lblKeyPreview.Location = new Point(3, 438);
            lblKeyPreview.Name = "lblKeyPreview";
            lblKeyPreview.Size = new Size(1119, 29);
            lblKeyPreview.TabIndex = 4;
            lblKeyPreview.Text = "Ключевой поток (первые 15 и последние 15 бит):";
            // 
            // txtKeyPreview
            // 
            txtKeyPreview.Dock = DockStyle.Fill;
            txtKeyPreview.Font = new Font("Consolas", 9F);
            txtKeyPreview.Location = new Point(3, 471);
            txtKeyPreview.Margin = new Padding(3, 4, 3, 4);
            txtKeyPreview.Multiline = true;
            txtKeyPreview.Name = "txtKeyPreview";
            txtKeyPreview.ReadOnly = true;
            txtKeyPreview.ScrollBars = ScrollBars.Vertical;
            txtKeyPreview.Size = new Size(1119, 67);
            txtKeyPreview.TabIndex = 5;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 707);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(1125, 26);
            statusStrip.TabIndex = 1;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(1108, 20);
            toolStripStatusLabel.Spring = true;
            toolStripStatusLabel.Text = "Готово";
            toolStripStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.FixedPanel = FixedPanel.Panel1;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Margin = new Padding(3, 4, 3, 4);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(panelTop);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(panelBits);
            splitContainer.Size = new Size(1125, 707);
            splitContainer.SplitterDistance = 160;
            splitContainer.SplitterWidth = 5;
            splitContainer.TabIndex = 0;
            // 
            // panelTop
            // 
            panelTop.ColumnCount = 3;
            panelTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            panelTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelTop.ColumnStyles.Add(new ColumnStyle());
            panelTop.Controls.Add(lblFile, 0, 0);
            panelTop.Controls.Add(txtFilePath, 1, 0);
            panelTop.Controls.Add(btnSelectFile, 2, 0);
            panelTop.Controls.Add(lblLfsr, 0, 1);
            panelTop.Controls.Add(txtLfsrState, 1, 1);
            panelTop.Controls.Add(btnEncrypt, 0, 2);
            panelTop.Controls.Add(btnDecrypt, 1, 2);
            panelTop.Dock = DockStyle.Fill;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.RowCount = 3;
            panelTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            panelTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            panelTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            panelTop.Size = new Size(1125, 160);
            panelTop.TabIndex = 0;
            // 
            // panelBits
            // 
            panelBits.ColumnCount = 1;
            panelBits.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelBits.Controls.Add(lblPlainBits, 0, 0);
            panelBits.Controls.Add(txtPlainBits, 0, 1);
            panelBits.Controls.Add(lblCipherBits, 0, 2);
            panelBits.Controls.Add(txtCipherBits, 0, 3);
            panelBits.Controls.Add(lblKeyPreview, 0, 4);
            panelBits.Controls.Add(txtKeyPreview, 0, 5);
            panelBits.Dock = DockStyle.Fill;
            panelBits.Location = new Point(0, 0);
            panelBits.Margin = new Padding(3, 4, 3, 4);
            panelBits.Name = "panelBits";
            panelBits.RowCount = 6;
            panelBits.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            panelBits.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelBits.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            panelBits.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelBits.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            panelBits.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            panelBits.Size = new Size(1125, 542);
            panelBits.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 733);
            Controls.Add(splitContainer);
            Controls.Add(statusStrip);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(729, 518);
            Name = "Form1";
            Text = "Потоковое шифрование LFSR-26";
            Load += Form1_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelBits.ResumeLayout(false);
            panelBits.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFile;
        private TextBox txtFilePath;
        private Button btnSelectFile;
        private Label lblLfsr;
        private TextBox txtLfsrState;
        private Button btnEncrypt;
        private Button btnDecrypt;
        private Label lblPlainBits;
        private TextBox txtPlainBits;
        private Label lblCipherBits;
        private TextBox txtCipherBits;
        private Label lblKeyPreview;
        private TextBox txtKeyPreview;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private SplitContainer splitContainer;
        private TableLayoutPanel panelTop;
        private TableLayoutPanel panelBits;
    }
}
