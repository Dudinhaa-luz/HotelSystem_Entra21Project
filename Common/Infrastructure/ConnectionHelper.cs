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
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\entra21\Documents\DBHotelSystem.mdf;Integrated Security=True;Connect Timeout=30";
        }
    }
}
