namespace WinFormsAppRonny
{
    partial class MainForm
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
            dataGridViewTask = new DataGridView();
            textBox1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTask).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTask
            // 
            dataGridViewTask.BackgroundColor = SystemColors.InactiveCaption;
            dataGridViewTask.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTask.Location = new Point(103, 40);
            dataGridViewTask.Name = "dataGridViewTask";
            dataGridViewTask.Size = new Size(651, 326);
            dataGridViewTask.TabIndex = 0;
            dataGridViewTask.CellClick += dataGridViewTask_CellClick_1;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ControlDarkDark;
            textBox1.Location = new Point(608, 403);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(93, 23);
            textBox1.TabIndex = 1;
            textBox1.Text = "Create_New";
            textBox1.UseVisualStyleBackColor = false;
            textBox1.Click += button1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(844, 450);
            Controls.Add(textBox1);
            Controls.Add(dataGridViewTask);
            MaximizeBox = false;
            Name = "MainForm";
            Padding = new Padding(2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Task Demo";
            Activated += MainForm_Activated;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTask).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewTask;
        private Button textBox1;
    }
}
