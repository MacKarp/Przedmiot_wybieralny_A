using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zadanie_6
{
    [Table("Books")]
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(30)]
        public string Publisher { get; set; }
    }
}