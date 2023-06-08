namespace ReplaceText
{
    partial class ReplaceText
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
            this.txtSourceTxt = new System.Windows.Forms.RichTextBox();
            this.txtMapBinding = new System.Windows.Forms.RichTextBox();
            this.txtResultText = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxSourceType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnFindAllVietnameseText = new System.Windows.Forms.Button();
            this.btnFindWithPattern = new System.Windows.Forms.Button();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtSourceTxt
            // 
            this.txtSourceTxt.Location = new System.Drawing.Point(12, 96);
            this.txtSourceTxt.Name = "txtSourceTxt";
            this.txtSourceTxt.Size = new System.Drawing.Size(871, 364);
            this.txtSourceTxt.TabIndex = 0;
            this.txtSourceTxt.Text = "";
            // 
            // txtMapBinding
            // 
            this.txtMapBinding.Location = new System.Drawing.Point(914, 96);
            this.txtMapBinding.Name = "txtMapBinding";
            this.txtMapBinding.Size = new System.Drawing.Size(607, 364);
            this.txtMapBinding.TabIndex = 1;
            this.txtMapBinding.Text = "";
            // 
            // txtResultText
            // 
            this.txtResultText.Location = new System.Drawing.Point(12, 493);
            this.txtResultText.Name = "txtResultText";
            this.txtResultText.Size = new System.Drawing.Size(1509, 397);
            this.txtResultText.TabIndex = 2;
            this.txtResultText.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Source Text:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(914, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Map binding: e.g. string=replacement";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 475);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Result Text:";
            // 
            // comboBoxSourceType
            // 
            this.comboBoxSourceType.FormattingEnabled = true;
            this.comboBoxSourceType.Location = new System.Drawing.Point(241, 12);
            this.comboBoxSourceType.Name = "comboBoxSourceType";
            this.comboBoxSourceType.Size = new System.Drawing.Size(121, 23);
            this.comboBoxSourceType.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Source Text Type:";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(494, 17);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 8;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnFindAllVietnameseText
            // 
            this.btnFindAllVietnameseText.Location = new System.Drawing.Point(665, 17);
            this.btnFindAllVietnameseText.Name = "btnFindAllVietnameseText";
            this.btnFindAllVietnameseText.Size = new System.Drawing.Size(218, 23);
            this.btnFindAllVietnameseText.TabIndex = 9;
            this.btnFindAllVietnameseText.Text = "Find all Vietnamese text";
            this.btnFindAllVietnameseText.UseVisualStyleBackColor = true;
            this.btnFindAllVietnameseText.Click += new System.EventHandler(this.btnFindAllVietnameseText_Click);
            // 
            // btnFindWithPattern
            // 
            this.btnFindWithPattern.Location = new System.Drawing.Point(942, 15);
            this.btnFindWithPattern.Name = "btnFindWithPattern";
            this.btnFindWithPattern.Size = new System.Drawing.Size(218, 23);
            this.btnFindWithPattern.TabIndex = 10;
            this.btnFindWithPattern.Text = "btnFindWithPattern";
            this.btnFindWithPattern.UseVisualStyleBackColor = true;
            this.btnFindWithPattern.Click += new System.EventHandler(this.btnFindWithPattern_Click);
            // 
            // txtPattern
            // 
            this.txtPattern.Location = new System.Drawing.Point(942, 44);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(521, 23);
            this.txtPattern.TabIndex = 11;
            // 
            // ReplaceText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1533, 902);
            this.Controls.Add(this.txtPattern);
            this.Controls.Add(this.btnFindWithPattern);
            this.Controls.Add(this.btnFindAllVietnameseText);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxSourceType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtResultText);
            this.Controls.Add(this.txtMapBinding);
            this.Controls.Add(this.txtSourceTxt);
            this.Name = "ReplaceText";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox txtSourceTxt;
        private RichTextBox txtMapBinding;
        private RichTextBox txtResultText;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBoxSourceType;
        private Label label4;
        private Button btnExecute;
        private Button btnFindAllVietnameseText;
        private Button btnFindWithPattern;
        private TextBox txtPattern;
    }
}