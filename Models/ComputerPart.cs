using System.ComponentModel.DataAnnotations;
namespace ComputerPart.Models
{
    public class ComputerPart
    {
        public int Id{get; set;}
         
         [Required]
         public string PartName{get; set;}

         [Required]
         public string Category{get; set;}

         [Required]
         public int Price {get; set;}

         [Required]
         [Range(1, 1000)]
         public int Quantity {get; set;}
    }
}
