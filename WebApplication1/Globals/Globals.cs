using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
namespace WebApplication1.Globals
{
    public class SQL
    {
        public MySqlConnection con = new MySqlConnection("Server = localhost; Database=technobilesen;user=root;pwd='';");
        public MySqlCommand cmd = new MySqlCommand();
    }
    public class Globals
    {

    }
}