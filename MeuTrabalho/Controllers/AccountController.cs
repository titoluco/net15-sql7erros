using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeuTrabalho.Models;
using System.Data.SqlClient;
using Dapper;

namespace MeuTrabalho.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginViewModel model)
        {
            using (SqlConnection connection = new SqlConnection("Server=.;Database=MEUDB;Integrated Security=SSPI"))
            {
                try
                {                    
                    SqlCommand cmd = new SqlCommand("SELECT username FROM tbLogin WHERE email=@email AND pwd=@pwd", connection);
                    cmd.Parameters.AddWithValue("@email", model.Email);
                    cmd.Parameters.AddWithValue("@pwd", model.Password);

                    connection.Open();
                    string username = (string)cmd.ExecuteScalar().ToString();

                    connection.Dispose();
                    //connection.Close();

                    return Redirect($"/Home/Dashboard?name={username}");
                    //return RedirectToAction("Dashboard", "Home", new { name = username});
                }
                catch (Exception ex)
                {
                    return View(model);
                }
            }
        }
    }
}
