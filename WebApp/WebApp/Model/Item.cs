using System.ComponentModel.DataAnnotations;

namespace WebApp.Model
{
    public class Item
    {
        [Key]

        public  int Id { get; set; }

        [Required]

        public string Name { get; set; }

        public string Dealer { get; set; }

        public string ISO { get; set; }

    }
}
