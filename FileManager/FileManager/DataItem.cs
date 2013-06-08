using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileManager
{
    class DataItem
    {
        private int dataItemID;
        private string dataLabel;
        private string dataValue;

        public string DataLabel
        {
            set { dataLabel= value; }
            get { return dataLabel; }
        }
        public string DataValue
        {
            set { dataValue = value; }
            get { return dataValue; }
        }

        public void Load(int DataIdemID)
        {
            dataItemID = DataIdemID;

            List<List<string>> results = new List<List<string>>();
            DB_Connection conn = new DB_Connection(DB_ConnectionString.GetFileManagerConnectionString());
            results = conn.ReturnQuery("sp_GET_DataItem @DataItemID="+dataItemID);
            if (results.Count > 0)
            {
                dataLabel = results[2][1];
                dataValue = results[3][1];
            }

        }

        public TreeNode BuildTree()
        {
            string displayString = dataLabel + ": ";
            if(dataValue.Length > 50)
            {displayString+=dataValue.Substring(1,50);}
            else 
            {displayString+=dataValue; }

            TreeNode tmpTreeNode = new TreeNode(displayString);
            tmpTreeNode.ImageIndex = 2;
            tmpTreeNode.SelectedImageIndex = 3;
            tmpTreeNode.Tag = this;
            return tmpTreeNode;
        }
    }
}
