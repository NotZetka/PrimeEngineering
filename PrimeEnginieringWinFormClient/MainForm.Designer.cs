namespace PrimeEnginieringWinFormClient
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
            LoginButton = new Button();
            LoginBox = new TextBox();
            PasswordBox = new TextBox();
            UsernameOrEmailLabel = new Label();
            PasswordLabel = new Label();
            SuspendLayout();
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(305, 247);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(183, 23);
            LoginButton.TabIndex = 0;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += button1_Click;
            // 
            // LoginBox
            // 
            LoginBox.Location = new Point(305, 155);
            LoginBox.Name = "LoginBox";
            LoginBox.Size = new Size(183, 23);
            LoginBox.TabIndex = 1;
            // 
            // PasswordBox
            // 
            PasswordBox.Location = new Point(305, 203);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.PasswordChar = '*';
            PasswordBox.Size = new Size(183, 23);
            PasswordBox.TabIndex = 2;
            // 
            // UsernameOrEmailLabel
            // 
            UsernameOrEmailLabel.AutoSize = true;
            UsernameOrEmailLabel.Location = new Point(342, 137);
            UsernameOrEmailLabel.Name = "UsernameOrEmailLabel";
            UsernameOrEmailLabel.Size = new Size(105, 15);
            UsernameOrEmailLabel.TabIndex = 3;
            UsernameOrEmailLabel.Text = "username or email";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(363, 185);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(57, 15);
            PasswordLabel.TabIndex = 4;
            PasswordLabel.Text = "Password";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 451);
            Controls.Add(PasswordLabel);
            Controls.Add(UsernameOrEmailLabel);
            Controls.Add(PasswordBox);
            Controls.Add(LoginBox);
            Controls.Add(LoginButton);
            Name = "MainForm";
            Text = "PrimeEnginiering";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoginButton;
        private TextBox LoginBox;
        private TextBox PasswordBox;
        private Label UsernameOrEmailLabel;
        private Label PasswordLabel;
    }
}
