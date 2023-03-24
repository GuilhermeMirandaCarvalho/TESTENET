using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class CidadeDTO
    {
        public int CidadeId { get; set; }

        public string? Nome { get; set; }

        public string? Uf { get; set; }

    }
}
