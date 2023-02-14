using Bogus;
using Bogus.DataSets;
using Bravi.Application.DTOs;
using Bravi.Application.Responses;
using Bravi.Domain.Enums;
using Bravi.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Tests.Dados_Humanos
{
    public class PessoaBogus : IDisposable
    {
        
        public GenericResponse<PessoaDTO> GerarGenericResponsePessoa()
        {

            var genericResponse = new GenericResponse<PessoaDTO>();
            genericResponse.Data = GerarPessoaValidaComConstrutorBogus();

            return genericResponse;
        }


        /// <summary>
        /// Método para gerar dados aleatórios válidos em uma classe sem construtor definido
        /// </summary>
        /// <returns>Model.Pessoa</returns>
        public PessoaDTO GerarPessoaValidaSemConstrutorBogus()
        {

            var genero = new Faker().PickRandom<Name.Gender>();
            int pessoaId = 0;
            var pessoaFaker = new Faker<PessoaDTO>();
            pessoaFaker.RuleFor(pessoa => pessoa.Id, pessoaId++);
            pessoaFaker.RuleFor(pessoa => pessoa.Nome, (faker, pessoa) => $"{faker.Name.FirstName(genero)} {faker.Name.LastName()}");


            var contatoFaker = new Faker<ContatoDTO>();
            contatoFaker.RuleFor(contato => contato.PessoaId, pessoaId);
            contatoFaker.RuleFor(contato => contato.Tipo, f => f.PickRandom<ContatoTipo>())
                .RuleFor(descricao => descricao.Descricao, (faker, descricao) => ReturnDescricaoTipoContato(descricao.Tipo));

            pessoaFaker.RuleFor(contatos => contatos.Contatos, contatoFaker.Generate(2).ToList());

            var pessoa = pessoaFaker.Generate();

            return pessoa;
        }

        /// <summary>
        /// Método para gerar dados aleatórios válidos em uma classe com construtor definido
        /// </summary>
        /// <returns>Model.Pessoa</returns>
        public PessoaDTO GerarPessoaValidaComConstrutorBogus()
        {

            var genero = new Faker().PickRandom<Name.Gender>();
            int pessoaId = 0;
            var pessoaFaker = new Faker<PessoaDTO>()
                .CustomInstantiator(faker => new PessoaDTO(
                    faker.Name.FirstName())
                );

            var tipoContato = new Faker().PickRandom<ContatoTipo>();
            var contatoFaker = new Faker<ContatoDTO>()
                .CustomInstantiator(faker => new ContatoDTO(
                    tipoContato,
                    ReturnDescricaoTipoContato(tipoContato))
                );
            contatoFaker.RuleFor(contato => contato.PessoaId, pessoaId);

            pessoaFaker.RuleFor(contatos => contatos.Contatos, contatoFaker.Generate(2).ToList());

            var pessoas = pessoaFaker.Generate();

            return pessoas;
        }



        /// <summary>
        /// Método para gerar dados aleatórios inválidos em uma classe sem construtor definido
        /// </summary>
        /// <returns>Model.Pessoa</returns>
        public PessoaDTO GerarPessoaInValidaSemConstrutorBogus()
        {

            var genero = new Faker().PickRandom<Name.Gender>();
            var pessoaFaker = new Faker<PessoaDTO>();
            pessoaFaker.RuleFor(pessoa => pessoa.Nome, (faker, pessoa) => $"{faker.Name.FirstName(genero)} {faker.Name.LastName()}");


            var contatoFaker = new Faker<ContatoDTO>();
            contatoFaker.RuleFor(contato => contato.Tipo, f => f.PickRandom<ContatoTipo>());

            pessoaFaker.RuleFor(contatos => contatos.Contatos, contatoFaker.Generate(2).ToList());

            var pessoa = pessoaFaker.Generate();

            return pessoa;
        }


        private static string ReturnDescricaoTipoContato(ContatoTipo contato)
        {
            if (contato == ContatoTipo.Tefelone)
            {
                return new Bogus.DataSets.PhoneNumbers().PhoneNumber();
            }
            else if (contato == ContatoTipo.Email)
            {
                return new Bogus.DataSets.Internet().Email();
            }
            else
            {
                return new Bogus.DataSets.PhoneNumbers().PhoneNumber();
            }
        }

        public void Dispose()
        {
        }
    }
}
