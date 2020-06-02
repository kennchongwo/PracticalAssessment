using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PracticalAssessment.Data;
using PracticalAssessment.Models;

namespace PracticalAssessment.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            foreach (var itemm in _context.GeoData)
            {
                _context.GeoData.Remove(itemm);
                _context.SaveChanges();
                
            }

                List<GeogData> geogdata = new List<GeogData>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://geodata.grid.unep.ch/api/countries/KE/variables/331"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    geogdata = JsonConvert.DeserializeObject<List<GeogData>>(apiResponse);
                }
            }
            foreach(var item in geogdata)
            {
                GeoData data = new GeoData
                {
                    iso2 = "KE" ,
                    Value = item.Value,
                    year = item.year
                };
                _context.GeoData.Add(data);
                _context.SaveChanges();

            }

            return View(geogdata);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
