using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieSharing.Models
{
    /// <summary>
    /// category entity
    /// </summary>
    public class Category
    {
        [Key, Column(Order = 0)]
        public long ID { get; set; }
        [StringLength(256), Required]
        public string Name { get; set; }
    }
}
