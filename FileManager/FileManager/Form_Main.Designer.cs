namespace FileManager
{
    partial class Form_Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Library = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.treeView_FileData = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Library";
            // 
            // comboBox_Library
            // 
            this.comboBox_Library.FormattingEnabled = true;
            this.comboBox_Library.Location = new System.Drawing.Point(12, 25);
            this.comboBox_Library.Name = "comboBox_Library";
            this.comboBox_Library.Size = new System.Drawing.Size(490, 21);
            this.comboBox_Library.TabIndex = 2;
            this.comboBox_Library.SelectedIndexChanged += new System.EventHandler(this.comboBox_Library_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "File Data";
            // 
            // treeView_FileData
            // 
            this.treeView_FileData.Location = new System.Drawing.Point(12, 65);
            this.treeView_FileData.Name = "treeView_FileData";
            this.treeView_FileData.Size = new System.Drawing.Size(490, 476);
            this.treeView_FileData.TabIndex = 4;
            this.treeView_FileData.DoubleClick += new System.EventHandler(this.treeView_FileData_DoubleClick);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 553);
            this.Controls.Add(this.treeView_FileData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_Library);
            this.Controls.Add(this.label1);
            this.Name = "Form_Main";
            this.Text = "File Manager";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Library;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeView_FileData;
    }
}

