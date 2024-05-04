using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication {
            public static Error InvalidCredentials => Error.Conflict(
                code: "Auth.InvalidCred",
                description: "Invalid credentials");
        }
    }
}
