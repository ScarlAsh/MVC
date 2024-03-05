using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC_day6.ViewModels
{
    public class ProductCustomerViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}
