using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileManager
{
    class FileItem
    {
        private int fileItemID;
        private string displayFileName;
        private string filePath;

        public int FileItemID
        {
            set { fileItemID = value; }
            get { return fileItemID; }
        }
        public string DisplayFileName
        {
            set { displayFileName = value; }
            get { return displayFileName; }
        }
        public string FilePath
        {
            set { filePath = value; }
            get { return filePath; }
        }

        public void Load(int FileItemID)
        {
            fileItemID = FileItemID;

            List<List<string>> results;
            DB_Connection conn = new DB_Connection(DB_ConnectionString.GetFileManagerConnectionString());
            results = conn.ReturnQuery("sp_GET_FileItem @FileItemID="+fileItemID.ToString());
            if (results.Count > 0)
            {
                fileItemID = Convert.ToInt32(results[0][1]);
                displayFileName = results[2][1];
                filePath = results[3][1];
            }
        }

        public TreeNode BuildTree()
        {
            TreeNode tmpTreeNode = new TreeNode(displayFileName);
            tmpTreeNode.ImageIndex = 4;
            tmpTreeNode.SelectedImageIndex = 5;
            tmpTreeNode.Tag = this;
            return tmpTreeNode;
        }
    }
}
