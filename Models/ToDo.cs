using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookCatalogUI.Models
{
    public class ToDo
    {
        public int ID { get; set; }
        public string? Description { get; set; }

        [DisplayName("Created Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
    }
}
