namespace PrimeEnginieringWinFormClient.Employees
{
    partial class AddContributorForm
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
            DataGridViewEmployees = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DataGridViewEmployees).BeginInit();
            SuspendLayout();
            // 
            // BackButton
            // 
            BackButton.Location = new Point(50, 26);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(75, 23);
            BackButton.TabIndex = 0;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += Back_Click;
            // 
            // DataGridViewEmployees
            // 
            DataGridViewEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewEmployees.Location = new Point(260, 38);
            DataGridViewEmployees.Name = "DataGridViewEmployees";
            DataGridViewEmployees.Size = new Size(295, 382);
            DataGridViewEmployees.TabIndex = 1;
            // 
            // AddContributorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DataGridViewEmployees);
            Controls.Add(BackButton);
            Name = "AddContributorForm";
            Text = "AddContributorForm";
            Load += AddContributorForm_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridViewEmployees).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button BackButton;
        private DataGridView DataGridViewEmployees;
    }
}