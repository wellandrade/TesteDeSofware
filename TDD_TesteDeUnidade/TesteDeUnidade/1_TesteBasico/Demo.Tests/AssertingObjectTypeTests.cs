using Xunit;

namespace Demo.Tests
{
    public class AssertingObjectTypeTests
    {
        [Fact] // Verifica o tipo da classe que foi criado
        public void FuncionarioFactory_Criar_DeveRetornarTipoFuncionario()
        {
            // Arrange - Act
            var funcionario = FuncionarioFactory.Criar("Joao", 1000);

            // Assert
            Assert.IsType<Funcionario>(funcionario);
        }

        [Fact] // Se a classe herda de Pessoa
        public void FuncionarioFactory_Criar_DeveRetornarTipoDerivadoPessoa()
        {
            // Arrange - Act
            var funcionario = FuncionarioFactory.Criar("Joao", 1000);

            // Assert
            Assert.IsAssignableFrom<Pessoa>(funcionario);
        }
    }
}
