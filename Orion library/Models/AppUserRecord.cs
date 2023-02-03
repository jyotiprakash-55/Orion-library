namespace Orion_library.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AppUserRecord
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Enter Your UserName")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Enter Your Password")]
        public string Password { get; set; }

        public bool isAdmin { get; set; }
    }
}
