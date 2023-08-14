using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIWithTSQL.Models
{
    /// <summary>
    /// In this code, we have a class called "User" which represents the model for a user in the application. Each property 
    /// of the class represents an attribute of the user, such as their ID, name, phone number, email, city, and registration 
    /// date.
    /// The "User" class represents the model for a user in the application.
    /// </summary>
    public class User
    {
        // Properties of the "User" class representing the user attributes.
        public int IdUser { get; set; }          // Unique identifier for the user.
        public string IC { get; set; }           // User's IC (Identity Card) number.
        public string Name { get; set; }         // User's name.
        public string Phone { get; set; }        // User's phone number.
        public string Email { get; set; }        // User's email address.
        public string City { get; set; }         // User's city of residence.
        public DateTime RegitrationDate { get; set; } // User's registration date.

        // Other methods or functionalities related to the "Usuario" class can be added here.
    }
}
