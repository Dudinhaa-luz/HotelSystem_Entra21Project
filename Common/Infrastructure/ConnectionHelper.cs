using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Infrastructure
{
    public class ConnectionHelper
    {
        public static string GetConnectionString()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dudinha\Documents\DbHotel.mdf;Integrated Security=True;Connect Timeout=30";
        }
    }
}
