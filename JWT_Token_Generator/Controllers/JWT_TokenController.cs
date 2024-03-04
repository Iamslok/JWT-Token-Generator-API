using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using System.Text;

namespace JWT_Token_Generator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWT_TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public JWT_TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [Route("GenerateJWTToken")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GenerateJWTToken([FromBody] RequestModel requestModel)
        {
            try
            {
                // Accessing property from appsettings.json
                var key = _configuration.GetValue<string>("SymmetricSecurityKey");

                SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                SigningCredentials signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                List<Claim> claims = new List<Claim>();

                // Populate claims dynamically based on RequestModel
                foreach (var model in requestModel.Cliams)
                {
                    if (!string.IsNullOrWhiteSpace(model.CliamType))
                    {
                        claims.Add(new Claim(model.CliamType, model.CliamValue));
                    }
                    else
                    {
                        return BadRequest("Invalid claim type.");
                    }
                }

                // Set token expiration
                int defaultTokenExpiresInHours = 2;
                DateTime tokenExpiresIn = DateTime.UtcNow.AddHours(requestModel?.TokenExpiresInHours ?? defaultTokenExpiresInHours);

                JwtSecurityToken tokenOptions = new JwtSecurityToken(
                        claims: claims,
                        expires: tokenExpiresIn,
                        signingCredentials: signinCredentials
                    );

                string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                // Optionally: Store or log the generated token

                return Ok(new TokenModel { Token = tokenString, TokenExpriesAt = tokenExpiresIn });
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
