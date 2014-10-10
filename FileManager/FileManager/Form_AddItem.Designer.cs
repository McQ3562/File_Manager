namespace FileManager
{
    partial class Form_AddItem
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_Library = new System.Windows.Forms.RadioButton();
            this.radioButton_Folder = new System.Windows.Forms.RadioButton();
            this.radioButton_File = new System.Windows.Forms.RadioButton();
            this.radioButton_Data = new System.Windows.Forms.RadioButton();
            this.textBox_LibraryName = new System.Windows.Forms.TextBox();
            this.textBox_Folder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_FileName = new System.Windows.Forms.TextBox();
            this.button_Browse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_FilePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_DataName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_DataData = new System.Windows.Forms.TextBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_DataData);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_DataName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_FilePath);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button_Browse);
            this.groupBox1.Controls.Add(this.textBox_FileName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_Folder);
            this.groupBox1.Controls.Add(this.textBox_LibraryName);
            this.groupBox1.Controls.Add(this.radioButton_Data);
            this.groupBox1.Controls.Add(this.radioButton_File);
            this.groupBox1.Controls.Add(this.radioButton_Folder);
            this.groupBox1.Controls.Add(this.radioButton_Library);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 571);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // radioButton_Library
            // 
            this.radioButton_Library.AutoSize = true;
            this.radioButton_Library.Location = new System.Drawing.Point(6, 19);
            this.radioButton_Library.Name = "radioButton_Library";
            this.radioButton_Library.Size = new System.Drawing.Size(78, 17);
            this.radioButton_Library.TabIndex = 0;
            this.radioButton_Library.TabStop = true;
            this.radioButton_Library.Text = "Add Library";
            this.radioButton_Library.UseVisualStyleBackColor = true;
            this.radioButton_Library.CheckedChanged += new System.EventHandler(this.radioButton_Library_CheckedChanged);
            // 
            // radioButton_Folder
            // 
            this.radioButton_Folder.AutoSize = true;
            this.radioButton_Folder.Location = new System.Drawing.Point(6, 107);
            this.radioButton_Folder.Name = "radioButton_Folder";
            this.radioButton_Folder.Size = new System.Drawing.Size(91, 17);
            this.radioButton_Folder.TabIndex = 1;
            this.radioButton_Folder.TabStop = true;
            this.radioButton_Folder.Text = "Add Folder to ";
            this.radioButton_Folder.UseVisualStyleBackColor = true;
            this.radioButton_Folder.CheckedChanged += new System.EventHandler(this.radioButton_Folder_CheckedChanged);
            // 
            // radioButton_File
            // 
            this.radioButton_File.AutoSize = true;
            this.radioButton_File.Location = new System.Drawing.Point(6, 198);
            this.radioButton_File.Name = "radioButton_File";
            this.radioButton_File.Size = new System.Drawing.Size(63, 17);
            this.radioButton_File.TabIndex = 2;
            this.radioButton_File.TabStop = true;
            this.radioButton_File.Text = "Add File";
            this.radioButton_File.UseVisualStyleBackColor = true;
            this.radioButton_File.CheckedChanged += new System.EventHandler(this.radioButton_File_CheckedChanged);
            // 
            // radioButton_Data
            // 
            this.radioButton_Data.AutoSize = true;
            this.radioButton_Data.Location = new System.Drawing.Point(6, 328);
            this.radioButton_Data.Name = "radioButton_Data";
            this.radioButton_Data.Size = new System.Drawing.Size(70, 17);
            this.radioButton_Data.TabIndex = 3;
            this.radioButton_Data.TabStop = true;
            this.radioButton_Data.Text = "Add Data";
            this.radioButton_Data.UseVisualStyleBackColor = true;
            this.radioButton_Data.CheckedChanged += new System.EventHandler(this.radioButton_Data_CheckedChanged);
            // 
            // textBox_LibraryName
            // 
            this.textBox_LibraryName.Location = new System.Drawing.Point(15, 67);
            this.textBox_LibraryName.Name = "textBox_LibraryName";
            this.textBox_LibraryName.Size = new System.Drawing.Size(348, 20);
            this.textBox_LibraryName.TabIndex = 4;
            // 
            // textBox_Folder
            // 
            this.textBox_Folder.Location = new System.Drawing.Point(15, 158);
            this.textBox_Folder.Name = "textBox_Folder";
            this.textBox_Folder.Size = new System.Drawing.Size(348, 20);
            this.textBox_Folder.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "New Library Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "New Folder Name";
            // 
            // textBox_FileName
            // 
            this.textBox_FileName.Location = new System.Drawing.Point(15, 251);
            this.textBox_FileName.Name = "textBox_FileName";
            this.textBox_FileName.Size = new System.Drawing.Size(348, 20);
            this.textBox_FileName.TabIndex = 8;
            // 
            // button_Browse
            // 
            this.button_Browse.Location = new System.Drawing.Point(288, 288);
            this.button_Browse.Name = "button_Browse";
            this.button_Browse.Size = new System.Drawing.Size(75, 23);
            this.button_Browse.TabIndex = 9;
            this.button_Browse.Text = "Browse";
            this.button_Browse.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Display Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Path to File";
            // 
            // textBox_FilePath
            // 
            this.textBox_FilePath.Location = new System.Drawing.Point(15, 290);
            this.textBox_FilePath.Name = "textBox_FilePath";
            this.textBox_FilePath.Size = new System.Drawing.Size(267, 20);
            this.textBox_FilePath.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 362);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Display Lable";
            // 
            // textBox_DataName
            // 
            this.textBox_DataName.Location = new System.Drawing.Point(15, 378);
            this.textBox_DataName.Name = "textBox_DataName";
            this.textBox_DataName.Size = new System.Drawing.Size(348, 20);
            this.textBox_DataName.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 411);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Data";
            // 
            // textBox_DataData
            // 
            this.textBox_DataData.Location = new System.Drawing.Point(15, 427);
            this.textBox_DataData.Multiline = true;
            this.textBox_DataData.Name = "textBox_DataData";
            this.textBox_DataData.Size = new System.Drawing.Size(348, 127);
            this.textBox_DataData.TabIndex = 16;
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(314, 607);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 1;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // Form_AddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 653);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_AddItem";
            this.Text = "Add Item";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_DataData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_DataName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_FilePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_Browse;
        private System.Windows.Forms.TextBox textBox_FileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Folder;
        private System.Windows.Forms.TextBox textBox_LibraryName;
        private System.Windows.Forms.RadioButton radioButton_Data;
        private System.Windows.Forms.RadioButton radioButton_File;
        private System.Windows.Forms.RadioButton radioButton_Folder;
        private System.Windows.Forms.RadioButton radioButton_Library;
        private System.Windows.Forms.Button button_Save;
    }
}