namespace Calculator
{
    partial class frmAddStrip
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstCalculationLines = new System.Windows.Forms.ListBox();
            this.txt = new System.Windows.Forms.TextBox();
            this.lblEnterCalculations = new System.Windows.Forms.Label();
            this.lblSelectLine = new System.Windows.Forms.Label();
            this.pnlAddChanges = new System.Windows.Forms.Panel();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.pnlAddChanges.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(604, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // lstCalculationLines
            // 
            this.lstCalculationLines.FormattingEnabled = true;
            this.lstCalculationLines.Location = new System.Drawing.Point(30, 38);
            this.lstCalculationLines.Name = "lstCalculationLines";
            this.lstCalculationLines.Size = new System.Drawing.Size(190, 329);
            this.lstCalculationLines.TabIndex = 1;
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(296, 100);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(179, 20);
            this.txt.TabIndex = 2;
            // 
            // lblEnterCalculations
            // 
            this.lblEnterCalculations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterCalculations.Location = new System.Drawing.Point(293, 56);
            this.lblEnterCalculations.Name = "lblEnterCalculations";
            this.lblEnterCalculations.Size = new System.Drawing.Size(205, 41);
            this.lblEnterCalculations.TabIndex = 3;
            this.lblEnterCalculations.Text = "Enter your calculations in the text box below";
            // 
            // lblSelectLine
            // 
            this.lblSelectLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectLine.Location = new System.Drawing.Point(293, 174);
            this.lblSelectLine.Name = "lblSelectLine";
            this.lblSelectLine.Size = new System.Drawing.Size(179, 36);
            this.lblSelectLine.TabIndex = 4;
            this.lblSelectLine.Text = "To make changes select a line in the list first";
            // 
            // pnlAddChanges
            // 
            this.pnlAddChanges.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlAddChanges.Controls.Add(this.btnInsert);
            this.pnlAddChanges.Controls.Add(this.btnDelete);
            this.pnlAddChanges.Controls.Add(this.btnUpdate);
            this.pnlAddChanges.Controls.Add(this.txtValue);
            this.pnlAddChanges.Location = new System.Drawing.Point(296, 237);
            this.pnlAddChanges.Name = "pnlAddChanges";
            this.pnlAddChanges.Size = new System.Drawing.Size(228, 130);
            this.pnlAddChanges.TabIndex = 5;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(157, 91);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(57, 23);
            this.btnInsert.TabIndex = 4;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(83, 91);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(68, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(16, 91);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(61, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(37, 27);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(151, 20);
            this.txtValue.TabIndex = 0;
            // 
            // frmAddStrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 456);
            this.Controls.Add(this.pnlAddChanges);
            this.Controls.Add(this.lblSelectLine);
            this.Controls.Add(this.lblEnterCalculations);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.lstCalculationLines);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmAddStrip";
            this.Text = "AddStrip";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlAddChanges.ResumeLayout(false);
            this.pnlAddChanges.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListBox lstCalculationLines;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.Label lblEnterCalculations;
        private System.Windows.Forms.Label lblSelectLine;
        private System.Windows.Forms.Panel pnlAddChanges;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtValue;
    }
}

