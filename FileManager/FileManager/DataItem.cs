using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileManager
{
    class DataItem
    {
        private string dataItemID;
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
            List<List<string>> results = new List<List<string>>();
            DB_Connection conn = new DB_Connection(DB_ConnectionString.GetFileManagerConnectionString());
            results = conn.ReturnQuery("sp_GET_DataItem @DataItemID="+dataItemID);
            if (results.Count > 0)
            {
                dataItemID = results[0][1];
            }

        }
    }
}
