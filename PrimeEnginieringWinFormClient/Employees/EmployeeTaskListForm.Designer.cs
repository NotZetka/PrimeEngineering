namespace PrimeEnginieringWinFormClient.Employees
{
    partial class EmployeeTaskListForm
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
            DataGridViewTasks = new DataGridView();
            BackButton = new Button();
            ((System.ComponentModel.ISupportInitialize)DataGridViewTasks).BeginInit();
            SuspendLayout();
            // 
            // DataGridViewTasks
            // 
            DataGridViewTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewTasks.Location = new Point(1, 31);
            DataGridViewTasks.Name = "DataGridViewTasks";
            DataGridViewTasks.Size = new Size(799, 415);
            DataGridViewTasks.TabIndex = 0;
            // 
            // BackButton
            // 
            BackButton.Location = new Point(12, 2);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(75, 23);
            BackButton.TabIndex = 1;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += Back_Click;
            // 
            // EmployeeTaskListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BackButton);
            Controls.Add(DataGridViewTasks);
            Name = "EmployeeTaskListForm";
            Text = "EmployeeTaskListForm";
            Load += EmployeeTaskListForm_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridViewTasks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DataGridViewTasks;
        private Button BackButton;
    }
}