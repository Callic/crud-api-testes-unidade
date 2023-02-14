using Bravi.Tests.Dados_Humanos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Tests
{
    public class PessoaTestsBogus : IClassFixture<PessoaBogus>
    {

        private readonly PessoaBogus _pessoaBogus;

        public PessoaTestsBogus(PessoaBogus pessoaBogus)
        {
            _pessoaBogus = pessoaBogus;
        }

        [Fact(DisplayName = "Teste Geração Pessoa Bogus")]
        [Trait("Categoria", "Pessoa Bogus")]
        public void TestarGeracaoPessoa()
        {
            var x = _pessoaBogus.GerarPessoaValidaSemConstrutorBogus();

            Assert.NotNull(x);
        }
    }
}
