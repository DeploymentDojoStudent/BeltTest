namespace WinFormsApp1
{
    partial class Form1
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            editionLabel = new Label();
            customerLabel = new Label();
            EditionValue = new TextBox();
            CustomerValue = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(50, 50);
            label1.Name = "label1";
            label1.Size = new Size(625, 54);
            label1.TabIndex = 0;
            label1.Text = "Welcome to the Deployment Dojo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(84, 145);
            label2.Name = "label2";
            label2.Size = new Size(78, 28);
            label2.TabIndex = 1;
            label2.Text = "Edition:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(62, 209);
            label3.Name = "label3";
            label3.Size = new Size(100, 28);
            label3.TabIndex = 2;
            label3.Text = "Customer:";
            // 
            // EditionValue
            // 
            EditionValue.Location = new Point(210, 149);
            EditionValue.Name = "EditionValue";
            EditionValue.Size = new Size(392, 27);
            EditionValue.TabIndex = 5;
            // 
            // CustomerValue
            // 
            CustomerValue.Location = new Point(210, 213);
            CustomerValue.Name = "CustomerValue";
            CustomerValue.Size = new Size(392, 27);
            CustomerValue.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CustomerValue);
            Controls.Add(EditionValue);
            Controls.Add(customerLabel);
            Controls.Add(editionLabel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label editionLabel;
        private Label customerLabel;
        private TextBox EditionValue;
        private TextBox CustomerValue;
    }
}