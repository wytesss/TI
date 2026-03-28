namespace lab1
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
            LoadFromFileCheckBox = new CheckBox();
            SaveToFileCheckBox = new CheckBox();
            EncryptButton = new Button();
            DecryptButton = new Button();
            PlainTextBox = new TextBox();
            CipherTextBox = new TextBox();
            KeyTextBox = new TextBox();
            KeyLabel = new Label();
            PlainTextLabel = new Label();
            CipherTextLabel = new Label();
            DecimalChoice = new RadioButton();
            VigenerChoice = new RadioButton();
            ProcessGroupBox = new GroupBox();
            SettingsGroupBox = new GroupBox();
            MethodGroupBox = new GroupBox();
            ProcessGroupBox.SuspendLayout();
            SettingsGroupBox.SuspendLayout();
            MethodGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // LoadFromFileCheckBox
            // 
            LoadFromFileCheckBox.AutoSize = true;
            LoadFromFileCheckBox.Cursor = Cursors.Hand;
            LoadFromFileCheckBox.Font = new Font("Bahnschrift SemiLight", 9F);
            LoadFromFileCheckBox.Location = new Point(9, 26);
            LoadFromFileCheckBox.Name = "LoadFromFileCheckBox";
            LoadFromFileCheckBox.Size = new Size(173, 22);
            LoadFromFileCheckBox.TabIndex = 0;
            LoadFromFileCheckBox.Text = "Загрузить из файла?";
            LoadFromFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // SaveToFileCheckBox
            // 
            SaveToFileCheckBox.AutoSize = true;
            SaveToFileCheckBox.Cursor = Cursors.Hand;
            SaveToFileCheckBox.Font = new Font("Bahnschrift SemiLight", 9F);
            SaveToFileCheckBox.Location = new Point(9, 56);
            SaveToFileCheckBox.Name = "SaveToFileCheckBox";
            SaveToFileCheckBox.Size = new Size(162, 22);
            SaveToFileCheckBox.TabIndex = 1;
            SaveToFileCheckBox.Text = "Сохранить в файл?";
            SaveToFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // EncryptButton
            // 
            EncryptButton.Cursor = Cursors.Hand;
            EncryptButton.Font = new Font("Bahnschrift SemiLight", 9F);
            EncryptButton.Location = new Point(268, 37);
            EncryptButton.Name = "EncryptButton";
            EncryptButton.Size = new Size(163, 29);
            EncryptButton.TabIndex = 2;
            EncryptButton.Text = "Зашифровать";
            EncryptButton.UseVisualStyleBackColor = true;
            EncryptButton.Click += EncryptButton_Click;
            // 
            // DecryptButton
            // 
            DecryptButton.Cursor = Cursors.Hand;
            DecryptButton.Font = new Font("Bahnschrift SemiLight", 9F);
            DecryptButton.Location = new Point(9, 37);
            DecryptButton.Name = "DecryptButton";
            DecryptButton.Size = new Size(162, 29);
            DecryptButton.TabIndex = 3;
            DecryptButton.Text = "Расшифровать";
            DecryptButton.UseVisualStyleBackColor = true;
            DecryptButton.Click += DecryptButton_Click;
            // 
            // PlainTextBox
            // 
            PlainTextBox.Cursor = Cursors.IBeam;
            PlainTextBox.Font = new Font("Bahnschrift SemiLight", 9F);
            PlainTextBox.Location = new Point(37, 52);
            PlainTextBox.Multiline = true;
            PlainTextBox.Name = "PlainTextBox";
            PlainTextBox.Size = new Size(758, 271);
            PlainTextBox.TabIndex = 4;
            // 
            // CipherTextBox
            // 
            CipherTextBox.Cursor = Cursors.IBeam;
            CipherTextBox.Font = new Font("Bahnschrift SemiLight", 9F);
            CipherTextBox.Location = new Point(37, 361);
            CipherTextBox.Multiline = true;
            CipherTextBox.Name = "CipherTextBox";
            CipherTextBox.Size = new Size(758, 269);
            CipherTextBox.TabIndex = 5;
            // 
            // KeyTextBox
            // 
            KeyTextBox.Cursor = Cursors.IBeam;
            KeyTextBox.Font = new Font("Bahnschrift SemiLight", 9F);
            KeyTextBox.Location = new Point(816, 52);
            KeyTextBox.Multiline = true;
            KeyTextBox.Name = "KeyTextBox";
            KeyTextBox.Size = new Size(437, 271);
            KeyTextBox.TabIndex = 6;
            // 
            // KeyLabel
            // 
            KeyLabel.AutoSize = true;
            KeyLabel.Font = new Font("Bahnschrift SemiLight", 9F);
            KeyLabel.Location = new Point(997, 29);
            KeyLabel.Name = "KeyLabel";
            KeyLabel.Size = new Size(46, 18);
            KeyLabel.TabIndex = 7;
            KeyLabel.Text = "Ключ";
            // 
            // PlainTextLabel
            // 
            PlainTextLabel.AutoSize = true;
            PlainTextLabel.Font = new Font("Bahnschrift SemiLight", 9F);
            PlainTextLabel.Location = new Point(340, 29);
            PlainTextLabel.Name = "PlainTextLabel";
            PlainTextLabel.Size = new Size(121, 18);
            PlainTextLabel.TabIndex = 8;
            PlainTextLabel.Text = "Исходный текст";
            // 
            // CipherTextLabel
            // 
            CipherTextLabel.AutoSize = true;
            CipherTextLabel.FlatStyle = FlatStyle.System;
            CipherTextLabel.Font = new Font("Bahnschrift SemiLight", 9F);
            CipherTextLabel.Location = new Point(365, 340);
            CipherTextLabel.Name = "CipherTextLabel";
            CipherTextLabel.Size = new Size(76, 18);
            CipherTextLabel.TabIndex = 9;
            CipherTextLabel.Text = "Результат";
            // 
            // DecimalChoice
            // 
            DecimalChoice.AutoSize = true;
            DecimalChoice.Cursor = Cursors.Hand;
            DecimalChoice.Font = new Font("Bahnschrift SemiLight", 9F);
            DecimalChoice.Location = new Point(9, 35);
            DecimalChoice.Name = "DecimalChoice";
            DecimalChoice.Size = new Size(157, 22);
            DecimalChoice.TabIndex = 10;
            DecimalChoice.TabStop = true;
            DecimalChoice.Text = "Метод Децимаций";
            DecimalChoice.UseVisualStyleBackColor = true;
            // 
            // VigenerChoice
            // 
            VigenerChoice.AutoSize = true;
            VigenerChoice.Cursor = Cursors.Hand;
            VigenerChoice.Font = new Font("Bahnschrift SemiLight", 9F);
            VigenerChoice.Location = new Point(268, 35);
            VigenerChoice.Name = "VigenerChoice";
            VigenerChoice.Size = new Size(147, 22);
            VigenerChoice.TabIndex = 11;
            VigenerChoice.TabStop = true;
            VigenerChoice.Text = "Метод Виженера";
            VigenerChoice.UseVisualStyleBackColor = true;
            // 
            // ProcessGroupBox
            // 
            ProcessGroupBox.Controls.Add(DecryptButton);
            ProcessGroupBox.Controls.Add(EncryptButton);
            ProcessGroupBox.Font = new Font("Bahnschrift SemiLight", 9F);
            ProcessGroupBox.Location = new Point(816, 545);
            ProcessGroupBox.Name = "ProcessGroupBox";
            ProcessGroupBox.Size = new Size(437, 85);
            ProcessGroupBox.TabIndex = 14;
            ProcessGroupBox.TabStop = false;
            ProcessGroupBox.Text = "Действие";
            // 
            // SettingsGroupBox
            // 
            SettingsGroupBox.Controls.Add(LoadFromFileCheckBox);
            SettingsGroupBox.Controls.Add(SaveToFileCheckBox);
            SettingsGroupBox.Font = new Font("Bahnschrift SemiLight", 9F);
            SettingsGroupBox.Location = new Point(816, 441);
            SettingsGroupBox.Name = "SettingsGroupBox";
            SettingsGroupBox.Size = new Size(437, 98);
            SettingsGroupBox.TabIndex = 15;
            SettingsGroupBox.TabStop = false;
            SettingsGroupBox.Text = "Настройки";
            // 
            // MethodGroupBox
            // 
            MethodGroupBox.Controls.Add(DecimalChoice);
            MethodGroupBox.Controls.Add(VigenerChoice);
            MethodGroupBox.Font = new Font("Bahnschrift SemiLight", 9F);
            MethodGroupBox.Location = new Point(816, 361);
            MethodGroupBox.Name = "MethodGroupBox";
            MethodGroupBox.Size = new Size(437, 74);
            MethodGroupBox.TabIndex = 16;
            MethodGroupBox.TabStop = false;
            MethodGroupBox.Text = "Метод";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1285, 657);
            Controls.Add(MethodGroupBox);
            Controls.Add(SettingsGroupBox);
            Controls.Add(ProcessGroupBox);
            Controls.Add(CipherTextLabel);
            Controls.Add(PlainTextLabel);
            Controls.Add(KeyLabel);
            Controls.Add(KeyTextBox);
            Controls.Add(CipherTextBox);
            Controls.Add(PlainTextBox);
            Name = "Form1";
            Text = "Криптография";
            ProcessGroupBox.ResumeLayout(false);
            SettingsGroupBox.ResumeLayout(false);
            SettingsGroupBox.PerformLayout();
            MethodGroupBox.ResumeLayout(false);
            MethodGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox LoadFromFileCheckBox;
        private CheckBox SaveToFileCheckBox;
        private Button EncryptButton;
        private Button DecryptButton;
        private TextBox PlainTextBox;
        private TextBox CipherTextBox;
        private TextBox KeyTextBox;
        private Label KeyLabel;
        private Label PlainTextLabel;
        private Label CipherTextLabel;
        private RadioButton DecimalChoice;
        private RadioButton VigenerChoice;
        private GroupBox ProcessGroupBox;
        private GroupBox SettingsGroupBox;
        private GroupBox MethodGroupBox;
    }
}
