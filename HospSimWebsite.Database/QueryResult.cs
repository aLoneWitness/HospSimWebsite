using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HospSimWebsite.Database
{
    namespace HospSimWebsite
    {
        public class QueryResult
        {
            public List<KeyValuePair<string, object>> Properties { get; private set; } = new List<KeyValuePair<string, object>>();

            public object this[string property]
            {
                get
                {
                    return Properties.Find(x => x.Key == property).Value;
                }
            }

            public QueryResult(MySqlDataReader DataReader)
            {
                for (int ordinal = 0; ordinal < DataReader.FieldCount; ++ordinal)
                    Properties.Add(DataReader.GetValue(ordinal).GetType().ToString() != "System.DBNull" ? new KeyValuePair<string, object>(DataReader.GetName(ordinal), DataReader.GetValue(ordinal)) : new KeyValuePair<string, object>(DataReader.GetName(ordinal), ""));
            }
        }
    }
}