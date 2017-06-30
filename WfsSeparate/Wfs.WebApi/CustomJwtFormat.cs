using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Microsoft.Owin.Security;
using Thinktecture.IdentityModel.Extensions;
using Thinktecture.IdentityModel.Tokens;

namespace Wfs.WebApi
{
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly byte[] _secret;
        private readonly string _issuer;

        public CustomJwtFormat(string issuer, byte[] secret)
        {
            _issuer = issuer;
            _secret = secret;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
                throw new ArgumentException("data");

            var signKey = new HmacSigningCredentials(_secret);
            var issuedUtc = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;

            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(_issuer, "Any", data.Identity.Claims, issuedUtc.Value.UtcDateTime, expires.Value.UtcDateTime, signKey));
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}