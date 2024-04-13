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

        //Nickname може містити в собі літери будь якого регістру англійського алфавіту, цифри та нижній підчерк ( _ )
        //Спец символи чи пробіли не дозволено додавати до нікнейму.
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void UserValidation_IsNicknameValid_InvalidData(string nickname)
        {
            Assert.Throws<ArgumentException>(() => UserValidation.IsNicknameValid(nickname));
        }

        [InlineData("`~!@#$%")]
        [InlineData("^&*()_+=/,><?.-")]
        [InlineData("Никнейм")]
        [InlineData("Нік ім'я")]
        public void UserValidation_IsNicknameValid_InvalidNickname(string nickname)
        {
            bool result = UserValidation.IsNicknameValid(nickname);

            Assert.True(result);
        }

        [Theory]
        [InlineData("John123")]
        [InlineData("123John")]
        [InlineData("John_123")]
        public void UserValidation_IsNicknameValid_ValidNickname(string nickname)
        {
            bool result = UserValidation.IsNicknameValid(nickname);

            Assert.False(result);
        }
    }
}
