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

        TreeNode currentlySelectedNode;

        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            // Load the images in an ImageList.
            ImageList myImageList = new ImageList();
            myImageList.Images.Add(Image.FromFile("Images\\folder.gif"));           //0
            myImageList.Images.Add(Image.FromFile("Images\\folder_selected.gif"));  //1
            myImageList.Images.Add(Image.FromFile("Images\\file.gif"));             //2
            myImageList.Images.Add(Image.FromFile("Images\\file_selected.gif"));    //3
            myImageList.Images.Add(Image.FromFile("Images\\image.gif"));            //4
            myImageList.Images.Add(Image.FromFile("Images\\image_selected.gif"));   //5

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
            //TreeNode selectedNode;
            //selectedNode = ((TreeView)sender).SelectedNode;  //.((FileItem)Tag).filePath;
            object obfFileItem = GetTreeDataObject(sender); //selectedNode.Tag;
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
            else if (objectType.Name == "DataItem")
            {

            }
        }

        private Object GetTreeDataObject(object selectedTreeNode)
        {
            TreeNode selectedNode;
            selectedNode = ((TreeView)selectedTreeNode).SelectedNode;
            object obfFileItem = selectedNode.Tag;
            System.Type objectType = obfFileItem.GetType();

            return obfFileItem;
        }

        private void contextMenuStripDataFileTree_Opening(object sender, CancelEventArgs e)
        {

            currentlySelectedNode = ((TreeView)(((ContextMenuStrip)(sender)).SourceControl)).SelectedNode;
            if ((currentlySelectedNode == null) || (currentlySelectedNode.Tag == null))
            {
                e.Cancel = true;
            }
            else if (currentlySelectedNode.Tag is LibraryFolder)
            {
                contextMenuStripDataFileTree.Items["addItemToolStripMenuItem"].Visible = true;
                contextMenuStripDataFileTree.Items["addItemToolStripMenuItem"].Text = "Add a new Item to \"" + currentlySelectedNode.Text + "\"";
                contextMenuStripDataFileTree.Items["editItemToolStripMenuItem"].Text = "Edit Folder \"" + currentlySelectedNode.Text + "\"";
                contextMenuStripDataFileTree.Items["deleteItemToolStripMenuItem"].Text = "Delete Folder \"" + currentlySelectedNode.Text + "\"";
            }
            else if (currentlySelectedNode.Tag is DataItem)
            {
                contextMenuStripDataFileTree.Items["addItemToolStripMenuItem"].Visible = false;
                contextMenuStripDataFileTree.Items["editItemToolStripMenuItem"].Text = "Edit Data in \"" + currentlySelectedNode.Text + "\"";
                contextMenuStripDataFileTree.Items["deleteItemToolStripMenuItem"].Text = "Delete \"" + currentlySelectedNode.Text + "\"";
            }
            else if (currentlySelectedNode.Tag is FileItem)
            {
                contextMenuStripDataFileTree.Items["addItemToolStripMenuItem"].Visible = false;
                contextMenuStripDataFileTree.Items["editItemToolStripMenuItem"].Text = "Edit File \"" + currentlySelectedNode.Text + "\"";
                contextMenuStripDataFileTree.Items["deleteItemToolStripMenuItem"].Text = "Delete File \"" + currentlySelectedNode.Text + "\"";
            }
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_AddItem addItem = new Form_AddItem();
            addItem.nodeToEdit = currentlySelectedNode;
            addItem.ShowDialog();
        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //object obFileItem = GetTreeDataObject(sender);

            
        }

        private void deleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }
    }
}