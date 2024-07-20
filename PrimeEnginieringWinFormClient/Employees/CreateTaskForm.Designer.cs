namespace PrimeEnginieringWinFormClient.Employees
{
    partial class CreateTaskForm
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
            HeaderBox = new TextBox();
            DescriptionBox = new TextBox();
            PriorityBox = new ComboBox();
            DateBox = new DateTimePicker();
            CreateButton = new Button();
            BackButton = new Button();
            HeaderLabel = new Label();
            DescriptionLabel = new Label();
            PriorityLabel = new Label();
            DateLabel = new Label();
            SuspendLayout();
            // 
            // HeaderBox
            // 
            HeaderBox.Location = new Point(283, 69);
            HeaderBox.Name = "HeaderBox";
            HeaderBox.Size = new Size(221, 23);
            HeaderBox.TabIndex = 0;
            // 
            // DescriptionBox
            // 
            DescriptionBox.Location = new Point(283, 116);
            DescriptionBox.Multiline = true;
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.Size = new Size(222, 115);
            DescriptionBox.TabIndex = 1;
            // 
            // PriorityBox
            // 
            PriorityBox.DropDownStyle = ComboBoxStyle.DropDownList;
            PriorityBox.FormattingEnabled = true;
            PriorityBox.Location = new Point(283, 252);
            PriorityBox.Name = "PriorityBox";
            PriorityBox.Size = new Size(221, 23);
            PriorityBox.TabIndex = 2;
            // 
            // DateBox
            // 
            DateBox.Location = new Point(283, 295);
            DateBox.MinDate = new DateTime(2024, 7, 19, 17, 49, 46, 0);
            DateBox.Name = "DateBox";
            DateBox.Size = new Size(221, 23);
            DateBox.TabIndex = 3;
            DateBox.Value = new DateTime(2024, 7, 19, 17, 49, 46, 0);
            // 
            // CreateButton
            // 
            CreateButton.Location = new Point(358, 333);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(75, 23);
            CreateButton.TabIndex = 4;
            CreateButton.Text = "Create";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += Submit_Click;
            // 
            // BackButton
            // 
            BackButton.Location = new Point(73, 28);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(75, 23);
            BackButton.TabIndex = 5;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += Back_Click;
            // 
            // HeaderLabel
            // 
            HeaderLabel.AutoSize = true;
            HeaderLabel.Location = new Point(372, 51);
            HeaderLabel.Name = "HeaderLabel";
            HeaderLabel.Size = new Size(45, 15);
            HeaderLabel.TabIndex = 6;
            HeaderLabel.Text = "Header";
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(366, 98);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(67, 15);
            DescriptionLabel.TabIndex = 7;
            DescriptionLabel.Text = "Description";
            // 
            // PriorityLabel
            // 
            PriorityLabel.AutoSize = true;
            PriorityLabel.Location = new Point(366, 234);
            PriorityLabel.Name = "PriorityLabel";
            PriorityLabel.Size = new Size(45, 15);
            PriorityLabel.TabIndex = 8;
            PriorityLabel.Text = "Priority";
            // 
            // DateLabel
            // 
            DateLabel.AutoSize = true;
            DateLabel.Location = new Point(372, 278);
            DateLabel.Name = "DateLabel";
            DateLabel.Size = new Size(31, 15);
            DateLabel.TabIndex = 9;
            DateLabel.Text = "Date";
            // 
            // CreateTaskForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DateLabel);
            Controls.Add(PriorityLabel);
            Controls.Add(DescriptionLabel);
            Controls.Add(HeaderLabel);
            Controls.Add(BackButton);
            Controls.Add(CreateButton);
            Controls.Add(DateBox);
            Controls.Add(PriorityBox);
            Controls.Add(DescriptionBox);
            Controls.Add(HeaderBox);
            Name = "CreateTaskForm";
            Text = "CreateTask";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox HeaderBox;
        private TextBox DescriptionBox;
        private ComboBox PriorityBox;
        private DateTimePicker DateBox;
        private Button CreateButton;
        private Button BackButton;
        private Label HeaderLabel;
        private Label DescriptionLabel;
        private Label PriorityLabel;
        private Label DateLabel;
    }
}