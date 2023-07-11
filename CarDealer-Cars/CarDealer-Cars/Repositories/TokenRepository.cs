using CarDealer_Car.Interfaces;
using CarDealer_Car.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarDealer_Car.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        public static readonly SymmetricSecurityKey SecretKey =
            new(Encoding.UTF8.GetBytes("wqWLEYfsB7DsvmPs5Gxhk8mdDBNLNQ6yQYD@345"));
        
        
    }
}