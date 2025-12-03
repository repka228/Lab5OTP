namespace ProjectRacing.Forms
{
    partial class FormJockey
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
            textBoxNameOfJockey = new TextBox();
            numericUpDownAgeOfJockey = new NumericUpDown();
            numericUpDownRateOfJockey = new NumericUpDown();
            textBoxAdressOfJockey = new TextBox();
            textBoxNumberOfJockey = new TextBox();
            labelNameOfJockey = new Label();
            labelAdressOfJockey = new Label();
            labelNumberOfJockey = new Label();
            labelAgeOfJockey = new Label();
            labelRateOfJockey = new Label();
            buttonExit = new Button();
            buttonSave = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAgeOfJockey).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRateOfJockey).BeginInit();
            SuspendLayout();
            // 
            // textBoxNameOfJockey
            // 
            textBoxNameOfJockey.Location = new Point(67, 9);
            textBoxNameOfJockey.Name = "textBoxNameOfJockey";
            textBoxNameOfJockey.Size = new Size(100, 23);
            textBoxNameOfJockey.TabIndex = 0;
            // 
            // numericUpDownAgeOfJockey
            // 
            numericUpDownAgeOfJockey.Location = new Point(67, 94);
            numericUpDownAgeOfJockey.Minimum = new decimal(new int[] { 18, 0, 0, 0 });
            numericUpDownAgeOfJockey.Name = "numericUpDownAgeOfJockey";
            numericUpDownAgeOfJockey.Size = new Size(120, 23);
            numericUpDownAgeOfJockey.TabIndex = 1;
            numericUpDownAgeOfJockey.Value = new decimal(new int[] { 18, 0, 0, 0 });
            // 
            // numericUpDownRateOfJockey
            // 
            numericUpDownRateOfJockey.DecimalPlaces = 1;
            numericUpDownRateOfJockey.Location = new Point(67, 123);
            numericUpDownRateOfJockey.Name = "numericUpDownRateOfJockey";
            numericUpDownRateOfJockey.Size = new Size(120, 23);
            numericUpDownRateOfJockey.TabIndex = 2;
            // 
            // textBoxAdressOfJockey
            // 
            textBoxAdressOfJockey.Location = new Point(67, 36);
            textBoxAdressOfJockey.Name = "textBoxAdressOfJockey";
            textBoxAdressOfJockey.Size = new Size(100, 23);
            textBoxAdressOfJockey.TabIndex = 3;
            // 
            // textBoxNumberOfJockey
            // 
            textBoxNumberOfJockey.Location = new Point(67, 65);
            textBoxNumberOfJockey.Name = "textBoxNumberOfJockey";
            textBoxNumberOfJockey.Size = new Size(100, 23);
            textBoxNumberOfJockey.TabIndex = 4;
            // 
            // labelNameOfJockey
            // 
            labelNameOfJockey.AutoSize = true;
            labelNameOfJockey.Location = new Point(12, 9);
            labelNameOfJockey.Name = "labelNameOfJockey";
            labelNameOfJockey.Size = new Size(31, 15);
            labelNameOfJockey.TabIndex = 5;
            labelNameOfJockey.Text = "Имя";
            // 
            // labelAdressOfJockey
            // 
            labelAdressOfJockey.AutoSize = true;
            labelAdressOfJockey.Location = new Point(12, 39);
            labelAdressOfJockey.Name = "labelAdressOfJockey";
            labelAdressOfJockey.Size = new Size(40, 15);
            labelAdressOfJockey.TabIndex = 6;
            labelAdressOfJockey.Text = "Адрес";
            // 
            // labelNumberOfJockey
            // 
            labelNumberOfJockey.AutoSize = true;
            labelNumberOfJockey.Location = new Point(12, 68);
            labelNumberOfJockey.Name = "labelNumberOfJockey";
            labelNumberOfJockey.Size = new Size(56, 15);
            labelNumberOfJockey.TabIndex = 7;
            labelNumberOfJockey.Text = "Телефон";
            // 
            // labelAgeOfJockey
            // 
            labelAgeOfJockey.AutoSize = true;
            labelAgeOfJockey.Location = new Point(12, 96);
            labelAgeOfJockey.Name = "labelAgeOfJockey";
            labelAgeOfJockey.Size = new Size(50, 15);
            labelAgeOfJockey.TabIndex = 8;
            labelAgeOfJockey.Text = "Возраст";
            // 
            // labelRateOfJockey
            // 
            labelRateOfJockey.AutoSize = true;
            labelRateOfJockey.Location = new Point(12, 125);
            labelRateOfJockey.Name = "labelRateOfJockey";
            labelRateOfJockey.Size = new Size(51, 15);
            labelRateOfJockey.TabIndex = 9;
            labelRateOfJockey.Text = "Рейтинг";
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(144, 167);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(75, 23);
            buttonExit.TabIndex = 11;
            buttonExit.Text = "Отмена";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(12, 167);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 10;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // FormJockey
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(239, 217);
            Controls.Add(buttonExit);
            Controls.Add(buttonSave);
            Controls.Add(labelRateOfJockey);
            Controls.Add(labelAgeOfJockey);
            Controls.Add(labelNumberOfJockey);
            Controls.Add(labelAdressOfJockey);
            Controls.Add(labelNameOfJockey);
            Controls.Add(textBoxNumberOfJockey);
            Controls.Add(textBoxAdressOfJockey);
            Controls.Add(numericUpDownRateOfJockey);
            Controls.Add(numericUpDownAgeOfJockey);
            Controls.Add(textBoxNameOfJockey);
            Name = "FormJockey";
            Text = "Жокей";
            ((System.ComponentModel.ISupportInitialize)numericUpDownAgeOfJockey).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRateOfJockey).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxNameOfJockey;
        private NumericUpDown numericUpDownAgeOfJockey;
        private NumericUpDown numericUpDownRateOfJockey;
        private TextBox textBoxAdressOfJockey;
        private TextBox textBoxNumberOfJockey;
        private Label labelNameOfJockey;
        private Label labelAdressOfJockey;
        private Label labelNumberOfJockey;
        private Label labelAgeOfJockey;
        private Label labelRateOfJockey;
        private Button buttonExit;
        private Button buttonSave;
    }
}