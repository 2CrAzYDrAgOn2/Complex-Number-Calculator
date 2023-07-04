namespace WinFormsApp2
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox realTextBox;
        private TextBox imaginaryTextBox;
        private Button calculateButton;
        private Label modulusLabel;
        private Label argumentLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            realTextBox = new TextBox();
            imaginaryTextBox = new TextBox();
            calculateButton = new Button();
            modulusLabel = new Label();
            argumentLabel = new Label();
            clearButton = new Button();
            wordButton = new Button();
            excelButton = new Button();
            exitButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // realTextBox
            // 
            realTextBox.Location = new Point(12, 12);
            realTextBox.MaxLength = 15;
            realTextBox.Name = "realTextBox";
            realTextBox.Size = new Size(100, 23);
            realTextBox.TabIndex = 0;
            realTextBox.KeyPress += realTextBox_KeyPress;
            // 
            // imaginaryTextBox
            // 
            imaginaryTextBox.Location = new Point(118, 12);
            imaginaryTextBox.MaxLength = 15;
            imaginaryTextBox.Name = "imaginaryTextBox";
            imaginaryTextBox.Size = new Size(100, 23);
            imaginaryTextBox.TabIndex = 1;
            imaginaryTextBox.KeyPress += imaginaryTextBox_KeyPress;
            // 
            // calculateButton
            // 
            calculateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            calculateButton.FlatStyle = FlatStyle.Flat;
            calculateButton.Location = new Point(12, 121);
            calculateButton.Name = "calculateButton";
            calculateButton.Size = new Size(206, 23);
            calculateButton.TabIndex = 2;
            calculateButton.Text = "Вычислить";
            calculateButton.UseVisualStyleBackColor = true;
            calculateButton.Click += calculateButton_Click;
            // 
            // modulusLabel
            // 
            modulusLabel.AutoSize = true;
            modulusLabel.Location = new Point(12, 76);
            modulusLabel.Name = "modulusLabel";
            modulusLabel.Size = new Size(0, 15);
            modulusLabel.TabIndex = 3;
            // 
            // argumentLabel
            // 
            argumentLabel.AutoSize = true;
            argumentLabel.Location = new Point(12, 99);
            argumentLabel.Name = "argumentLabel";
            argumentLabel.Size = new Size(0, 15);
            argumentLabel.TabIndex = 4;
            // 
            // clearButton
            // 
            clearButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.Location = new Point(12, 150);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(206, 23);
            clearButton.TabIndex = 5;
            clearButton.Text = "Очистить";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // wordButton
            // 
            wordButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            wordButton.FlatStyle = FlatStyle.Flat;
            wordButton.Location = new Point(12, 179);
            wordButton.Name = "wordButton";
            wordButton.Size = new Size(206, 23);
            wordButton.TabIndex = 6;
            wordButton.Text = "Показать в Word";
            wordButton.UseVisualStyleBackColor = true;
            wordButton.Click += wordButton_Click;
            // 
            // excelButton
            // 
            excelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            excelButton.FlatStyle = FlatStyle.Flat;
            excelButton.Location = new Point(12, 208);
            excelButton.Name = "excelButton";
            excelButton.Size = new Size(206, 23);
            excelButton.TabIndex = 7;
            excelButton.Text = "Показать в Excel";
            excelButton.UseVisualStyleBackColor = true;
            excelButton.Click += excelButton_Click;
            // 
            // exitButton
            // 
            exitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.Location = new Point(12, 237);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(206, 23);
            exitButton.TabIndex = 8;
            exitButton.Text = "Выйти";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(224, 12);
            label1.Name = "label1";
            label1.Size = new Size(183, 255);
            label1.TabIndex = 9;
            label1.Text = resources.GetString("label1.Text");
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 10;
            label2.Text = "Реальная часть";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(132, 38);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 11;
            label3.Text = "Мнимая часть";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            ClientSize = new Size(415, 272);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(exitButton);
            Controls.Add(excelButton);
            Controls.Add(wordButton);
            Controls.Add(clearButton);
            Controls.Add(realTextBox);
            Controls.Add(imaginaryTextBox);
            Controls.Add(calculateButton);
            Controls.Add(modulusLabel);
            Controls.Add(argumentLabel);
            Name = "MainForm";
            Text = "Complex Number Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button clearButton;
        private Button wordButton;
        private Button excelButton;
        private Button exitButton;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
