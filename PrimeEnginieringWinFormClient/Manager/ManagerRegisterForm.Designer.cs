namespace PrimeEnginieringWinFormClient.Manager
{
    partial class ManagerRegisterForm
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
            UsernabeLabel = new Label();
            EmailLabel = new Label();
            PasswordLabel = new Label();
            ConfirmPasswordLabel = new Label();
            UsernameBox = new TextBox();
            EmailBox = new TextBox();
            PasswordBox = new TextBox();
            ConfirmPasswordBox = new TextBox();
            BackButton = new Button();
            CreateButton = new Button();
            SuspendLayout();
            // 
            // UsernabeLabel
            // 
            UsernabeLabel.AutoSize = true;
            UsernabeLabel.Location = new Point(359, 85);
            UsernabeLabel.Name = "UsernabeLabel";
            UsernabeLabel.Size = new Size(60, 15);
            UsernabeLabel.TabIndex = 0;
            UsernabeLabel.Text = "Username";
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(369, 129);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(41, 15);
            EmailLabel.TabIndex = 1;
            EmailLabel.Text = "E-mail";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(359, 173);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(57, 15);
            PasswordLabel.TabIndex = 2;
            PasswordLabel.Text = "Password";
            // 
            // ConfirmPasswordLabel
            // 
            ConfirmPasswordLabel.AutoSize = true;
            ConfirmPasswordLabel.Location = new Point(340, 217);
            ConfirmPasswordLabel.Name = "ConfirmPasswordLabel";
            ConfirmPasswordLabel.Size = new Size(104, 15);
            ConfirmPasswordLabel.TabIndex = 3;
            ConfirmPasswordLabel.Text = "Confirm password";
            // 
            // UsernameBox
            // 
            UsernameBox.Location = new Point(316, 103);
            UsernameBox.Name = "UsernameBox";
            UsernameBox.Size = new Size(161, 23);
            UsernameBox.TabIndex = 4;
            // 
            // EmailBox
            // 
            EmailBox.Location = new Point(316, 147);
            EmailBox.Name = "EmailBox";
            EmailBox.Size = new Size(161, 23);
            EmailBox.TabIndex = 5;
            // 
            // PasswordBox
            // 
            PasswordBox.Location = new Point(316, 191);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.PasswordChar = '*';
            PasswordBox.Size = new Size(161, 23);
            PasswordBox.TabIndex = 6;
            // 
            // ConfirmPasswordBox
            // 
            ConfirmPasswordBox.Location = new Point(316, 235);
            ConfirmPasswordBox.Name = "ConfirmPasswordBox";
            ConfirmPasswordBox.PasswordChar = '*';
            ConfirmPasswordBox.Size = new Size(161, 23);
            ConfirmPasswordBox.TabIndex = 7;
            // 
            // BackButton
            // 
            BackButton.Location = new Point(74, 34);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(75, 23);
            BackButton.TabIndex = 8;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += Back_Click;
            // 
            // CreateButton
            // 
            CreateButton.Location = new Point(356, 264);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(75, 23);
            CreateButton.TabIndex = 9;
            CreateButton.Text = "Create";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += CreateButton_Click;
            // 
            // ManagerRegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CreateButton);
            Controls.Add(BackButton);
            Controls.Add(ConfirmPasswordBox);
            Controls.Add(PasswordBox);
            Controls.Add(EmailBox);
            Controls.Add(UsernameBox);
            Controls.Add(ConfirmPasswordLabel);
            Controls.Add(PasswordLabel);
            Controls.Add(EmailLabel);
            Controls.Add(UsernabeLabel);
            Name = "ManagerRegisterForm";
            Text = "ManagerRegister";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UsernabeLabel;
        private Label EmailLabel;
        private Label PasswordLabel;
        private Label ConfirmPasswordLabel;
        private TextBox UsernameBox;
        private TextBox EmailBox;
        private TextBox PasswordBox;
        private TextBox ConfirmPasswordBox;
        private Button BackButton;
        private Button CreateButton;
    }
}