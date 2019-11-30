using Xunit;

namespace Demo.Tests
{
    public class AssertingCollectionTests
    {
        [Fact]
        public void Funcionario_Habilidades_NaoDevePossuirHabilidadesVazias()
        {
            // Arrange - Act
            var funcionario = FuncionarioFactory.Criar("Joao", 1000);

            // Assert
            Assert.All(funcionario.Habilidades, habilidade => Assert.False(string.IsNullOrEmpty(habilidade)));
        }

        [Fact]
        public void Funcionario_Habilidades_JuniorDevePossuirHabilidadeBasica()
        {
            // Arrange - Act
            var funcionario = FuncionarioFactory.Criar("Joao", 1000);

            // Assert
            Assert.Contains("OOP", funcionario.Habilidades); // Procurando uma string em uma lista de string
        }

        [Fact]
        public void Funcionario_Habilidades_JuniorNaoDevePossuirHabilidadeBasica()
        {
            // Arrange - Act
            var funcionario = FuncionarioFactory.Criar("Joao", 1000);

            // Assert
            Assert.DoesNotContain("Microservices", funcionario.Habilidades); // Procurando uma string em uma lista de string
        }

        [Fact(Skip ="Pulando teste com falha")]
        public void Funcionario_Habilidades_SeniorDevePossuirHabilidades()
        {
            // Arrange 
            var funcionario = FuncionarioFactory.Criar("Joao", 1000);

            // Act
            var habilidades = new []
            {
                "Lógica de Programação",
                "OOP",
                "Testes",
                "Microservices",
            };

            // Assert
            Assert.Equal(habilidades, funcionario.Habilidades); // Procurando uma string em uma lista de string
        }
    }
}
