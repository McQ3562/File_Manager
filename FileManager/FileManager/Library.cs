using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileManager
{
    class Library
    {
        List<LibraryFolder> libraryFolders = new List<LibraryFolder>();
        string libraryName = "";
        int libraryID;

        public string LibraryName
        {
            get{ return libraryName; }
            set { libraryName = value; }
        }
        public int LibraryID
        {
            get { return libraryID; }
            set { libraryID = value; }
        }
        public List<LibraryFolder> LibraryFolders
        {
            get { return libraryFolders; }
            set { libraryFolders = value; }
        }

        public void Load()
        {
            //Load Library from database
            List<List<string>> results = new List<List<string>>();
            DB_Connection conn = new DB_Connection(DB_ConnectionString.GetFileManagerConnectionString());
            results = conn.ReturnQuery("sp_GET_LibraryFolderIDs @LibraryFolderID=NULL, @LibraryName='" + libraryName + "'");

            for (int counter = 1; counter < results[0].Count; counter++)
            {
                int libraryFolderID;
                //save each Library folder
                LibraryFolder tmpLibraryFolder = new LibraryFolder();
                if(Int32.TryParse(results[0][counter],out libraryFolderID))
                {
                    tmpLibraryFolder.Load(libraryFolderID);
                    libraryFolders.Add(tmpLibraryFolder);
                }
            }
        }

        public void Save()
        {
            //Saves Library data to database for specified ID
        }

        public TreeNode BuildTree()
        {
            TreeNode tmpTreeNode = new TreeNode(libraryName);
            foreach (LibraryFolder tmpLibraryFolder in libraryFolders)
            {
                tmpTreeNode.Nodes.Add(tmpLibraryFolder.BuildTree());
            }
            return tmpTreeNode;
        }

        public TreeNode BuildTree(TreeNode OldTree)
        {
            foreach (LibraryFolder tmpLibraryFolder in libraryFolders)
            {
                TreeNode treeNode = new TreeNode(tmpLibraryFolder.FolderName);
                treeNode.Tag = tmpLibraryFolder;
                treeNode.Nodes.Add(tmpLibraryFolder.BuildTree());
                OldTree.Nodes.Add(treeNode);
            }

            return OldTree;
        }
    }
}
