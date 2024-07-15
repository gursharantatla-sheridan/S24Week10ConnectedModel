using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S24Week10ConnectedModel
{
    public class Data
    {
        private static string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;";

        public static string ConnectionStr 
        { 
            get { return connStr; } 
        }
    }
}
