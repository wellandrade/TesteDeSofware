using Features.Core;
using Xunit;

namespace Features.Tests._2._6_CodeCovarge
{
    public class CpfValidationTest
    {
        [Theory(DisplayName = "CPF validos")]
        [Trait("Categoria", "CPF validation")]
        [InlineData("15231766607")]
        [InlineData("78246847333")]
        [InlineData("64184957307")]
        [InlineData("21681764400")]

        public void Cpf_ValidarMultiplosNumeros_TodosDevemSerValidos(string cpf)
        {
            // Assert
            var cpfValidation = new CpfValidation();

            // Act e Assert
            Assert.True(cpfValidation.EhValido(cpf));
        }

        //[Theory(DisplayName = "CPF invvalidos")]
        //[Trait("Categoria", "CPF validation")]
        //[InlineData("152317666012317")]
        //[InlineData("782468473312313")]
        //[InlineData("6418495730213127")]
        //[InlineData("2168176442312313")]

        //public void Cpf_ValidarMultiplosNumeros_TodosDevemSerInvalidos(string cpf)
        //{
        //    // Assert
        //    var cpfValidation = new CpfValidation();

        //    // Act e Assert
        //    Assert.False(cpfValidation.EhValido(cpf));
        //}
    }
}
