using Bravi.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Bravi.Application.DTOs
{
    public class ContatoDTO
    {
        public ContatoDTO()
        {

        }
        public ContatoDTO(ContatoTipo contatoTipo, string descricao)
        {
            Tipo= contatoTipo;
            Descricao= descricao;  
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public ContatoTipo Tipo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int PessoaId { get; set; }
    }
}
