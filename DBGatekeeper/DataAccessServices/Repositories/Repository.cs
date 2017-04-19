using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections;
using System.Data;

namespace DBGatekeeper.DataAccessServices.Repositories
{
    public class Repository : IRepository
    {
        #region Fields
        private Database _database;
        #endregion

        #region Properties
         public Database Database
        {
            get
            {
                return _database;
            }
            set
            {
                _database = value;
            }
        }
        #endregion

        #region Ctors
        public Repository(Database database)
        {
            Database = database;
        }
        #endregion

        #region Methods
        public Hashtable GetEntity(string sqlString)
        {
            Hashtable hashTable = Hashtable.Synchronized(new Hashtable());

             // Call the ExecuteReader method by specifying the command type 
            // as a SQL statement, and passing in the SQL statement. 
            using (IDataReader reader = Database.ExecuteReader(CommandType.Text, sqlString))
            {
                // Use the values in the rows as required - here we are just displaying them. 
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string sKey = reader.GetName(i);
                        object Value = reader[i];

                        if (!hashTable.ContainsKey(sKey))
                        {
                            hashTable.Add(sKey, Value);
                        }
                    }
                }
            }

            return hashTable;
        }
        #endregion
    }
}