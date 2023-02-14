using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Tests
{

    public class EscapandoTeste
    {
        [Fact(DisplayName = "Teste Versão Antiga Teste", Skip = "Pular teste versão antiga")]
        [Trait("Categoria", "Pular Teste")]
        public void Pular_Teste_Falhando_Propositalmente()
        {
            Assert.True(false);
        }
    }
}
