using Bravi.Domain.Enums;
using System.Text.Json.Serialization;

namespace Bravi.Domain.Models
{
    public class Contato : Entidade
    {
        public Contato() { }    
        public Contato(ContatoTipo contatoTipo, string descricao)
        {
            Tipo = contatoTipo;
            Descricao = descricao;
            
        }
        public ContatoTipo Tipo { get; private set; }
        public string Descricao { get; private set; }
        public int PessoaId { get; set; }
        [JsonIgnore]
        public Pessoa Pessoa { get; set; }
    }
}
