namespace PrimeEnginieringWinFormClient.Employees
{
    partial class EditTaskForm
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
            DeadLineBox = new DateTimePicker();
            SaveButton = new Button();
            HeaderLabel = new Label();
            DescriptionLabel = new Label();
            PriorityLabel = new Label();
            MarkFinishedButton = new Button();
            SuspendLayout();
            // 
            // HeaderBox
            // 
            HeaderBox.Location = new Point(293, 71);
            HeaderBox.Name = "HeaderBox";
            HeaderBox.Size = new Size(219, 23);
            HeaderBox.TabIndex = 0;
            // 
            // DescriptionBox
            // 
            DescriptionBox.Location = new Point(293, 116);
            DescriptionBox.Multiline = true;
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.Size = new Size(219, 135);
            DescriptionBox.TabIndex = 1;
            // 
            // PriorityBox
            // 
            PriorityBox.DropDownStyle = ComboBoxStyle.DropDownList;
            PriorityBox.FormattingEnabled = true;
            PriorityBox.Location = new Point(294, 274);
            PriorityBox.Name = "PriorityBox";
            PriorityBox.Size = new Size(218, 23);
            PriorityBox.TabIndex = 2;
            // 
            // DeadLineBox
            // 
            DeadLineBox.Location = new Point(293, 303);
            DeadLineBox.Name = "DeadLineBox";
            DeadLineBox.Size = new Size(218, 23);
            DeadLineBox.TabIndex = 3;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(350, 332);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(115, 23);
            SaveButton.TabIndex = 4;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += Save_Click;
            // 
            // HeaderLabel
            // 
            HeaderLabel.AutoSize = true;
            HeaderLabel.Location = new Point(382, 53);
            HeaderLabel.Name = "HeaderLabel";
            HeaderLabel.Size = new Size(45, 15);
            HeaderLabel.TabIndex = 5;
            HeaderLabel.Text = "Header";
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(370, 97);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(67, 15);
            DescriptionLabel.TabIndex = 6;
            DescriptionLabel.Text = "Description";
            // 
            // PriorityLabel
            // 
            PriorityLabel.AutoSize = true;
            PriorityLabel.Location = new Point(382, 256);
            PriorityLabel.Name = "PriorityLabel";
            PriorityLabel.Size = new Size(45, 15);
            PriorityLabel.TabIndex = 7;
            PriorityLabel.Text = "Priority";
            // 
            // MarkFinishedButton
            // 
            MarkFinishedButton.Location = new Point(350, 361);
            MarkFinishedButton.Name = "MarkFinishedButton";
            MarkFinishedButton.Size = new Size(115, 23);
            MarkFinishedButton.TabIndex = 8;
            MarkFinishedButton.Text = "Mark Finished";
            MarkFinishedButton.UseVisualStyleBackColor = true;
            MarkFinishedButton.Click += MarkFinishedButton_Click;
            // 
            // EditTaskForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MarkFinishedButton);
            Controls.Add(PriorityLabel);
            Controls.Add(DescriptionLabel);
            Controls.Add(HeaderLabel);
            Controls.Add(SaveButton);
            Controls.Add(DeadLineBox);
            Controls.Add(PriorityBox);
            Controls.Add(DescriptionBox);
            Controls.Add(HeaderBox);
            Name = "EditTaskForm";
            Text = "EditTaskForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox HeaderBox;
        private TextBox DescriptionBox;
        private ComboBox PriorityBox;
        private DateTimePicker DeadLineBox;
        private Button SaveButton;
        private Label HeaderLabel;
        private Label DescriptionLabel;
        private Label PriorityLabel;
        private Button MarkFinishedButton;
    }
}