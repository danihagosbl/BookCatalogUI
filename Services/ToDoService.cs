using BookCatalogUI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using NuGet.Protocol;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;

namespace BookCatalogUI.Services
{
  
    public class ToDoService : IToDoService
    {
        private static HttpClient sharedClient = new()
        {
            BaseAddress = new Uri("https://booksapi.whitedesert-a14a6cd8.uksouth.azurecontainerapps.io/api/Todos"),
        };

        public async Task<ToDoDto> AddToDo(ToDoDto dto)
        {
            HttpClient client = new HttpClient();
            var result = await client.PostAsJsonAsync<ToDoDto>("https://booksapi.whitedesert-a14a6cd8.uksouth.azurecontainerapps.io/api/Todos", dto);
          
            var final = result.IsSuccessStatusCode;
            if(final)
            {
               // var readTask = result.Content.ReadAsStreamAsync<ToDo>();
            }
            return dto;
            
        }
        public async Task<string> DeleteTodo(int id)
        {
            HttpClient client = new HttpClient();
            var uri = Path.Combine("https://booksapi.whitedesert-a14a6cd8.uksouth.azurecontainerapps.io/api/Todos", id.ToString());
            var result = await client.DeleteAsync(uri);
            var todo = await result.Content.ReadAsStringAsync();
            return todo;
            
        }

        public Task<ToDoDto> GetToDoById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
