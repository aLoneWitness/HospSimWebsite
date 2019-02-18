using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospSimWebsite
{
    public class QueryResult
    {
        public List<KeyValuePair<string, object>> Properties { get; } =
            new List<KeyValuePair<string, object>>();

        public object this[string property] {
            get { return Properties.Find(x => x.Key == property).Value; }
        }

        public QueryResult(MySqlDataReader dataReader)
        {
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                Properties.Add(dataReader.GetValue(i).GetType().ToString() != "System.DBNull"
                    ? new KeyValuePair<string, object>(dataReader.GetName(i), dataReader.GetValue(i))
                    : new KeyValuePair<string, object>(dataReader.GetName(i), ""));
            }
        }
    }
}
