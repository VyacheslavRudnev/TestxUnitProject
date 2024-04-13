using System.Xml.Linq;

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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void UserValidation_IsPasswordValid_InvalidData(string pass)
        {
            Assert.Throws<ArgumentException>(() => UserValidation.IsPasswordValid(pass));
        }

        [Theory]
        [InlineData("StrongPassword_123")]
        [InlineData("12_Password(3)StronG")]
        public void UserValidation_IsPasswordValid_ValidData(string pass)
        {
            Assert.True(UserValidation.IsPasswordValid(pass));
        }

        [Theory]
        [InlineData("short")]
        [InlineData("1234567")]
        public void UserValidation_IsPasswordValid_ShortPassword(string pass)
        {
            Assert.False(UserValidation.IsPasswordValid(pass), "Парольне може бути менше 8 символів");
        }

        [Theory]
        [InlineData("Password$123")]
        [InlineData("Pa ssword123")]
        [InlineData("Password'=+,./}{")]
        public void UserValidation_IsPasswordValid_InvalidCharacters(string pass)
        {
            Assert.False(UserValidation.IsPasswordValid(pass), "Пароль не може містити символи: ' = + , . / } { ~ ");
        }

        [Theory]
        [InlineData("ValidPassword")]
        [InlineData("pass123word")]
        public void UserValidation_IsPasswordValid_LatinAlphabet(string pass)
        {
            Assert.True(UserValidation.IsPasswordValid(pass));
        }

        [Theory]
        [InlineData("Пароль")]
        [InlineData("пароль123")]
        public void UserValidation_IsPasswordInvalid_NonLatinAlphabet(string pass)
        {
            Assert.False(UserValidation.IsPasswordValid(pass), "Для паролю використовуйте лише символи латинського алфавіту");
        }

        [Theory]
        [InlineData("weakpassword")]
        [InlineData("Password")]
        [InlineData("Password_")]
        [InlineData("Password123")]
        public void UserValidation_IsPasswordInvalid_Complexity(string pass)
        {
            Assert.False(UserValidation.IsPasswordValid(pass));
        }

        [Theory]

        [InlineData("12345678")]
        [InlineData("abcdefgh")]
        [InlineData("qwertyui")]
        [InlineData("11111111")]
        [InlineData("qqqqqqqq")]
        public void UserValidation_IsPasswordInvalid_SimplePasswords(string pass)
        {
            Assert.False(UserValidation.IsPasswordValid(pass));
        }
    }
}
