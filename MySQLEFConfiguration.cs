using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShunUT
{
    public class MySQLEFConfiguration : DbConfiguration
    {
        public MySQLEFConfiguration()
        {
            SetHistoryContext("MySql.Data.MySqlClient",
                (conn, schema)=> new MySql.Data.Entity.MySqlHistoryContext(conn, schema));
        }
    }
}
