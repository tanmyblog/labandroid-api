using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    [Table("Restaurants")]
    public class Restaurants
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        [MaxLength(100)]
        public string id { get; set; }

        [Required]
        [MaxLength(100)]
        public string name { get; set; }

        [MaxLength(100)]
        public string address { get; set; }

        [MaxLength(100)]
        public string type { get; set; }
    }
}