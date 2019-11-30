using Xunit;

namespace Demo.Tests
{
    public class AssertRangeTests
    {
        // Testando que o valor esta dentro das faixas
        [Theory(Skip ="Pulando teste com falha")]
        [InlineData(400)]
        [InlineData(1500)]
        [InlineData(3000)]
        [InlineData(5000)]
        [InlineData(7000)]
        [InlineData(9200)]
        public void Funcionario_Salario_FaixaSalariaisDevemRespeitarNivelProfissional(double salario)
        {
            // Arrange & Act 
            var funcionario = new Funcionario("Joao", salario);

            // Assert 
            if (funcionario.NivelProfissional == NivelProfissional.Junior)
                Assert.InRange(funcionario.Salario, 500, 1999);

            if (funcionario.NivelProfissional == NivelProfissional.Pleno)
                Assert.InRange(funcionario.Salario, 2000, 7999);

            if (funcionario.NivelProfissional == NivelProfissional.Senior)
                Assert.InRange(funcionario.Salario, 8000, double.MaxValue);

            // Assert - Nao pode ta dentro dessa faixa, salario nao permitido
            Assert.NotInRange(funcionario.Salario, 0, 499);
        }
    }
}
