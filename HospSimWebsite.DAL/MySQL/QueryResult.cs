using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HospSimWebsite.DAL.MySQL
{
    namespace HospSimWebsite
    {
        public class QueryResult
        {
            public QueryResult(MySqlDataReader DataReader)
            {
                for (var ordinal = 0; ordinal < DataReader.FieldCount; ++ordinal)
                    Properties.Add(DataReader.GetValue(ordinal).GetType().ToString() != "System.DBNull"
                        ? new KeyValuePair<string, object>(DataReader.GetName(ordinal), DataReader.GetValue(ordinal))
                        : new KeyValuePair<string, object>(DataReader.GetName(ordinal), ""));
            }

            public List<KeyValuePair<string, object>> Properties { get; } = new List<KeyValuePair<string, object>>();

            public object this[string property]
            {
                get { return Properties.Find(x => x.Key == property).Value; }
            }
        }
    }
}