namespace ProjectRacing.Forms
{
    partial class FormHorse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelNameOfHorse = new Label();
            labelSex = new Label();
            labelDateOfBirthday = new Label();
            textBoxNameOfHorse = new TextBox();
            dateTimePickerDateOfBirthday = new DateTimePicker();
            buttonSave = new Button();
            buttonExit = new Button();
            labelOwner = new Label();
            comboBoxOwner = new ComboBox();
            comboBoxSex = new ComboBox();
            SuspendLayout();
            // 
            // labelNameOfHorse
            // 
            labelNameOfHorse.AutoSize = true;
            labelNameOfHorse.Location = new Point(12, 38);
            labelNameOfHorse.Name = "labelNameOfHorse";
            labelNameOfHorse.Size = new Size(94, 15);
            labelNameOfHorse.TabIndex = 0;
            labelNameOfHorse.Text = "Кличка лошади";
            // 
            // labelSex
            // 
            labelSex.AutoSize = true;
            labelSex.Location = new Point(18, 81);
            labelSex.Name = "labelSex";
            labelSex.Size = new Size(30, 15);
            labelSex.TabIndex = 1;
            labelSex.Text = "Пол";
            // 
            // labelDateOfBirthday
            // 
            labelDateOfBirthday.AutoSize = true;
            labelDateOfBirthday.Location = new Point(12, 120);
            labelDateOfBirthday.Name = "labelDateOfBirthday";
            labelDateOfBirthday.Size = new Size(90, 15);
            labelDateOfBirthday.TabIndex = 2;
            labelDateOfBirthday.Text = "Дата рождения";
            // 
            // textBoxNameOfHorse
            // 
            textBoxNameOfHorse.Location = new Point(112, 38);
            textBoxNameOfHorse.Name = "textBoxNameOfHorse";
            textBoxNameOfHorse.Size = new Size(100, 23);
            textBoxNameOfHorse.TabIndex = 3;
            // 
            // dateTimePickerDateOfBirthday
            // 
            dateTimePickerDateOfBirthday.Location = new Point(112, 120);
            dateTimePickerDateOfBirthday.Name = "dateTimePickerDateOfBirthday";
            dateTimePickerDateOfBirthday.Size = new Size(200, 23);
            dateTimePickerDateOfBirthday.TabIndex = 9;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(72, 149);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 10;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(203, 149);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(75, 23);
            buttonExit.TabIndex = 11;
            buttonExit.Text = "Отмена";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // labelOwner
            // 
            labelOwner.AutoSize = true;
            labelOwner.Location = new Point(12, 9);
            labelOwner.Name = "labelOwner";
            labelOwner.Size = new Size(59, 15);
            labelOwner.TabIndex = 12;
            labelOwner.Text = "Владелец";
            // 
            // comboBoxOwner
            // 
            comboBoxOwner.FormattingEnabled = true;
            comboBoxOwner.Location = new Point(112, 9);
            comboBoxOwner.Name = "comboBoxOwner";
            comboBoxOwner.Size = new Size(121, 23);
            comboBoxOwner.TabIndex = 13;
            // 
            // comboBoxSex
            // 
            comboBoxSex.FormattingEnabled = true;
            comboBoxSex.Location = new Point(62, 77);
            comboBoxSex.Name = "comboBoxSex";
            comboBoxSex.Size = new Size(121, 23);
            comboBoxSex.TabIndex = 16;
            // 
            // FormHorse
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(328, 184);
            Controls.Add(comboBoxSex);
            Controls.Add(comboBoxOwner);
            Controls.Add(labelOwner);
            Controls.Add(buttonExit);
            Controls.Add(buttonSave);
            Controls.Add(dateTimePickerDateOfBirthday);
            Controls.Add(textBoxNameOfHorse);
            Controls.Add(labelDateOfBirthday);
            Controls.Add(labelSex);
            Controls.Add(labelNameOfHorse);
            Name = "FormHorse";
            Text = "Лошадь";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNameOfHorse;
        private Label labelSex;
        private Label labelDateOfBirthday;
        private TextBox textBoxNameOfHorse;
        private DateTimePicker dateTimePickerDateOfBirthday;
        private Button buttonSave;
        private Button buttonExit;
        private Label labelOwner;
        private ComboBox comboBoxOwner;
        private ComboBox comboBoxSex;
    }
}