using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(Employee emp)
        {
            string query = $"INSERT INTO Employee(name,email,gender,password) VALUES ('{emp.UserName}','{emp.UserEmail}','{emp.UserGender}','{emp.UserPassword}')";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            return View();
        }       
    }
}