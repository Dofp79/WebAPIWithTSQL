using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIWithTSQL.Data
{
    /// <summary>
    /// The "Conexion" class represents a static class for storing the connection string to the database.
    /// </summary>
    public class Conexion
    {
        // The static variable "rutaConexion" holds the connection string to the database.
        // The connection string specifies the server, database name, and integrated security settings for accessing the database.
        public static string stringConexion = "Data Source=(local);Initial Catalog=UserDB;Integrated Security=True";

        // Other methods or functionalities related to the database connection can be added here if needed.
    }
}
