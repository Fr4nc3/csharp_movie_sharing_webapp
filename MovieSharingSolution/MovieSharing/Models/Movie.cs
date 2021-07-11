using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieSharing.Models
{
    public class Movie
    {
        /// <summary>
        /// Gets or sets the movie identifier.
        /// </summary>
        /// <value>The identifier.</value>
        /// 
        [Key, Column(Order = 0)]
        public long ID { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [StringLength(1024), Required]
        public string Title { get; set; }
        [StringLength(256), Required]
        public string Category { get; set; }
        [Display(Name = "Shared User")]
        [StringLength(256)]
        public string SharedWithName { get; set; } = "";
        [Display(Name = "Shared Email")]
        [StringLength(256)]
        public string SharedWithEmailAddress { get; set; } = "";
        [Display(Name = "Shared Date")]
        [DataType(DataType.Date)]
        public DateTime? SharedDate { get; set; } = null;

        [Display(Name = "Is Sharable")]
        public bool IsSharable { get; set; } = true;

        /// <summary>
        /// Gets or sets the owner email identifier.
        /// </summary>
        /// <value>The movie owner email identifier.</value>
        [StringLength(256), Required]
        public string OwnerEmailAddress { get; set; }
        [StringLength(256), Required]
        [Display(Name = "Owner")]
        public string OwnerName { get; set; } = "";

        [StringLength(256)]
        public string Status { get; set; } = "";

    }
}
