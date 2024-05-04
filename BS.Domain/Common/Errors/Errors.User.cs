﻿using ErrorOr;

namespace BS.Domain.Common.Errors
{
    public  static partial class Errors
    {
        public static class User {
            public static Error DuplicationEmail => Error.Validation(
                code: "User.DuplicationEmail",
                description: "Email is already in use");
        }
    }
}
