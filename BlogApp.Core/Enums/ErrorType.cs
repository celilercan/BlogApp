using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Enums
{
    public enum ErrorType
    {
        None = 0,
        MissingInput = 1,
        DuplicateEmail = 2,
        NotFound = 3,
        CurrentPasswordWrong = 4,
        PasswordsNotMatching = 5,
        AccessError = 6
    }
}
