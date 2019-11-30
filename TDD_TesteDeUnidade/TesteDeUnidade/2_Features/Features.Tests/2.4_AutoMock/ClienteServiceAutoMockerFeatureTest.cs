using Features.Clientes;
using MediatR;
using Moq;
using System.Linq;
using System.Threading;
using Xunit;

namespace Features.Tests._2._4_AutoMock
{
    [Collection(nameof(ClienteAutoMockerCollection))]
    public class ClienteServiceAutoMockerFeatureTest
    {
        readonly ClienteTestAutoMockerFixture _clienteTestAutoMockerFeature;
        private readonly ClienteService _clienteService;

        public ClienteServiceAutoMockerFeatureTest(ClienteTestAutoMockerFixture clienteTestBogusFeature)
        {
            _clienteTestAutoMockerFeature = clienteTestBogusFeature;
            _clienteService = _clienteTestAutoMockerFeature.ObterClienteService();
        }

        [Fact(DisplayName = "Adicionar cliente com sucesso")]
        [Trait("Categoria", " Cliente service AutoMockFixture test")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            // Arrange
            var cliente = _clienteTestAutoMockerFeature.GerarClienteValido();

            // Act
            _clienteService.Adicionar(cliente);

            // Assert
            _clienteTestAutoMockerFeature.Mocker.GetMock<IClienteRepository>().Verify(r => r.Adicionar(cliente), Times.Once); // Verificar se o metodo de Adicionar do Repositorio foi chamado  vez
            _clienteTestAutoMockerFeature.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once); // Verificar se o metodo publish foi chamado e se o q foi enviado herda de INotification
        }

        [Fact(DisplayName = "Adicionar cliente com falha")]
        [Trait("Categoria", " Cliente service AutoMockFixture test")]
        public void ClienteService_Adicionar_DeveFalharDevidoClienteInvalido()
        {
            // Arrange
            var cliente = _clienteTestAutoMockerFeature.GerarClienteInvalido();

            // Act
            _clienteService.Adicionar(cliente);

            // Assert
            _clienteTestAutoMockerFeature.Mocker.GetMock<IClienteService>().Verify(r => r.Adicionar(cliente), Times.Never); // Verificar se o metodo de Adicionar do Repositorio nao foi chamado
            _clienteTestAutoMockerFeature.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never); // Verificar se o metodo publish nao foi chamado e se o q foi enviado herda de INotification
        }

        [Fact(DisplayName = "Obter clientes ativos")]
        [Trait("Categoria", "Cliente service AutoMockFixture teste")]
        public void ClienteService_ObterTodosAtivos_DeveRetornarApenasClientesAtivos()
        {
            // Arrange
            _clienteTestAutoMockerFeature.Mocker.GetMock<IClienteRepository>().Setup(c => c.ObterTodos()) // Quando o metodo ObterTodos for chamado, sera envocado o ObterClientesVariados
                .Returns(_clienteTestAutoMockerFeature.ObterClientesVariados());

            // Act
            var clientes = _clienteService.ObterTodosAtivos();

            // Assert
            _clienteTestAutoMockerFeature.Mocker.GetMock<IClienteRepository>().Verify(m => m.ObterTodos(), Times.Once); // Verificar se chamou pelo menos uma vez o metodo ObterTodos
            Assert.True(clientes.Any()); // Se existe algum cliente
            Assert.False(clientes.Count(c => !c.Ativo) > 0); // Se existe pelo um cliente ativo 
        }
    }
}
