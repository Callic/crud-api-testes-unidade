using Bravi.Application.DTOs;
using Bravi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Tests.Fixture
{
    //ESTA CONFIGURAÇÃO É PARA O XUNIT IDENTIFICAR QUE DEVE MANTER O ESTADO DOS OBJETOS GERADOS PELA FIXTURE PessoaFixture
    [CollectionDefinition(nameof(PessoaCollection))]
    public class PessoaCollection : ICollectionFixture<PessoaFixture> { }


    public class PessoaFixture : IDisposable
    {
        public PessoaDTO GerarPessoaValida()
        {
            return new PessoaDTO();
        }
        public void Dispose()
        {
        }
    }
}
