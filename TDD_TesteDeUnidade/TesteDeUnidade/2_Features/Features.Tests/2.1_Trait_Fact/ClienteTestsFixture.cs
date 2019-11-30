using Bogus;
using Features.Clientes;
using System;
using Xunit;

namespace Features.Tests
{
    [CollectionDefinition(nameof(ClienteCollection))]
    public class ClienteCollection : ICollectionFixture<ClienteTestsFixture>
    { }

    public class ClienteTestsFixture : IDisposable
    {
        public Cliente GerarClienteValido()
        {
            var cliente = new Faker<Cliente>("pt_BR") // Gerar dados em portugues/ CustomInstantiator para usar o construtor da classe 
                              .CustomInstantiator(f => new Cliente(
                                Guid.NewGuid(),
                                f.Name.FirstName(null),
                                f.Name.LastName(null),
                                f.Date.Past(80, DateTime.Now.AddYears(-18)),
                                "",
                                true,
                                DateTime.Now))
                              .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLower())); // Regra para gerar o email com base no nome e sobrenome

            return cliente;
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

        public void Dispose()
        {
        }
    }
}