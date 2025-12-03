namespace ProjectRacing
{
    partial class FormRacing
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
            menuStrip = new MenuStrip();
            infoToolStripMenuItem = new ToolStripMenuItem();
            ownersToolStripMenuItem = new ToolStripMenuItem();
            horsesToolStripMenuItem = new ToolStripMenuItem();
            jockeysToolStripMenuItem = new ToolStripMenuItem();
            operationToolStripMenuItem = new ToolStripMenuItem();
            registrationCompetitionToolStripMenuItem = new ToolStripMenuItem();
            completeMedicalExaminationToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { infoToolStripMenuItem, operationToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(239, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // infoToolStripMenuItem
            // 
            infoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ownersToolStripMenuItem, horsesToolStripMenuItem, jockeysToolStripMenuItem });
            infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            infoToolStripMenuItem.Size = new Size(94, 20);
            infoToolStripMenuItem.Text = "Справочники";
            // 
            // ownersToolStripMenuItem
            // 
            ownersToolStripMenuItem.Name = "ownersToolStripMenuItem";
            ownersToolStripMenuItem.Size = new Size(180, 22);
            ownersToolStripMenuItem.Text = "Владельцы";
            ownersToolStripMenuItem.Click += OwnersToolStripMenuItem_Click;
            // 
            // horsesToolStripMenuItem
            // 
            horsesToolStripMenuItem.Name = "horsesToolStripMenuItem";
            horsesToolStripMenuItem.Size = new Size(180, 22);
            horsesToolStripMenuItem.Text = "Лошади";
            horsesToolStripMenuItem.Click += HorsesToolStripMenuItem_Click;
            // 
            // jockeysToolStripMenuItem
            // 
            jockeysToolStripMenuItem.Name = "jockeysToolStripMenuItem";
            jockeysToolStripMenuItem.Size = new Size(180, 22);
            jockeysToolStripMenuItem.Text = "Жокеи";
            jockeysToolStripMenuItem.Click += JockeysToolStripMenuItem_Click;
            // 
            // operationToolStripMenuItem
            // 
            operationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registrationCompetitionToolStripMenuItem, completeMedicalExaminationToolStripMenuItem });
            operationToolStripMenuItem.Name = "operationToolStripMenuItem";
            operationToolStripMenuItem.Size = new Size(75, 20);
            operationToolStripMenuItem.Text = "Операции";
            // 
            // registrationCompetitionToolStripMenuItem
            // 
            registrationCompetitionToolStripMenuItem.Name = "registrationCompetitionToolStripMenuItem";
            registrationCompetitionToolStripMenuItem.Size = new Size(225, 22);
            registrationCompetitionToolStripMenuItem.Text = "Регистрация соревнований";
            registrationCompetitionToolStripMenuItem.Click += RegistrationCompetitionToolStripMenuItem_Click;
            // 
            // completeMedicalExaminationToolStripMenuItem
            // 
            completeMedicalExaminationToolStripMenuItem.Name = "completeMedicalExaminationToolStripMenuItem";
            completeMedicalExaminationToolStripMenuItem.Size = new Size(225, 22);
            completeMedicalExaminationToolStripMenuItem.Text = "Провести медосмотр";
            completeMedicalExaminationToolStripMenuItem.Click += CompleteMedicalExaminationToolStripMenuItem_Click;
            // 
            // FormRacing
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(239, 44);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "FormRacing";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Скачки";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem infoToolStripMenuItem;
        private ToolStripMenuItem horsesToolStripMenuItem;
        private ToolStripMenuItem ownersToolStripMenuItem;
        private ToolStripMenuItem jockeysToolStripMenuItem;
        private ToolStripMenuItem operationToolStripMenuItem;
        private ToolStripMenuItem registrationCompetitionToolStripMenuItem;
        private ToolStripMenuItem completeMedicalExaminationToolStripMenuItem;
    }
}
