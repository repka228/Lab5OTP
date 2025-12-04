namespace ProjectRacing.Forms.MedicalExamination
{
    partial class FormMedicalExaminations
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
            panel1 = new Panel();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            buttonAdd = new Button();
            dataGridViewHorses = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHorses).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonUpdate);
            panel1.Controls.Add(buttonDelete);
            panel1.Controls.Add(buttonAdd);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(684, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(116, 450);
            panel1.TabIndex = 8;
            // 
            // buttonUpdate
            // 
            buttonUpdate.BackgroundImage = Properties.Resources.icons8_update_64;
            buttonUpdate.BackgroundImageLayout = ImageLayout.Stretch;
            buttonUpdate.Location = new Point(16, 146);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(75, 61);
            buttonUpdate.TabIndex = 2;
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += ButtonUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.BackgroundImage = Properties.Resources.icons8_delete_480;
            buttonDelete.BackgroundImageLayout = ImageLayout.Stretch;
            buttonDelete.Location = new Point(16, 79);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 61);
            buttonDelete.TabIndex = 1;
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += ButtonDelete_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.BackgroundImage = Properties.Resources.icons8_add_100;
            buttonAdd.BackgroundImageLayout = ImageLayout.Stretch;
            buttonAdd.Location = new Point(16, 12);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 61);
            buttonAdd.TabIndex = 0;
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += ButtonAdd_Click;
            // 
            // dataGridViewHorses
            // 
            dataGridViewHorses.AllowUserToAddRows = false;
            dataGridViewHorses.AllowUserToDeleteRows = false;
            dataGridViewHorses.AllowUserToResizeColumns = false;
            dataGridViewHorses.AllowUserToResizeRows = false;
            dataGridViewHorses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewHorses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHorses.Dock = DockStyle.Fill;
            dataGridViewHorses.Location = new Point(0, 0);
            dataGridViewHorses.MultiSelect = false;
            dataGridViewHorses.Name = "dataGridViewHorses";
            dataGridViewHorses.ReadOnly = true;
            dataGridViewHorses.RowHeadersVisible = false;
            dataGridViewHorses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewHorses.Size = new Size(800, 450);
            dataGridViewHorses.TabIndex = 9;
            // 
            // FormMedicalExaminations
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(dataGridViewHorses);
            Name = "FormMedicalExaminations";
            Text = "Медицинские обследования";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewHorses).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonAdd;
        private DataGridView dataGridViewHorses;
    }
}