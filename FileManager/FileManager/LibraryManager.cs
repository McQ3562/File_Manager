using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileManager
{
    class LibraryManager
    {
        public List<Library> libraryCollection = new List<Library>();

        public void load()
        {
            List<List<string>> results = new List<List<string>>();
            DB_Connection conn = new DB_Connection(DB_ConnectionString.GetFileManagerConnectionString());

            results = conn.ReturnQuery("dbo.sp_GET_Libraries");
            if (results[0][0].IndexOf("Error") == -1)
            {
                for (int counter = 1; counter < results[0].Count; counter++)
                {
                    Library tmpLibrary = new Library();
                    tmpLibrary.LibraryID = Convert.ToInt32(results[0][counter]);
                    tmpLibrary.LibraryName = results[1][counter];

                    libraryCollection.Add(tmpLibrary);
                }
            }
        }

        public Library GetLibrary(string libraryName)
        {
            Library tmpLibrary = new Library();
            tmpLibrary.LibraryName = libraryName;
            tmpLibrary.Load();

            return tmpLibrary;
        }

    }
}
