namespace ProjectRacing.Forms.Owners
{
    partial class FormOwner
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
            labelNameOfOwner = new Label();
            labelNumberOfOwner = new Label();
            textBoxNumberOfOwner = new TextBox();
            textBoxNameOfOwner = new TextBox();
            labelAdressOfOwner = new Label();
            textBoxAdressOfOwner = new TextBox();
            buttonExit = new Button();
            buttonSave = new Button();
            SuspendLayout();
            // 
            // labelNameOfOwner
            // 
            labelNameOfOwner.AutoSize = true;
            labelNameOfOwner.Location = new Point(12, 15);
            labelNameOfOwner.Name = "labelNameOfOwner";
            labelNameOfOwner.Size = new Size(31, 15);
            labelNameOfOwner.TabIndex = 0;
            labelNameOfOwner.Text = "Имя";
            // 
            // labelNumberOfOwner
            // 
            labelNumberOfOwner.AutoSize = true;
            labelNumberOfOwner.Location = new Point(12, 58);
            labelNumberOfOwner.Name = "labelNumberOfOwner";
            labelNumberOfOwner.Size = new Size(56, 15);
            labelNumberOfOwner.TabIndex = 1;
            labelNumberOfOwner.Text = "Телефон";
            // 
            // textBoxNumberOfOwner
            // 
            textBoxNumberOfOwner.Location = new Point(74, 55);
            textBoxNumberOfOwner.Name = "textBoxNumberOfOwner";
            textBoxNumberOfOwner.Size = new Size(100, 23);
            textBoxNumberOfOwner.TabIndex = 2;
            // 
            // textBoxNameOfOwner
            // 
            textBoxNameOfOwner.Location = new Point(74, 15);
            textBoxNameOfOwner.Name = "textBoxNameOfOwner";
            textBoxNameOfOwner.Size = new Size(100, 23);
            textBoxNameOfOwner.TabIndex = 3;
            // 
            // labelAdressOfOwner
            // 
            labelAdressOfOwner.AutoSize = true;
            labelAdressOfOwner.Location = new Point(12, 90);
            labelAdressOfOwner.Name = "labelAdressOfOwner";
            labelAdressOfOwner.Size = new Size(40, 15);
            labelAdressOfOwner.TabIndex = 4;
            labelAdressOfOwner.Text = "Адрес";
            // 
            // textBoxAdressOfOwner
            // 
            textBoxAdressOfOwner.Location = new Point(74, 90);
            textBoxAdressOfOwner.Name = "textBoxAdressOfOwner";
            textBoxAdressOfOwner.Size = new Size(100, 23);
            textBoxAdressOfOwner.TabIndex = 5;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(137, 134);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(75, 23);
            buttonExit.TabIndex = 7;
            buttonExit.Text = "Отмена";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(5, 134);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // FormOwner
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(215, 167);
            Controls.Add(buttonExit);
            Controls.Add(buttonSave);
            Controls.Add(textBoxAdressOfOwner);
            Controls.Add(labelAdressOfOwner);
            Controls.Add(textBoxNameOfOwner);
            Controls.Add(textBoxNumberOfOwner);
            Controls.Add(labelNumberOfOwner);
            Controls.Add(labelNameOfOwner);
            Name = "FormOwner";
            Text = "Владелец";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNameOfOwner;
        private Label labelNumberOfOwner;
        private TextBox textBoxNumberOfOwner;
        private TextBox textBoxNameOfOwner;
        private Label labelAdressOfOwner;
        private TextBox textBoxAdressOfOwner;
        private Button buttonExit;
        private Button buttonSave;
    }
}