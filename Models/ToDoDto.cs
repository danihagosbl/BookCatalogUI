using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookCatalogUI.Models
{
    public class ToDoDto
    {
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
