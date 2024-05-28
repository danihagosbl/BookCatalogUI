using BookCatalogUI.Models;

namespace BookCatalogUI.Services
{
    public interface IToDoService
    {
        Task<ToDoDto> AddToDo(ToDoDto dto);
    }
}
