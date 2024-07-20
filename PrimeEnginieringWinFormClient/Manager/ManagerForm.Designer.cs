namespace PrimeEnginieringWinFormClient
{
    partial class ManagerForm
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
            LogoutButton = new Button();
            DataGridViewEmployees = new DataGridView();
            RegisterButton = new Button();
            ((System.ComponentModel.ISupportInitialize)DataGridViewEmployees).BeginInit();
            SuspendLayout();
            // 
            // LogoutButton
            // 
            LogoutButton.Location = new Point(41, 30);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(75, 23);
            LogoutButton.TabIndex = 0;
            LogoutButton.Text = "Logout";
            LogoutButton.UseVisualStyleBackColor = true;
            LogoutButton.Click += Logout_Click;
            // 
            // DataGridViewEmployees
            // 
            DataGridViewEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewEmployees.Location = new Point(216, 38);
            DataGridViewEmployees.Name = "DataGridViewEmployees";
            DataGridViewEmployees.Size = new Size(348, 400);
            DataGridViewEmployees.TabIndex = 1;
            // 
            // RegisterButton
            // 
            RegisterButton.Location = new Point(626, 30);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(132, 23);
            RegisterButton.TabIndex = 2;
            RegisterButton.Text = "Register Employee";
            RegisterButton.UseVisualStyleBackColor = true;
            RegisterButton.Click += Register_Click;
            // 
            // ManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(RegisterButton);
            Controls.Add(DataGridViewEmployees);
            Controls.Add(LogoutButton);
            Name = "ManagerForm";
            Text = "ManagerForm";
            Load += ManagerForm_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridViewEmployees).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button LogoutButton;
        private DataGridView DataGridViewEmployees;
        private Button RegisterButton;
    }
}