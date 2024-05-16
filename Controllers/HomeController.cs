using BookCatalogUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BookCatalogUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            //var result = await client.GetAsync("https://localhost:7280/api/Todos");
            var result = await client.GetAsync("https://booksapi.whitedesert-a14a6cd8.uksouth.azurecontainerapps.io/api/Todos");
            var text = await result.Content.ReadAsStringAsync();
            ViewBag.Todos = JsonConvert.DeserializeObject<List<ToDo>>(text);
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