using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

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
        public ActionResult Index(DtoEmployee emp)
        {
            string query = $"INSERT INTO Employee(name,email,gender,password) VALUES ('{emp.name}','{emp.email}','{emp.gender}','{emp.password}')";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            return View();
        } 
        
        public ActionResult Show()
        {
            string query = "SELECT * FROM Employee";
            connection.Open();
            DataTable data = new DataTable();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);// fetch multiple data records
            adapter.Fill(data);
            return View(data);
        }

        public ActionResult Single(int? id)
        {
            string query = $"SELECT * FROM Employee WHERE id='{id}'";
            connection.Open();
            DataTable data = new DataTable();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);// fetch multiple data records
            adapter.Fill(data);
            if (data.Rows.Count == 0)
            {
                return RedirectToAction("Show");
            }

            return View(data);
        }

        public ActionResult Edit(int? id)
        {
            string query = $"SELECT * FROM Employee WHERE id='{id}'";
            connection.Open();
            DataTable data = new DataTable();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);// fetch multiple data records
            adapter.Fill(data);
            if (data.Rows.Count == 0)
            {
                return RedirectToAction("Show");
            }
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(int? id,Employee emp)
        {
            string query = $"UPDATE Employee SET name='{emp.name}',email='{emp.email}',gender='{emp.gender}',password='{emp.password}' WHERE id='{id}'";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("Show");
        }

    }
}