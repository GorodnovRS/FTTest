using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FTTest.Models
{
    class IzdelModel
    {
        [Key]
        public long Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public List<LinksModel> Links { get; set; }

        public List<LinksModel> Components { get; set; }
    }
}
