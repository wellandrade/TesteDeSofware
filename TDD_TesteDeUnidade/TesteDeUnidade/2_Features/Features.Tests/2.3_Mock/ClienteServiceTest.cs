using Features.Clientes;
using Features.Tests._2._2_DadosHumanos;
using MediatR;
using Moq;
using System.Threading;
using Xunit;
using System.Linq;

namespace Features.Tests._2._2_Mock
{
    [Collection(nameof(ClienteBogusCollection))]
    public class ClienteServiceTest
    {
        readonly ClienteTestBogusFeature _clienteTestBogusFeature;

        public ClienteServiceTest(ClienteTestBogusFeature clienteTestBogusFeature)
        {
            _clienteTestBogusFeature = clienteTestBogusFeature;
        }

        [Fact(DisplayName = "Adicionar cliente com sucesso")]
        [Trait("Categoria", " Cliente service mock test")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            // Arrange
            var cliente = _clienteTestBogusFeature.GerarClienteValido();
            var clienteRepoMock = new Mock<IClienteRepository>(); // Criando mock do IClienteRepository
            var mediatorMock = new Mock<IMediator>();
            var clienteServices = new ClienteService(clienteRepoMock.Object, mediatorMock.Object); // Para acessar o objeto que foi "mockado"

            // Act
            clienteServices.Adicionar(cliente);

            // Assert
            clienteRepoMock.Verify(r => r.Adicionar(cliente), Times.Once); // Verificar se o metodo de Adicionar do Repositorio foi chamado  vez
            mediatorMock.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once); // Verificar se o metodo publish foi chamado e se o q foi enviado herda de INotification

        }

        [Fact(DisplayName = "Adicionar cliente com falha")]
        [Trait("Categoria", " Cliente service mock test")]
        public void ClienteService_Adicionar_DeveFalharDevidoClienteInvalido()
        {
            // Arrange
            var cliente = _clienteTestBogusFeature.GerarClienteInvalido();
            var clienteRepoMock = new Mock<IClienteRepository>(); // Criando mock do IClienteRepository
            var mediatorMock = new Mock<IMediator>();
            var clienteServices = new ClienteService(clienteRepoMock.Object, mediatorMock.Object); // Para acessar o objeto que foi "mockado"

            // Act
            clienteServices.Adicionar(cliente);

            // Assert
            clienteRepoMock.Verify(r => r.Adicionar(cliente), Times.Never); // Verificar se o metodo de Adicionar do Repositorio nao foi chamado
            mediatorMock.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never); // Verificar se o metodo publish nao foi chamado e se o q foi enviado herda de INotification

        }

        [Fact(DisplayName = "Obter clientes ativos")]
        [Trait("Categoria", "Cliente service mock teste")]
        public void ClienteService_ObterTodosAtivos_DeveRetornarApenasClientesAtivos()
        {
            // Arrange
            var clienteRepo = new Mock<IClienteRepository>();
            var mediatorMock = new Mock<IMediator>();

            clienteRepo.Setup(c => c.ObterTodos()) // Quando o metodo ObterTodos for chamado, sera envocado o ObterClientesVariados
                .Returns(_clienteTestBogusFeature.ObterClientesVariados());

            var clienteService = new ClienteService(clienteRepo.Object, mediatorMock.Object);

            // Act
            var clientes = clienteService.ObterTodosAtivos();

            // Assert
            clienteRepo.Verify(m => m.ObterTodos(), Times.Once); // Verificar se chamou pelo menos uma vez o metodo ObterTodos
            Assert.True(clientes.Any()); // Se existe algum cliente
            Assert.False(clientes.Count(c => !c.Ativo) > 0); // Se existe pelo um cliente ativo 
        }
    }
}
