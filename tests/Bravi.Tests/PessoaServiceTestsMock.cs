using AutoMapper;
using Bravi.Application.Configuration;
using Bravi.Application.DTOs;
using Bravi.Application.Services;
using Bravi.Domain.Interfaces;
using Bravi.Domain.Models;
using Bravi.Infra.Context;
using Bravi.Tests.Dados_Humanos;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.AutoMock;
using Xunit.Abstractions;

namespace Bravi.Tests
{
    public class PessoaServiceTestsMock : IClassFixture<PessoaBogus>
    {

        private readonly PessoaBogus _pessoaBogus;
        private MapperConfiguration MapperMock;
        readonly ITestOutputHelper _outputHelper;

        public PessoaServiceTestsMock(PessoaBogus pessoaBogus, ITestOutputHelper outputHelper)
        {
            _pessoaBogus = pessoaBogus;
            MapperMock = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutomapperConfig());
            });
            _outputHelper = outputHelper;
        }

        [Fact(DisplayName ="Adicionar Pessoa Válida Mock")]
        [Trait("Categoria", "Pessoa Service Mock")]
        public async void Pessoa_Adicionar_Valido()
        {
            //arrange
            var genericResponse= _pessoaBogus.GerarGenericResponsePessoa();
            
            var _mapper = MapperMock.CreateMapper();

            var pessoaRepo = new Mock<IPessoaRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();
            
            unitOfWork.Setup(uow => uow.PessoaRepository).Returns(pessoaRepo.Object);
            unitOfWork.Setup(uow => uow.Commit()).ReturnsAsync(true);
            
            var pessoaService = new PessoaService(unitOfWork.Object, _mapper);

            //act
            var result = await pessoaService.Adicionar(genericResponse.Data!);

            //assert
            pessoaRepo.Verify(p => p.Adicionar(It.IsAny<Pessoa>()), Times.Once);
            Assert.NotNull(result.Data);
        }



        // TODO: Voltar aqui para rever a parte de integração, e testar mais o retorno da API tbm
        [Fact(DisplayName = "Adicionar Pessoa Inválida Mock")]
        [Trait("Categoria", "Pessoa Service Mock")]
        public async void Pessoa_Adicionar_Invalido()
        {
            //arrange
            var pessoa = _pessoaBogus.GerarPessoaInValidaSemConstrutorBogus();
            var pessoaRepo = new Mock<IPessoaRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var _mapper = new Mock<IMapper>();
            unitOfWork.Setup(uow => uow.PessoaRepository).Returns(pessoaRepo.Object);
            unitOfWork.Setup(uow => uow.Commit()).ReturnsAsync(false);

            var pessoaService = new PessoaService(unitOfWork.Object, _mapper.Object);

            //act
            var result = await pessoaService.Adicionar(pessoa);

            //assert
            Assert.Equal(0, result.Data!.Id);
            pessoaRepo.Verify(p => p.Adicionar(_mapper.Object.Map<Pessoa>(pessoa)), Times.Once());
        }



        [Fact(DisplayName = "Adicionar Pessoa Válida AutoMock")]
        [Trait("Categoria", "Pessoa Service AutoMock")]
        public async void Pessoa_Adicionar_Valido_AutoMock()
        {
            //arrange
            var pessoa = _pessoaBogus.GerarPessoaValidaSemConstrutorBogus();

            var mocker = new AutoMocker();
            var _mapper = MapperMock.CreateMapper();
            mocker.Use<IMapper>(_mapper);
            var pessoaService = mocker.CreateInstance<PessoaService>();

            

            mocker.GetMock<IUnitOfWork>().Setup(uow => uow.PessoaRepository).Returns(mocker.GetMock<IPessoaRepository>().Object);
            mocker.GetMock<IUnitOfWork>().Setup(uow => uow.Commit()).ReturnsAsync(true);

            //act
            var result = await pessoaService.Adicionar(pessoa);

            //assert
            mocker.GetMock<IPessoaRepository>().Verify(p => p.Adicionar(It.IsAny<Pessoa>()), Times.Once);
            //Assert.NotNull(result);

            //UTILIZANDO FLUENT ASSERTIONS -> https://fluentassertions.com/
            result.Data.Should().NotBeNull();
            result.Erros.Should().BeEmpty(because: "Não deve conter erros (mensagem teste)");
            _outputHelper.WriteLine("Mensagem de saída caso algum dia eu precise usar");
        }
    }
}
