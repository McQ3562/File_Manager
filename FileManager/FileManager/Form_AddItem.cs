using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileManager
{
    public partial class Form_AddItem : Form
    {

        public TreeNode nodeToEdit { get; set; }

        public Form_AddItem()
        {
            InitializeComponent();
        }

        private void radioButton_Library_CheckedChanged(object sender, EventArgs e)
        {
            updateDisplay("Library");
        }

        private void radioButton_Folder_CheckedChanged(object sender, EventArgs e)
        {
            updateDisplay("Folder");
        }

        private void radioButton_File_CheckedChanged(object sender, EventArgs e)
        {
            updateDisplay("File");
        }

        private void radioButton_Data_CheckedChanged(object sender, EventArgs e)
        {
            updateDisplay("Data");
        }

        private void updateDisplay(string section)
        {
            bool libraryFlag = false;
            bool folderFlag = false;
            bool fileFlag = false;
            bool dataFlag = false;

            if (section == "Library")
                libraryFlag = true;
            else if (section == "Folder")
                folderFlag = true;
            else if (section == "File")
                fileFlag = true;
            else if (section == "Data")
                dataFlag = true;

            textBox_LibraryName.Enabled = libraryFlag;
            textBox_Folder.Enabled = folderFlag;
            textBox_FileName.Enabled = fileFlag;
            textBox_FilePath.Enabled = fileFlag;
            button_Browse.Enabled = fileFlag;
            textBox_DataName.Enabled = dataFlag;
            textBox_DataData.Enabled = dataFlag;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (radioButton_Library.Checked)
            {
                Library tmpLibrary = new Library();
                tmpLibrary.LibraryName = textBox_LibraryName.Text;
                tmpLibrary.Save();
            }
            else if (radioButton_Folder.Checked)
            {
                string libraryName = nodeToEdit.FullPath.Substring(0,nodeToEdit.FullPath.IndexOf("\\"));

                LibraryFolder tmpLibFolder = new LibraryFolder();
                tmpLibFolder.FolderName = textBox_Folder.Text;
                tmpLibFolder.Save(((FileManager.LibraryFolder)(nodeToEdit.Tag)).LibraryFolderID, libraryName);
            }
            else if (radioButton_File.Checked)
            {
                FileItem tmpFileeItem = new FileItem();

            }
            else if (radioButton_Data.Checked)
            {

            }
        }
    }
}
