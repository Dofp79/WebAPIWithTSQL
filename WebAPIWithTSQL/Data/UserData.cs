
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using WebAPIWithTSQL.Models;

namespace WebAPIWithTSQL.Data
{
    public class UserData
    {
        /// <summary>
        /// The "Registration" method is used to register a new user in the database. It takes a "User" object as a 
        /// parameter, which contains the user's information.
        /// </summary>
        /// <param name="oUser"></param>
        // <returns></returns>       
        public static bool Registration(User oUser)
        {
            // Using block ensures that the SqlConnection is properly closed and disposed after use.
            using (SqlConnection oConexion = new SqlConnection(Conexion.stringConexion))
            {
                // Create a new SqlCommand object to execute the stored procedure "sp_Registration".
                SqlCommand cmd = new SqlCommand("sp_Registration", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Add parameters to the SqlCommand for the stored procedure.     
                cmd.Parameters.AddWithValue("@IC", oUser.IC);
                cmd.Parameters.AddWithValue("@Name", oUser.Name);   
                cmd.Parameters.AddWithValue("@Phone", oUser.Phone); 
                cmd.Parameters.AddWithValue("@Email", oUser.Email); 
                cmd.Parameters.AddWithValue("@City", oUser.City);   

                try
                {
                    // Open the database connection.
                    oConexion.Open();

                    // Execute the stored procedure using cmd.ExecuteNonQuery() since we are not expecting a return value.
                    cmd.ExecuteNonQuery();

                    // If the registration is successful, return true.
                    return true;
                }
                catch (Exception ex)
                {
                    // If an exception occurs during the registration process, return false.
                    // In a real application, you may want to log the error for debugging purposes.
                    return false;
                }
            }
        }
        /// <summary>
        /// The Edit method is used to modify (update) an existing user's information in the database.
        /// </summary>
        /// <param name="oUser"></param>
        /// <returns></returns>
        public static bool Edit(User oUser)
        {
                 
            using (SqlConnection oConexion = new SqlConnection(Conexion.stringConexion))
            {
                // Create a new SqlCommand object to execute the stored procedure "sp_Edit".
                SqlCommand cmd = new SqlCommand("sp_Edit", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Add parameters to the SqlCommand for the stored procedure.
                cmd.Parameters.AddWithValue("@IdUser", oUser.IdUser); 
                cmd.Parameters.AddWithValue("@IC", oUser.IC);         
                cmd.Parameters.AddWithValue("@Name", oUser.Name);     
                cmd.Parameters.AddWithValue("@Phone", oUser.Phone);   
                cmd.Parameters.AddWithValue("@Email", oUser.Email);   
                cmd.Parameters.AddWithValue("@City", oUser.City);     

                try
                {
                    // Open the database connection.
                    oConexion.Open();

                    // Execute the stored procedure using cmd.ExecuteNonQuery() since we are not expecting a return value.
                    cmd.ExecuteNonQuery();

                    // If the modification is successful, return true.
                    return true;
                }
                catch (Exception ex)
                {
                    // If an exception occurs during the modification process, return false.
                    // In a real application, you may want to log the error for debugging purposes.
                    return false;
                }
            }
        }

        /// <summary>
        /// In the provided code, the Listing method is used to retrieve a list of users from the database.
        /// </summary>
        /// <returns></returns>
        public static List<User> Listing()
        {
            // Create a list to hold the User objects retrieved from the database.
            List<User> oListaUsuario = new List<User>();

            // Using block ensures that the SqlConnection is properly closed and disposed after use.
            using (SqlConnection oConexion = new SqlConnection(Conexion.stringConexion))
            {
                // Create a new SqlCommand object to execute the stored procedure "sp_Listing".
                SqlCommand cmd = new SqlCommand("sp_Listing", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                try
                {
                    // Open the database connection.
                    oConexion.Open();

                    // Execute the stored procedure using cmd.ExecuteNonQuery() since we are not expecting a return value.
                    cmd.ExecuteNonQuery();

                    // Use SqlDataReader to read the results of the stored procedure.
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // Loop through the SqlDataReader and create User objects from the retrieved data.
                        while (dr.Read())
                        {
                            oListaUsuario.Add(new User()
                            {
                                IdUser = Convert.ToInt32(dr["IdUser"]),
                                IC = dr["IC"].ToString(),
                                Name = dr["Name"].ToString(),
                                Phone = dr["Phone"].ToString(), 
                                Email = dr["Email"].ToString(),
                                City = dr["City"].ToString(),
                                RegitrationDate = Convert.ToDateTime(dr["RegitrationDate"].ToString())
                            });
                        }
                    }

                    // Return the list of User objects populated with data from the database.
                    return oListaUsuario;
                }
                catch (Exception ex)
                {
                    // If an exception occurs while retrieving data from the database, return an empty list.
                    // In a real application, you may want to log the error for debugging purposes.
                    return oListaUsuario;
                }
            }
        }

        /// <summary>
        /// The View method is used to retrieve a single user from the database based on their IdUser.
        /// </summary>
        /// <param name="IdUser"></param>
        /// <returns></returns>
        public static User View(int IdUser)
        {
            // Create a new User object to hold the user retrieved from the database.
            User oUser = new User();

            // Using block ensures that the SqlConnection is properly closed and disposed after use.
            using (SqlConnection oConexion = new SqlConnection(Conexion.stringConexion))
            {
                // Create a new SqlCommand object to execute the stored procedure "sp_View".
                SqlCommand sqlCommand = new SqlCommand("sp_View", oConexion);
                SqlCommand cmd = sqlCommand;
                cmd.CommandType = CommandType.StoredProcedure;

                // Add the parameter "@IdUser" to the SqlCommand to pass the user's ID to the stored procedure.
                cmd.Parameters.AddWithValue("@IdUser", IdUser);

                try
                {
                    // Open the database connection.
                    oConexion.Open();

                    // Execute the stored procedure using cmd.ExecuteNonQuery() since we are not expecting a return value.
                    cmd.ExecuteNonQuery();

                    // Use SqlDataReader to read the results of the stored procedure.
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // Loop through the SqlDataReader to read the data of the single user.
                        while (dr.Read())
                        {
                            oUser = new User()
                            {
                                IdUser = Convert.ToInt32(dr["IdUser"]),
                                IC = dr["IC"].ToString(),
                                Name = dr["Name"].ToString(),
                                Phone = dr["Phone"].ToString(),
                                Email = dr["Email"].ToString(),
                                City = dr["City"].ToString(),
                                RegitrationDate = Convert.ToDateTime(dr["RegitrationDate"].ToString())
                            };
                        }
                    }

                    // Return the User object containing the data of the retrieved user.
                    return oUser;
                }
                catch (Exception ex)
                {
                    // If an exception occurs while retrieving data from the database, return an empty User object.
                    // In a real application, you may want to log the error for debugging purposes.
                    return oUser;
                }
            }
        }

        /// <summary>
        /// The Delete method is used to delete a user from the database based on their IdUser.
        /// </summary>
        /// <param name="IdUser"></param>
        /// <returns></returns>
        public static bool Delete(int IdUser)
        {
            // Using block ensures that the SqlConnection is properly closed and disposed after use.
            using (SqlConnection oConexion = new SqlConnection(Conexion.stringConexion))
            {
                // Create a new SqlCommand object to execute the stored procedure "sp_Delete".
                SqlCommand cmd = new SqlCommand("sp_Delete", oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Add the parameter "@IdUser" to the SqlCommand to pass the user's ID to the stored procedure.
                cmd.Parameters.AddWithValue("@IdUser", IdUser);

                try
                {
                    // Open the database connection.
                    oConexion.Open();

                    // Execute the stored procedure using cmd.ExecuteNonQuery() to perform the delete operation.
                    cmd.ExecuteNonQuery();

                    // Return true to indicate that the delete operation was successful.
                    return true;
                }
                catch (Exception ex)
                {
                    // If an exception occurs while executing the stored procedure, return false to indicate that the delete operation failed.
                    // In a real application, you may want to log the error for debugging purposes.
                    return false;
                }
            }
        }
    }
}