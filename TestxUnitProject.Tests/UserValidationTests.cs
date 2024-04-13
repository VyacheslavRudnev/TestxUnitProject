namespace TestxUnitProject.Tests
{
    public class UserValidationTests
    {
        //TDD - Test Driven Development

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void UserValidation_IsNameValid_InvalidData(string name)
        {
            Assert.Throws<ArgumentException>(() => UserValidation.IsNameValid(name));
        }


        [Theory]
        [InlineData("John123")]
        [InlineData("123John")]
        public void UserValidation_IsNameValid_InvalidName(string name)
        {
            // Triple A (Arrange-Act-Assert)
            // Arrange
            //string name = string.Empty;

            // Act
            bool result = UserValidation.IsNameValid(name);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void UserValidation_IsNameValid_ValidName()
        {
            // Triple A (Arrange-Act-Assert)
            // Arrange
            string name = "John";

            // Act
            bool result = UserValidation.IsNameValid(name);

            // Assert
            Assert.True(result);
            //Assert.Throws<NotImplementedException>();
        }
    }
}
