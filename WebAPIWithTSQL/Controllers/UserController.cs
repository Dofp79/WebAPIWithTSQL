using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIWithTSQL.Data;
using WebAPIWithTSQL.Models;
//https://youtu.be/-rhIFSDgFjk?t=1718    https://github.com/CodigoEstudiante/NO_ProyectoWebAPICSharp/commit/c5a2974366ef33105dadbbc87b3bc1b4aa3e7016#diff-0ca610f8a70ab62b6fe063aa2893552f549feac3704aa88ae63e27c14661d43a
namespace WebAPIWithTSQL.Controllers
{
    /// <summary>
    /// The code provided is for an ASP.NET Web API controller named "UsuarioController" that handles HTTP requests related 
    /// to the "User" entity. This controller provides endpoints for performing CRUD (Create, Read, Update, Delete) operations 
    /// on the "User" entity. 
    /// </summary>
    public class UserController : ApiController
    {
        // GET api/<controller>
        public List<User> Get()
        {
            // GET method that returns a list of all users by calling the Listing method from the UserData class.
            return UserData.Listing();
        }

        // GET api/<controller>/5
        public User Get(int id)
        {
            // GET method that returns a single user by ID by calling the View method from the UserData class.
            return UserData.View(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] User oUser)
        {
            // POST method that handles user registration by calling the Registration method from the UserData class.
            // The User object to be registered is received as a parameter from the request body ([FromBody] attribute).
            return UserData.Registration(oUser);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] User oUser)
        {
            // PUT method that handles user update by calling the Edit method from the UserData class.
            // The updated User object is received as a parameter from the request body ([FromBody] attribute).
            return UserData.Edit(oUser);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            // DELETE method that handles user deletion by calling the Delete method from the UserData class.
            // The ID of the user to be deleted is received as a parameter in the URL.
            return UserData.Delete(id);
        }
    }
}
