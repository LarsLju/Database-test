using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Database_test
{
    class members
    {
        dbConnectionString connectionString = new dbConnectionString();
        private string connexString = dbConnectionString.connectionString;
        private SqlConnection con;
        private SqlCommand command;
    }



}
