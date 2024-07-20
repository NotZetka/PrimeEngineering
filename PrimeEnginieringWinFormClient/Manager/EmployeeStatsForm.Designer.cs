namespace PrimeEnginieringWinFormClient.Manager
{
    partial class ManagerEmployeeStatsForm
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
            BackButton = new Button();
            FinishedTasksLabel = new Label();
            UnfinishedTasksLabel = new Label();
            DataGridViewMonthlyStats = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DataGridViewMonthlyStats).BeginInit();
            SuspendLayout();
            // 
            // BackButton
            // 
            BackButton.Location = new Point(65, 25);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(75, 23);
            BackButton.TabIndex = 0;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += Back_Click;
            // 
            // FinishedTasksLabel
            // 
            FinishedTasksLabel.AutoSize = true;
            FinishedTasksLabel.Location = new Point(196, 29);
            FinishedTasksLabel.Name = "FinishedTasksLabel";
            FinishedTasksLabel.Size = new Size(83, 15);
            FinishedTasksLabel.TabIndex = 1;
            FinishedTasksLabel.Text = "Finished tasks:";
            // 
            // UnfinishedTasksLabel
            // 
            UnfinishedTasksLabel.AutoSize = true;
            UnfinishedTasksLabel.Location = new Point(422, 33);
            UnfinishedTasksLabel.Name = "UnfinishedTasksLabel";
            UnfinishedTasksLabel.Size = new Size(96, 15);
            UnfinishedTasksLabel.TabIndex = 2;
            UnfinishedTasksLabel.Text = "Unfinished tasks:";
            // 
            // DataGridViewMonthlyStats
            // 
            DataGridViewMonthlyStats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewMonthlyStats.Location = new Point(103, 82);
            DataGridViewMonthlyStats.Name = "DataGridViewMonthlyStats";
            DataGridViewMonthlyStats.Size = new Size(571, 325);
            DataGridViewMonthlyStats.TabIndex = 3;
            // 
            // ManagerEmployeeStatsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DataGridViewMonthlyStats);
            Controls.Add(UnfinishedTasksLabel);
            Controls.Add(FinishedTasksLabel);
            Controls.Add(BackButton);
            Name = "ManagerEmployeeStatsForm";
            Text = "EmployeeStatsForm";
            Load += ManagerEmployeeStatsForm_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridViewMonthlyStats).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BackButton;
        private Label FinishedTasksLabel;
        private Label UnfinishedTasksLabel;
        private DataGridView DataGridViewMonthlyStats;
    }
}