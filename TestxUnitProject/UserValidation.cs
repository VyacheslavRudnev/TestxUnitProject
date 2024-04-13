﻿using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace TestxUnitProject;

public static class UserValidation
{
    public static bool IsNameValid(string name) 
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(nameof(name));
        }

        return !name.Any(char.IsDigit);
    }

    public static bool IsEmailValid(string name)
    {
        throw new NotImplementedException();
    }

    public static bool IsPasswordValid(string name)
    {
        throw new NotImplementedException();
    }

    public static bool IsNicknameValid(string nickname)
    {
        if (string.IsNullOrWhiteSpace(nickname))
        {
            throw new ArgumentException(nameof(nickname));
        }
        return !nickname.Any(char.IsDigit);
    }
}
