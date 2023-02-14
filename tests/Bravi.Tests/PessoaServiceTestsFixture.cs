using AutoMapper;
using Bravi.Application.Services;
using Bravi.Domain.Interfaces;
using Bravi.Domain.Models;
using Bravi.Tests.Fixture;
using Moq;
namespace Bravi.Tests
{
    //TAMBÉM ADICIONAMOS A CollectionDefinition AQUI PARA O XUNIT SABER QUE ESTÁ CLASSE ESTÁ UTILIZANDO A PESSOAFIXTURE E POR ESTE MOTIVO DEVE SALVAR O ESTADO DOS OBJETOS QUE AQUI SERÃO MANIPULADOS
    [Collection(nameof(PessoaCollection))]
    public class PessoaServiceTestsFixture
    {
        
        PessoaFixture _pessoaFixture;

        public PessoaServiceTestsFixture(PessoaFixture pessoaFixture)
        {
            _pessoaFixture = pessoaFixture;
        }

        [Fact(DisplayName = "Nova Pessoa Válida")]
        [Trait("Categoria", "Pessoa Testes Utilizando Fixture")]
        public void Fixture_Pessoa_Adicionar_Valido()
        {
            //arrange
            var pessoa = _pessoaFixture.GerarPessoaValida();
            var pessoaRepo = new Mock<IPessoaRepository>();
            var UoF = new Mock<IUnitOfWork>();
            var _mapper = new Mock<IMapper>();

            var pessoaService = new PessoaService(UoF.Object, _mapper.Object);

            //act
            var result = pessoaService.Adicionar(pessoa);

            //assert
            Assert.NotNull(result);
            pessoaRepo.Verify(p => p.Adicionar(_mapper.Object.Map<Pessoa>(pessoa)),Times.Once());
        }
    }
}
