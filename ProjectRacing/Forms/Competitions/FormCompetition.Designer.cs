namespace ProjectRacing.Forms
{
    partial class FormCompetition
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
            dateTimePickerDateOfCompetition = new DateTimePicker();
            textBoxNameOfCompetition = new TextBox();
            labelDateOfCompetition = new Label();
            labelNameOfCompetitions = new Label();
            buttonSave = new Button();
            buttonExit = new Button();
            textBoxAdressOfCompetition = new TextBox();
            labelAdressOfCompetition = new Label();
            label1 = new Label();
            numericUpDownPlace = new NumericUpDown();
            comboBoxHorses = new ComboBox();
            comboBoxJockeys = new ComboBox();
            labelHorses = new Label();
            labelJockeys = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPlace).BeginInit();
            SuspendLayout();
            // 
            // dateTimePickerDateOfCompetition
            // 
            dateTimePickerDateOfCompetition.Location = new Point(159, 108);
            dateTimePickerDateOfCompetition.Name = "dateTimePickerDateOfCompetition";
            dateTimePickerDateOfCompetition.Size = new Size(173, 23);
            dateTimePickerDateOfCompetition.TabIndex = 0;
            // 
            // textBoxNameOfCompetition
            // 
            textBoxNameOfCompetition.Location = new Point(159, 143);
            textBoxNameOfCompetition.Name = "textBoxNameOfCompetition";
            textBoxNameOfCompetition.Size = new Size(173, 23);
            textBoxNameOfCompetition.TabIndex = 1;
            // 
            // labelDateOfCompetition
            // 
            labelDateOfCompetition.AutoSize = true;
            labelDateOfCompetition.Location = new Point(12, 108);
            labelDateOfCompetition.Name = "labelDateOfCompetition";
            labelDateOfCompetition.Size = new Size(114, 15);
            labelDateOfCompetition.TabIndex = 2;
            labelDateOfCompetition.Text = "Дата соревнований";
            // 
            // labelNameOfCompetitions
            // 
            labelNameOfCompetitions.AutoSize = true;
            labelNameOfCompetitions.Location = new Point(12, 143);
            labelNameOfCompetitions.Name = "labelNameOfCompetitions";
            labelNameOfCompetitions.Size = new Size(141, 15);
            labelNameOfCompetitions.TabIndex = 3;
            labelNameOfCompetitions.Text = "Название соревнований";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(51, 212);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(179, 212);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(75, 23);
            buttonExit.TabIndex = 5;
            buttonExit.Text = "Отмена";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // textBoxAdressOfCompetition
            // 
            textBoxAdressOfCompetition.Location = new Point(159, 180);
            textBoxAdressOfCompetition.Name = "textBoxAdressOfCompetition";
            textBoxAdressOfCompetition.Size = new Size(173, 23);
            textBoxAdressOfCompetition.TabIndex = 6;
            // 
            // labelAdressOfCompetition
            // 
            labelAdressOfCompetition.AutoSize = true;
            labelAdressOfCompetition.Location = new Point(12, 183);
            labelAdressOfCompetition.Name = "labelAdressOfCompetition";
            labelAdressOfCompetition.Size = new Size(124, 15);
            labelAdressOfCompetition.TabIndex = 7;
            labelAdressOfCompetition.Text = "Место соревнований";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 72);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 24;
            label1.Text = "Место";
            // 
            // numericUpDownPlace
            // 
            numericUpDownPlace.Location = new Point(159, 70);
            numericUpDownPlace.Name = "numericUpDownPlace";
            numericUpDownPlace.Size = new Size(173, 23);
            numericUpDownPlace.TabIndex = 23;
            numericUpDownPlace.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // comboBoxHorses
            // 
            comboBoxHorses.FormattingEnabled = true;
            comboBoxHorses.Location = new Point(159, 41);
            comboBoxHorses.Name = "comboBoxHorses";
            comboBoxHorses.Size = new Size(173, 23);
            comboBoxHorses.TabIndex = 22;
            // 
            // comboBoxJockeys
            // 
            comboBoxJockeys.FormattingEnabled = true;
            comboBoxJockeys.Location = new Point(159, 12);
            comboBoxJockeys.Name = "comboBoxJockeys";
            comboBoxJockeys.Size = new Size(173, 23);
            comboBoxJockeys.TabIndex = 21;
            // 
            // labelHorses
            // 
            labelHorses.AutoSize = true;
            labelHorses.Location = new Point(12, 44);
            labelHorses.Name = "labelHorses";
            labelHorses.Size = new Size(51, 15);
            labelHorses.TabIndex = 18;
            labelHorses.Text = "Лошадь";
            // 
            // labelJockeys
            // 
            labelJockeys.AutoSize = true;
            labelJockeys.Location = new Point(12, 9);
            labelJockeys.Name = "labelJockeys";
            labelJockeys.Size = new Size(44, 15);
            labelJockeys.TabIndex = 17;
            labelJockeys.Text = "Жокей";
            // 
            // FormCompetition
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 269);
            Controls.Add(label1);
            Controls.Add(numericUpDownPlace);
            Controls.Add(comboBoxHorses);
            Controls.Add(comboBoxJockeys);
            Controls.Add(labelHorses);
            Controls.Add(labelJockeys);
            Controls.Add(labelAdressOfCompetition);
            Controls.Add(textBoxAdressOfCompetition);
            Controls.Add(buttonExit);
            Controls.Add(buttonSave);
            Controls.Add(labelNameOfCompetitions);
            Controls.Add(labelDateOfCompetition);
            Controls.Add(textBoxNameOfCompetition);
            Controls.Add(dateTimePickerDateOfCompetition);
            Name = "FormCompetition";
            Text = "Соревнование";
            ((System.ComponentModel.ISupportInitialize)numericUpDownPlace).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePickerDateOfCompetition;
        private TextBox textBoxNameOfCompetition;
        private Label labelDateOfCompetition;
        private Label labelNameOfCompetitions;
        private Button buttonSave;
        private Button buttonExit;
        private TextBox textBoxAdressOfCompetition;
        private Label labelAdressOfCompetition;
        private Label label1;
        private NumericUpDown numericUpDownPlace;
        private ComboBox comboBoxHorses;
        private ComboBox comboBoxJockeys;
        private Label labelHorses;
        private Label labelJockeys;
    }
}