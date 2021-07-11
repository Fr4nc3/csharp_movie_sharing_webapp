using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieSharing.Models
{
    // imperson entity
    public class Imperson
    {
        [Key, Column(Order = 0)]
        public long ID { get; set; }
        [StringLength(256), Required]
        public string Email { get; set; }
        [StringLength(256), Required]
        public string Name { get; set; }
    }
}
