using Features.Clientes;
using Features.Tests._2._4_AutoMock;
using Xunit;
using Xunit.Abstractions;

namespace Features.Tests._2._5_FluentAssertion
{
    [Collection(nameof(ClienteAutoMockerCollection))]
    public class ClienteFluentAssertionsTest
    {
        private readonly ClienteTestAutoMockerFixture _clienteTestAutoMockerFixture;
        private ITestOutputHelper _testOutputHelper;

        private readonly ClienteService _clienteService;

        public ClienteFluentAssertionsTest(ClienteTestAutoMockerFixture clienteTestAutoMockerFixture, ITestOutputHelper testOutputHelper)
        {
            _clienteTestAutoMockerFixture = clienteTestAutoMockerFixture;
            _testOutputHelper = testOutputHelper;
            _clienteService = _clienteTestAutoMockerFixture.ObterClienteService();
        }

        [Fact(DisplayName = "Novo Cliente Válido", Skip = "Pulando teste")]
        [Trait("Categoria", "Cliente Fixture Testes")]
        public void Cliente_NovoCliente_DeveEstarValido()
        {
            // Arrange
            var cliente = _clienteTestAutoMockerFixture.GerarClienteValido();

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.True(result);
            Assert.NotEqual(0, cliente.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "Novo Cliente Válido")]
        [Trait("Categoria", "Cliente Fixture Testes")]
        public void Cliente_NovoCliente_DeveEstarInvalido()
        {
            // Arrange
            var cliente = _clienteTestAutoMockerFixture.GerarClienteInvalido();

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.False(result);
            Assert.NotEqual(0, cliente.ValidationResult.Errors.Count);

            _testOutputHelper.WriteLine($"Foram encontrados { cliente.ValidationResult.Errors.Count } nesse teste");
        }
    }
}
