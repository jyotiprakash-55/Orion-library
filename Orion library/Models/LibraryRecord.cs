namespace Orion_library.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LibraryRecord
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Author1 { get; set; }

        [Required]
        [StringLength(50)]
        public string Author2 { get; set; }

        public DateTime PublishedDate { get; set; }

        public int Pages { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        public string Language { get; set; }

        public string ShelfNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Topics { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime IssuedDate { get; set; }

        public DateTime CreatedOnDateTime { get; set; }

        public int CreatedByUserId { get; set; }

        public int UpdateByUserId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
