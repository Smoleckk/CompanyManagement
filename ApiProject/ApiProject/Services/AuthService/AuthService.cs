using ApiProject.Data;
using ApiProject.Dtos;
using ApiProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ApiProject.Services.AuthService
{
    public class AuthService : IAuthService
    {
        public static User user = new User();

        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public AuthService(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<ServiceResponse<string>> Login(UserDto request)
        {
            var response = new ServiceResponse<string>();
            var use = await _context.Users.FirstOrDefaultAsync(i => i.Username == request.Username);

            if (use == null)
            {
                response.Success = false;
                response.Message = "Wrong Credentials";
            }
            //return BadRequest("Wrong Credentials");
            if (!VerifyPasswordHash(request.Password, use.PasswordHash, use.PasswordSalt))
            //return BadRequest("Wrong Credentials");
            {
                response.Success = false;
                response.Message = "Wrong Credentials";
            }
            else
            {
                response.Data = CreateToken(user);
            }

            return response;

            //string token = CreateToken(use);
        }

        public async Task<ServiceResponse<int>> Register(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.Username = request.Username;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Notes = new List<Note>();
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new ServiceResponse<int> { Data = user.Id, Message = "Registration successful!" };
        }


        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordhash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computehash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes((string)password));
                return computehash.SequenceEqual(passwordhash);
            }
        }
    }
}
