using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Cidades")]
    public class Cidade
    {
        [Key]
        public int CidadeId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(2)]
        public string? Uf { get; set; }
     }
}
