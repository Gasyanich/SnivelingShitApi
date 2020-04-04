using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnivelingShitApi.DataAccess.Entities
{
    [Table("Film")]
    public class Film
    {
        [Key] public int Id { get; set; }

        [MaxLength(100)] [Required] public string Name { get; set; }

        [MaxLength(50)] [Required] public string Status { get; set; }

        [MaxLength(100)] [Required] public string Genre { get; set; }
    }
}