using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileManager
{
    class LibraryFolder
    {
        List<LibraryFolder> subFolders = new List<LibraryFolder>();
        List<FileItem> fileItemList = new List<FileItem>();
        List<DataItem> dataItemList = new List<DataItem>();
        int libraryFolderID;
        string folderName;

        public int LibraryFolderID
        {
            get { return libraryFolderID; }
            //set { libraryFolderID = value; }
        }
        public string FolderName
        {
            get { return folderName; }
            //set { folderName = value; }
        }
        public List<FileItem> FileItemList
        {
            get { return fileItemList; }
        }
        public List<DataItem> DataItemList
        {
            get { return dataItemList; }
        }

        public void Load(int LibraryFolderID)
        {
            libraryFolderID = LibraryFolderID;

            List<List<string>> results;
            DB_Connection conn = new DB_Connection(DB_ConnectionString.GetFileManagerConnectionString());
            results = conn.ReturnQuery("sp_GET_LibraryFolder @LibraryFolderID="+LibraryFolderID);

            libraryFolderID = Convert.ToInt32(results[0][1]);
            folderName = results[3][1];

            results = conn.ReturnQuery("sp_GET_LibraryFolderIDs @LibraryFolderID="+libraryFolderID.ToString());
            if (results.Count > 0)
            {
                for (int counter = 1; counter <= results[0].Count-1; counter++)
                {
                    LibraryFolder tmpSubFolder = new LibraryFolder();
                    tmpSubFolder.Load(Convert.ToInt32(results[0][counter]));
                    subFolders.Add(tmpSubFolder);
                }
            }

            results = conn.ReturnQuery("sp_GET_FileItemsbyID @LibraryFolderID=" + libraryFolderID);
            if ((results.Count > 0) && (results[0][0].IndexOf("Error") == -1))
            {
                for (int counter = 1; counter <= results[0].Count-1; counter++)
                {

                    FileItem tmpFileItem = new FileItem();
                    tmpFileItem.Load(Convert.ToInt32(results[0][counter]));
                    fileItemList.Add(tmpFileItem);
                }
            }

            results = conn.ReturnQuery("sp_GET_DataItemsbyID @LibraryFolderID=" + libraryFolderID);
            if (results.Count > 0)
            {
                for (int counter = 1; counter <= results[0].Count-1; counter++)
                {

                    DataItem tmpDataItem = new DataItem();
                    tmpDataItem.Load(Convert.ToInt32(results[0][counter]));
                    dataItemList.Add(tmpDataItem);
                }
            }
        }

        public TreeNode BuildTree()
        {
            TreeNode tmpTreeNode = new TreeNode(folderName);
            tmpTreeNode.ImageIndex = 0;
            tmpTreeNode.SelectedImageIndex = 1;

            List<TreeNode> OldTree = new List<TreeNode>();

            foreach (LibraryFolder tmpLibraryFolder in subFolders)
            {
                //OldTree.AddRange(tmpLibraryFolder.BuildTree());
                tmpTreeNode.Nodes.Add(tmpLibraryFolder.BuildTree());
            }
            foreach (FileItem tmpFileItem in fileItemList)
            {
                //OldTree.Add(tmpFileItem.BuildTree());
                tmpTreeNode.Nodes.Add(tmpFileItem.BuildTree());
            }
            foreach (DataItem tmpDataItem in dataItemList)
            {
                //OldTree.Add(new TreeNode(tmpDataItem.DataLabel));
                //tmpTreeNode.Nodes.Add(tmpDataItem.BuildTree());
            }

            return tmpTreeNode;
        }
    }
}
