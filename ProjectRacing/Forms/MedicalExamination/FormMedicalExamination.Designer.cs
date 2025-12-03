namespace ProjectRacing.Forms.MedicalExamination
{
    partial class FormMedicalExamination
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
            labelHorse = new Label();
            labelResult = new Label();
            labelDate = new Label();
            comboBoxHorses = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            dateTimePickerMedicalExamination = new DateTimePicker();
            comboBoxResult = new ComboBox();
            SuspendLayout();
            // 
            // labelHorse
            // 
            labelHorse.AutoSize = true;
            labelHorse.Location = new Point(12, 12);
            labelHorse.Name = "labelHorse";
            labelHorse.Size = new Size(51, 15);
            labelHorse.TabIndex = 0;
            labelHorse.Text = "Лошадь";
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(12, 88);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(60, 15);
            labelResult.TabIndex = 1;
            labelResult.Text = "Результат";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(12, 53);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(32, 15);
            labelDate.TabIndex = 2;
            labelDate.Text = "Дата";
            // 
            // comboBoxHorses
            // 
            comboBoxHorses.FormattingEnabled = true;
            comboBoxHorses.Location = new Point(78, 12);
            comboBoxHorses.Name = "comboBoxHorses";
            comboBoxHorses.Size = new Size(121, 23);
            comboBoxHorses.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(12, 120);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ButtonSave_Click;
            // 
            // button2
            // 
            button2.Location = new Point(124, 120);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "Отмена";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ButtonExit_Click;
            // 
            // dateTimePickerMedicalExamination
            // 
            dateTimePickerMedicalExamination.Location = new Point(78, 53);
            dateTimePickerMedicalExamination.Name = "dateTimePickerMedicalExamination";
            dateTimePickerMedicalExamination.Size = new Size(200, 23);
            dateTimePickerMedicalExamination.TabIndex = 6;
            // 
            // comboBoxResult
            // 
            comboBoxResult.FormattingEnabled = true;
            comboBoxResult.Location = new Point(78, 85);
            comboBoxResult.Name = "comboBoxResult";
            comboBoxResult.Size = new Size(121, 23);
            comboBoxResult.TabIndex = 7;
            // 
            // FormMedicalExamination
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(339, 220);
            Controls.Add(comboBoxResult);
            Controls.Add(dateTimePickerMedicalExamination);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBoxHorses);
            Controls.Add(labelDate);
            Controls.Add(labelResult);
            Controls.Add(labelHorse);
            Name = "FormMedicalExamination";
            Text = "Медицинское обследование";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelHorse;
        private Label labelResult;
        private Label labelDate;
        private ComboBox comboBoxHorses;
        private Button button1;
        private Button button2;
        private DateTimePicker dateTimePickerMedicalExamination;
        private ComboBox comboBoxResult;
    }
}