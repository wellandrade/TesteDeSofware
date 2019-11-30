using Features.Clientes;
using Features.Tests._2._2_DadosHumanos;
using MediatR;
using Moq;
using System.Threading;
using Xunit;
using System.Linq;
using Moq.AutoMock;

namespace Features.Tests._2._4_AutoMock
{
    [Collection(nameof(ClienteBogusCollection))]
    public class ClienteServiceAutoMockerTest
    {
        readonly ClienteTestBogusFeature _clienteTestBogusFeature;

        public ClienteServiceAutoMockerTest(ClienteTestBogusFeature clienteTestBogusFeature)
        {
            _clienteTestBogusFeature = clienteTestBogusFeature;
        }

        [Fact(DisplayName = "Adicionar cliente com sucesso")]
        [Trait("Categoria", " Cliente service AutoMock test")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            // Arrange
            var cliente = _clienteTestBogusFeature.GerarClienteValido();
            var mocker = new AutoMocker();

            var clienteService = mocker.CreateInstance<ClienteService>(); // Ja cria o mock com a resolução de todas as interfaces

            // Act
            clienteService.Adicionar(cliente);

            // Assert
            mocker.GetMock<IClienteRepository>().Verify(r => r.Adicionar(cliente), Times.Once); // Verificar se o metodo de Adicionar do Repositorio foi chamado  vez
            mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once); // Verificar se o metodo publish foi chamado e se o q foi enviado herda de INotification
        }

        [Fact(DisplayName = "Adicionar cliente com falha")]
        [Trait("Categoria", " Cliente service AutoMock test")]
        public void ClienteService_Adicionar_DeveFalharDevidoClienteInvalido()
        {
            // Arrange
            var cliente = _clienteTestBogusFeature.GerarClienteInvalido();
            var mocker = new AutoMocker();
            var clienteService = mocker.CreateInstance<ClienteService>();

            // Act
            clienteService.Adicionar(cliente);

            // Assert
            mocker.GetMock<IClienteService>().Verify(r => r.Adicionar(cliente), Times.Never); // Verificar se o metodo de Adicionar do Repositorio nao foi chamado
            mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never); // Verificar se o metodo publish nao foi chamado e se o q foi enviado herda de INotification
        }

        [Fact(DisplayName = "Obter clientes ativos")]
        [Trait("Categoria", "Cliente service AutoMock teste")]
        public void ClienteService_ObterTodosAtivos_DeveRetornarApenasClientesAtivos()
        {
            // Arrange
            var mocker = new AutoMocker();
            var clienteService = mocker.CreateInstance<ClienteService>();

            mocker.GetMock<IClienteRepository>().Setup(c => c.ObterTodos()) // Quando o metodo ObterTodos for chamado, sera envocado o ObterClientesVariados
                .Returns(_clienteTestBogusFeature.ObterClientesVariados());

            // Act
            var clientes = clienteService.ObterTodosAtivos();

            // Assert
            mocker.GetMock<IClienteRepository>().Verify(m => m.ObterTodos(), Times.Once); // Verificar se chamou pelo menos uma vez o metodo ObterTodos
            Assert.True(clientes.Any()); // Se existe algum cliente
            Assert.False(clientes.Count(c => !c.Ativo) > 0); // Se existe pelo um cliente ativo 
        }
    }
}
