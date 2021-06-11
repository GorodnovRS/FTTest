using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTTest.Models
{
    class LinksModel
    {
        [Column("Izdel")]
        public long IzdelId { get; set; } 

        public IzdelModel Izdel { get; set; }
        [Column("IzdelUp")]
        public long IzdelUpId { get; set; }

        public IzdelModel IzdelUp { get; set; }
        
        [Required]
        [Column("Kol")]
        public int Count { get; set; }
    }
}
