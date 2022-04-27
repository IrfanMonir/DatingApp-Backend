using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using System.Text;

namespace Api.DependencyInjection
{
    public static class AuthServiceRegister
    {
        public static void AddAuthService(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenvalidaionParams = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,  //Gets or sets a boolean that controls if validation of the SecurityKey that signed the securityToken is called.
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecuritySettings:JwtSettings:key"])),  // Gets or sets the SecurityKey that is to be used for signature validation.
                ValidateIssuer = false,  //Gets or sets a boolean to control if the issuer will be validated during token validation.
                ValidateAudience = false, // Gets or sets a boolean to control if the audience will be validated during token validation.
                ValidateLifetime = true,  //Gets or sets a boolean to control if the lifetime will be validated during token validation.
                ClockSkew = TimeSpan.Zero  //Gets or sets the clock skew to apply when validating a time.
            };

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = tokenvalidaionParams;
                });
        }
    }
}
