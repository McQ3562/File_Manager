using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace FileManager
{
    public partial class Form_Main : Form
    {
        Library currentLibrary = new Library();
        LibraryManager libraryManager = new LibraryManager();

        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            // Load the images in an ImageList.
            ImageList myImageList = new ImageList();
            myImageList.Images.Add(Image.FromFile("folder.gif"));           //0
            myImageList.Images.Add(Image.FromFile("folder_selected.gif"));  //1
            myImageList.Images.Add(Image.FromFile("file.gif"));             //2
            myImageList.Images.Add(Image.FromFile("file_selected.gif"));    //3
            myImageList.Images.Add(Image.FromFile("image.gif"));            //4
            myImageList.Images.Add(Image.FromFile("image_selected.gif"));   //5

            // Assign the ImageList to the TreeView.
            treeView_FileData.ImageList = myImageList;

            // Set the TreeView control's default image and selected image indexes.
            treeView_FileData.ImageIndex = 0;
            treeView_FileData.SelectedImageIndex = 1;


            libraryManager.load();

            foreach (Library tmpLibrary in libraryManager.libraryCollection)
            {
                comboBox_Library.Items.Add(tmpLibrary.LibraryName);
            }
        }

        private void comboBox_Library_SelectedIndexChanged(object sender, EventArgs e)
        {
            string LibraryName = comboBox_Library.SelectedItem.ToString();
            currentLibrary = libraryManager.GetLibrary(LibraryName);

            DisplayTree(currentLibrary);
        }

        private void DisplayTree(Library tmpLibrary)
        {
            treeView_FileData.Nodes.Clear();

            TreeNode tmpTreeNode;
            tmpTreeNode = currentLibrary.BuildTree(); //tmpTreeNode);
            treeView_FileData.Nodes.Add(tmpTreeNode);
        }

        private void treeView_FileData_DoubleClick(object sender, EventArgs e)
        {
            TreeNode selectedNode;
            selectedNode = ((TreeView)sender).SelectedNode;  //.((FileItem)Tag).filePath;
            object obfFileItem = selectedNode.Tag;
            System.Type objectType = obfFileItem.GetType();

            if(objectType.Name == "FileItem")
            {
                FileItem tempFileItem = (FileItem)obfFileItem;
                if (File.Exists(tempFileItem.FilePath))
                {
                    System.Diagnostics.Process.Start(tempFileItem.FilePath);
                }
                else
                {
                    MessageBox.Show("File does not exist.  Please update path to file.", "Missing File Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            
            
            //Process OpenFileProcess = new Process();
            //OpenFileProcess.StartInfo.UseShellExecute = false;
            //OpenFileProcess.StartInfo.FileName = tempFileItem.FilePath;
            //OpenFileProcess.StartInfo.CreateNoWindow = false;
            //OpenFileProcess.Start();
        }

        private void GetProgramPath(string fileName)
        {


        }
    }
}