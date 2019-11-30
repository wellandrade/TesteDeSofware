using Bogus;
using Features.Clientes;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using Moq.AutoMock;

namespace Features.Tests._2._4_AutoMock
{
    [CollectionDefinition(nameof(ClienteAutoMockerCollection))]
    public class ClienteAutoMockerCollection : ICollectionFixture<ClienteTestAutoMockerFixture>
    {

    }

    public class ClienteTestAutoMockerFixture : IDisposable
    {
        public ClienteService ClienteService;
        public AutoMocker Mocker;

        public Cliente GerarClienteValido()
        {
            return GerarClientes(1, true).FirstOrDefault();
        }

        public IEnumerable<Cliente> ObterClientesVariados()
        {
            var clientes = new List<Cliente>();

            clientes.AddRange(GerarClientes(50, true).ToList());
            clientes.AddRange(GerarClientes(50, false).ToList());

            return clientes;
        }

        public Cliente GerarClienteInvalido()
        {
            var cliente = new Faker<Cliente>("pt_BR") // Gerar dados em portugues/ CustomInstantiator para usar o construtor da classe 
                              .CustomInstantiator(f => new Cliente(
                                  Guid.NewGuid(),
                                  f.Name.FirstName(null),
                                  f.Name.LastName(null),
                                  f.Date.Past(17, DateTime.Now.AddYears(-1)),
                                  "",
                                  true,
                                  DateTime.Now));

            return cliente;
        }

        public IEnumerable<Cliente> GerarClientes(int quantidade, bool ativo)
        {
            var clientes = new Faker<Cliente>("pt_BR") // Gerar dados em portugues/ CustomInstantiator para usar o construtor da classe 
                              .CustomInstantiator(f => new Cliente(
                                Guid.NewGuid(),
                                f.Name.FirstName(null),
                                f.Name.LastName(null),
                                f.Date.Past(80, DateTime.Now.AddYears(-18)),
                                "",
                                ativo,
                                DateTime.Now))
                              .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLower())); // Regra para gerar o email com base no nome e sobrenome

            return clientes.Generate(quantidade);
        }

        public ClienteService ObterClienteService()
        {
            Mocker = new AutoMocker();
            ClienteService = Mocker.CreateInstance<ClienteService>();

            return ClienteService;
        }

        public void Dispose()
        {
        }
    }
}
