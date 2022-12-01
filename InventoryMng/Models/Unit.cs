using System.ComponentModel.DataAnnotations;

namespace InventoryMng.Models
{
    public class Unit
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        [StringLength(70)]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }  
    }
}
