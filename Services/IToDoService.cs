using BookCatalogUI.Models;

namespace BookCatalogUI.Services
{
    public interface IToDoService
    {
        Task<ToDoDto> AddToDo(ToDoDto dto);
        Task<ToDoDto> EditToDo(int id,ToDoDto dto);
        Task<ToDoDto> GetToDoById(int id);
    }
}
