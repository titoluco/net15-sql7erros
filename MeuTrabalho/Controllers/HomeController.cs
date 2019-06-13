using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeuTrabalho.Models;
using MeuTrabalho.Repository;

namespace MeuTrabalho.Controllers
{
    public class HomeController : Controller, IDisposable
    {
        HistoryRepository historyRepository;

        public HomeController(HistoryRepository historyRepository)
        {
            //this.connection = new SqlConnection("Server=.;Database=MEUDB;Integrated Security=SSPI;Max Pool Size=2;Application Name=Teste");
            this.historyRepository = historyRepository;
        }

        public IActionResult Index()
        {
            return RedirectToActionPermanent("Index", "Account");
        }

        public IActionResult Dashboard(string name)
        {
            if( name == null )
            {
                throw new ArgumentNullException(name);
            }

            ViewBag.Name = name;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            try
            {                
                historyRepository.Log("INSERT tbLog VALUES ('about')");
                //using (SqlCommand sql = new SqlCommand("INSERT tbLog VALUES ('about')", this.connection))
                //{
                   // connection.Execute("INSERT tbLog VALUES ('about')");
                //}               
            }
            catch(Exception ex)
            {
                ViewData["Message"] = "ERROR ABOUT";
            }

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            try
            {
                //SqlConnection conn1 = this.connection;
                //conn1.Open();

                //SqlCommand sql = new SqlCommand("INSERT tbLog VALUES ('contact')");
                //sql.Connection = conn1;

                //sql.ExecuteScalar();
                //conn1.Close();
                historyRepository.Log("INSERT tbLog VALUES ('contact')");

            }
            catch(Exception ex)
            {
                return RedirectToAction("Error");
            }

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
