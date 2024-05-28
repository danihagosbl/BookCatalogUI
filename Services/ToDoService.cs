using BookCatalogUI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection.Metadata.Ecma335;

namespace BookCatalogUI.Services
{
    public class ToDoService : IToDoService
    {
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
    }
}
