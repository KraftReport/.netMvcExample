using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCExample.Web.Features.Book
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Author is required")]
        [StringLength(100, ErrorMessage = "Author cannot exceed 100 characters")]
        public string author  { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be a non-negative number")]
        public int price { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public CATEGORY category { get; set; }
    }
}
