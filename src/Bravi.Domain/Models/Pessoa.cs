using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Models
{
    public class Pessoa : Entidade
    {
        public Pessoa() { }

        public Pessoa(string nome)
        {
            Nome = nome;
        }
        public string Nome { get; private set; }
        public ICollection<Contato> Contatos { get; set; }
    }
}
