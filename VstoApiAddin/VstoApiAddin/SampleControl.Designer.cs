namespace VstoApiAddin
{
    partial class SampleControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCheckSpelling = new System.Windows.Forms.Button();
            this.btnFixSpelling = new System.Windows.Forms.Button();
            this.chkIssueList = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btnCheckSpelling
            // 
            this.btnCheckSpelling.Location = new System.Drawing.Point(25, 13);
            this.btnCheckSpelling.Name = "btnCheckSpelling";
            this.btnCheckSpelling.Size = new System.Drawing.Size(610, 28);
            this.btnCheckSpelling.TabIndex = 1;
            this.btnCheckSpelling.Text = "Check Spelling";
            this.btnCheckSpelling.UseVisualStyleBackColor = true;
            this.btnCheckSpelling.Click += new System.EventHandler(this.btnCheckSpelling_Click);
            // 
            // btnFixSpelling
            // 
            this.btnFixSpelling.Location = new System.Drawing.Point(25, 393);
            this.btnFixSpelling.Name = "btnFixSpelling";
            this.btnFixSpelling.Size = new System.Drawing.Size(610, 28);
            this.btnFixSpelling.TabIndex = 2;
            this.btnFixSpelling.Text = "Fix Spelling";
            this.btnFixSpelling.UseVisualStyleBackColor = true;
            this.btnFixSpelling.Click += new System.EventHandler(this.btnFixSpelling_Click);
            // 
            // chkIssueList
            // 
            this.chkIssueList.FormattingEnabled = true;
            this.chkIssueList.Location = new System.Drawing.Point(37, 76);
            this.chkIssueList.Name = "chkIssueList";
            this.chkIssueList.Size = new System.Drawing.Size(597, 293);
            this.chkIssueList.TabIndex = 3;
            this.chkIssueList.Visible = false;
            // 
            // SampleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkIssueList);
            this.Controls.Add(this.btnFixSpelling);
            this.Controls.Add(this.btnCheckSpelling);
            this.Name = "SampleControl";
            this.Size = new System.Drawing.Size(680, 464);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCheckSpelling;
        private System.Windows.Forms.Button btnFixSpelling;
        private System.Windows.Forms.CheckedListBox chkIssueList;
    }
}
