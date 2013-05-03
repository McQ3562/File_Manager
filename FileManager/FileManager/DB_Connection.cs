using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace FileManager
{
    public class DB_Connection
    {
        private string ConnectionString;
        private SqlConnection myConnection;

        //Constructor
        public DB_Connection(string NewConnectionString)
        {
            ConnectionString = NewConnectionString;
        }

        //Instance Methoids
        private void MakeConnection()
        {
            myConnection = new SqlConnection(ConnectionString);
        }

        public int ExecuteQuery(string QueryString)
        {
            int recordsEffectedCount = 0;

        if (myConnection==null)
            {
                MakeConnection();
            }

        string myQuery = QueryString;
        SqlCommand myCommand = new SqlCommand(myQuery);

        try
            {
                //initalize and open connection
                myCommand.Connection = myConnection;
                if (myConnection.State != System.Data.ConnectionState.Open)
                {
                    myConnection.Open();
                }
            }
        catch(Exception err)
            {
                WriteError(System.DateTime.Now + " " + err.Message);
                myConnection.Close();
            }

        try
            {
                //run query and close connection
                recordsEffectedCount = myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
        catch(Exception err)
            {
                WriteError(System.DateTime.Now + " " + err.Message);
                myConnection.Close();
            }

        return recordsEffectedCount;
        }

    public List<List<string>> ReturnQuery(string QueryString)
    {
        List<List<string>> TmpQuery;

        if (myConnection==null)
        {
            MakeConnection();
        }

        string myQuery = QueryString;
        SqlCommand myCommand = new SqlCommand(myQuery);

        try
        {
            //open connection
            myCommand.Connection = myConnection;
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }
        catch(Exception err)
        {
            WriteError(System.DateTime.Now + " " + err.Message);
            myConnection.Close();

            List<List<string>> ErrorMessage = new List<List<string>>();
            ErrorMessage.Add(new List<string>());
            ErrorMessage[0].Add("Error: " + err.Message);
            return ErrorMessage;
        }

        try
        {
            //initalize reader and read from db
            SqlDataReader myReader;
            myReader = myCommand.ExecuteReader();
            TmpQuery = ReadResults(myReader);

            //close connection
            myReader.Close();
            myConnection.Close();
        }
        catch (Exception err)
        {
            WriteError(System.DateTime.Now + " " + err.Message);
            myConnection.Close();
            
            List<List<string>> ErrorMessage = new List<List<string>>();
            ErrorMessage.Add(new List<string>());
            ErrorMessage[0].Add("Error: " + err.Message);
            return ErrorMessage;
        }

        return TmpQuery;
    }

    private List<List<string>> ReadResults(SqlDataReader testReader)
    {
        List<List<string>> nullRetArray = new List<List<string>>();
        if (testReader.HasRows == false)
            {return nullRetArray;}

        List<List<string>> RetArray = new List<List<string>>();

        for(int x=0;x<testReader.FieldCount;x++)
        {
            RetArray.Add(new List<string>());
            RetArray[x].Add("");
        }

        while (testReader.Read())
        {
            for (int x = 0;testReader.FieldCount>x;x++)
            {
                RetArray[x][0] = testReader.GetName(x);
                RetArray[x].Add(GetElement(testReader.GetDataTypeName(x), testReader, x));
            }
        }

        return RetArray;
    }
 
    private string GetElement(string DataType, SqlDataReader NewReader, long newOffset)
    {
        int Offset = ((int)newOffset);
        if (NewReader.IsDBNull(Offset) != true)
        {
            if (DataType == "int")
            {
                return Convert.ToString(NewReader.GetInt32(Offset));
            }
            else if (DataType == "nvarchar")
            {
                return Convert.ToString(NewReader.GetString(Offset));
            }
            else if (DataType == "varchar")
            {
                return Convert.ToString(NewReader.GetString(Offset));
            }
            else if (DataType == "char")
            {
                return Convert.ToString(NewReader.GetString(Offset));
            }
            else if (DataType == "text")
            {
                return Convert.ToString(NewReader.GetString(Offset));
            }
            else if (DataType == "tinyint")
            {
                return Convert.ToString(NewReader.GetByte(Offset));
            }
            else if (DataType == "smalldatetime")
            {
                return Convert.ToString(NewReader.GetDateTime(Offset));
            }
            else if (DataType == "datetime")
            {
                return Convert.ToString(NewReader.GetDateTime(Offset));
            }
            else if (DataType == "bit")
            {
                return Convert.ToString(NewReader.GetBoolean(Offset));
            }
            else if (DataType == "money")
            {
                return Convert.ToString(NewReader.GetSqlMoney(Offset).Value);
            }
            else if (DataType == "bigint")
            {
                return Convert.ToString(NewReader.GetInt64(Offset));
            }
        }
        return "";
    }

    private void WriteError(string ErrorMessage)
    {
        Console.Write(ErrorMessage);
    }

    //SQL Queries
    public List<List<string>> CreateCall(string NewPhoneLog)
    {
        string SQL = "sp_CreateCall @CallID=";
        return ReturnQuery(SQL);
    }


}

public class DB_ConnectionString
    {
        private static string ServerName = "";
        private static string DatabaseName = "";
        private static string UserId = "";
        private static string Password = "";
        private static string ConnectionType = "SQL";
        private static string ApplicatioName = "File_Manager";
        //For Access Databases Only
        private static string FilePath = "";

        //Accessors
        public static string serverName
        {
            get { return ServerName; }
            set { ServerName = value; }
        }
        public static string databaseName
        {
            get { return DatabaseName; }
            set { DatabaseName = value; }
        }
        public static string userID
        {
            get { return UserId; }
            set { UserId = value; }
        }
        public static string password
        {
            get { return Password; }
            set { Password = value; }
        }
        public static string connectionType
        {
            get { return ConnectionType; }
            set { ConnectionType = value; }
        }
        public static string applicationName
        {
            get { return ApplicatioName; }
            set { ApplicatioName = value; }
        }
        public static string filePath
        {
            get { return FilePath; }
            set { FilePath = value; }
        }

        //Class Methoids
        public static string GetConnectionString()
        {
            if (ConnectionType == "SQL")
            {
                return "user id=" + UserId + ";password=" + Password + ";initial catalog=" + DatabaseName + ";Data Source=" + ServerName + ";Connect Timeout=10;Application Name=" + ApplicatioName;
            }
            else if (ConnectionType == "Compact")
            {
                return "Data Source= |DataDirectory|\\" + DatabaseName;
            }
            else if (ConnectionType == "Access")
            {
                return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+FilePath+";Persist Security Info=False;";
            }
            else
            {
                return "Persist Security Info=False;Integrated Security=SSPI;database=" + DatabaseName + ";server=" + ServerName + ";Application Name=" + ApplicatioName;
            }
        }

        public static string GetFileManagerConnectionString()
        {
            ConnectionStringSettings awareConStr = ConfigurationManager.ConnectionStrings["FileManager"];
            SqlConnectionStringBuilder awareConStrBuilder = new SqlConnectionStringBuilder(awareConStr.ConnectionString);
            return awareConStrBuilder.ConnectionString;
        }
    }
}
