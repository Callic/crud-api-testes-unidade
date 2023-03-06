using Bravi.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Bravi.Application.DTOs
{
    public class PessoaDTO
    {
        public PessoaDTO()
        {

        }
        public PessoaDTO(string nome)
        {
            Nome= nome;
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        public IEnumerable<ContatoDTO>? Contatos { get; set; } = new List<ContatoDTO>();


    }
}
