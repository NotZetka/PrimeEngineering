namespace PrimeEnginieringWinFormClient
{
    partial class EmployeeForm
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
            CreateTaskButton = new Button();
            GetTasksListButton = new Button();
            LogoutButton = new Button();
            SuspendLayout();
            // 
            // CreateTaskButton
            // 
            CreateTaskButton.Location = new Point(303, 177);
            CreateTaskButton.Name = "CreateTaskButton";
            CreateTaskButton.Size = new Size(137, 23);
            CreateTaskButton.TabIndex = 0;
            CreateTaskButton.Text = "Create Task";
            CreateTaskButton.UseVisualStyleBackColor = true;
            CreateTaskButton.Click += CreateTask_Click;
            // 
            // GetTasksListButton
            // 
            GetTasksListButton.Location = new Point(303, 225);
            GetTasksListButton.Name = "GetTasksListButton";
            GetTasksListButton.Size = new Size(137, 23);
            GetTasksListButton.TabIndex = 1;
            GetTasksListButton.Text = "Get list of tasks";
            GetTasksListButton.UseVisualStyleBackColor = true;
            GetTasksListButton.Click += GetTasksList_Click;
            // 
            // LogoutButton
            // 
            LogoutButton.Location = new Point(79, 41);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(75, 23);
            LogoutButton.TabIndex = 2;
            LogoutButton.Text = "Logout";
            LogoutButton.UseVisualStyleBackColor = true;
            LogoutButton.Click += logoutButton_Click;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LogoutButton);
            Controls.Add(GetTasksListButton);
            Controls.Add(CreateTaskButton);
            Name = "EmployeeForm";
            Text = "EmployeeForm";
            ResumeLayout(false);
        }

        #endregion

        private Button CreateTaskButton;
        private Button GetTasksListButton;
        private Button LogoutButton;
    }
}