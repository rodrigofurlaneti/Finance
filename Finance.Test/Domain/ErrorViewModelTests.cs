using Bogus;
using Finance.Domain;

namespace Finance.Tests.Domain
{
    public class ErrorViewModelTests
    {
        [Fact]
        public void Deve_Preencher_As_Propriedades_Do_Classe_ErrorViewModel()
        {
            // Arrange
            var faker = new Faker<ErrorViewModel>()
                .RuleFor(e => e.RequestId, f => f.Random.String2(10)); // Gerando uma string aleatória de 10 caracteres

            // Act
            var errorViewModel = faker.Generate();

            // Assert
            Assert.NotNull(errorViewModel);
            Assert.NotNull(errorViewModel.RequestId);
            Assert.True(errorViewModel.ShowRequestId);

            // Output for demonstration
            Console.WriteLine($"RequestId: {errorViewModel.RequestId}");
            Console.WriteLine($"ShowRequestId: {errorViewModel.ShowRequestId}");
        }

        [Fact]
        public void Deve_Lidar_Com_RequestId_Valor_Nulo()
        {
            // Arrange
            var errorViewModel = new ErrorViewModel { RequestId = null };

            // Act & Assert
            Assert.Null(errorViewModel.RequestId);
            Assert.False(errorViewModel.ShowRequestId);

            // Output for demonstration
            Console.WriteLine($"RequestId: {errorViewModel.RequestId}");
            Console.WriteLine($"ShowRequestId: {errorViewModel.ShowRequestId}");
        }

        [Fact]
        public void RequestId_Deve_Ser_Uma_String_Anulável()
        {
            // Arrange
            var property = typeof(ErrorViewModel).GetProperty(nameof(ErrorViewModel.RequestId));

            // Act & Assert
            Assert.NotNull(property);
            Assert.Equal(typeof(string), Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            Assert.True(property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)
                || property.PropertyType == typeof(string));
        }

        [Fact]
        public void RequestId_Deve_Aceitar_Valor_Nulo()
        {
            // Arrange
            var model = new ErrorViewModel();

            // Act
            model.RequestId = null;

            // Assert
            Assert.Null(model.RequestId);
        }

        [Fact]
        public void Propriedade_RequestId_Deve_Ser_Do_Tipo_Bool()
        {
            // Arrange
            var property = typeof(ErrorViewModel).GetProperty(nameof(ErrorViewModel.ShowRequestId));

            // Act & Assert
            Assert.NotNull(property);
            Assert.Equal(typeof(bool), property.PropertyType);
        }
    }
}
