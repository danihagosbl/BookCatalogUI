using BookCatalogUI.Models;
using BookCatalogUI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BookCatalogUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IToDoService _todoService;

        public HomeController(ILogger<HomeController> logger, IToDoService toDoService)
        {
            _logger = logger;
            _todoService = toDoService;
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
        public async Task<IActionResult> AddTodo(ToDoDto todo)
        {
            await _todoService.AddToDo(todo);
            return View();
        }
        public async Task<IActionResult> DeleteTodo(int id)
        {
            await _todoService.DeleteTodo(id);
            return RedirectToAction("Index");
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