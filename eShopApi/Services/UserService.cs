using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using eShopApi.DTOs;
using eShopApi.Helper;
using eShopApi.Interfaces;
using eShopApi.Models;
using eShopApi.Responses;
using MongoDB.Driver;

namespace eShopApi.Services
{
   public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _userCollection;
       private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        public UserService(
            IDBConnection dbconnection,
            ITokenService tokenService,
            IMapper mapper,
            IEmailService emailService
            )
        {
            _tokenService = tokenService;
            _userCollection = dbconnection.DataBase.GetCollection<User>("User");
            _mapper = mapper;
            _emailService = emailService;
        }


        public async Task<(bool status, PaginationResult<ResponseUser> user)> Get(PaginationDto paginationParams)
        {

            var mongoFilter = Builders<User>.Filter.Empty;

            //if (!string.IsNullOrEmpty(filter?.Name))
            //{
            //    mongoFilter &= Builders<Product>.Filter.Regex(p => p.Name, new MongoDB.Bson.BsonRegularExpression(filter.Name, "i"));
            //}

            //if (!string.IsNullOrEmpty(filter?.Category))
            //{
            //    mongoFilter &= Builders<Product>.Filter.Eq(p => p.Category, filter.Category);
            //}

            //if (filter?.MinPrice.HasValue == true)
            //{
            //    mongoFilter &= Builders<Product>.Filter.Gte(p => p.Price, filter.MinPrice.Value);
            //}

            //if (filter?.MaxPrice.HasValue == true)
            //{
            //    mongoFilter &= Builders<Product>.Filter.Lte(p => p.Price, filter.MaxPrice.Value);
            //}

            var result = await PaginationResult<ResponseUser>.GetPaginatedDataAsync<User, ResponseUser>(
           _userCollection, _mapper, paginationParams.PageNumber, paginationParams.PageSize, mongoFilter);


            return (true, new PaginationResult<ResponseUser>(result.Items, result.TotalCount, result.CurrentPage, result.PageSize));
        }

        public async Task<(bool status,string message, ResponseRegister register)> Register(RegisterDto payload)
        {
            using var hmac = new HMACSHA512();
            if (await UserExit(payload.UserName))
            {
                return (false, "User Already Exist", null);
            }
           var user = new User();
            user.UserName = payload.UserName;
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload.Password));
            user.PasswordSalt = hmac.Key;
            user.Email = payload.Email;
            await _userCollection.InsertOneAsync(user);
            string htmlTemplate = await File.ReadAllTextAsync("EmailTemplates/WelcomeEmail.html");

            htmlTemplate = htmlTemplate
                .Replace("{{UserName}}", user.UserName)
                .Replace("{{LoginUrl}}", "https://yourapp.com/login"); // Update with real link

            try
            {
                await _emailService.SendEmailAsync(user.Email, "Welcome! To RedStore", htmlTemplate);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                //_logger.LogError("Email sending failed: " + ex.Message);
                // Do not return failure — user is still registered
            }
            return (true, "Register Sucessfully", new ResponseRegister
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            });
        }

        public async Task<(bool status,string message, ResponseLogin login)> Login(LoginDto payload)
        {
            var user = (await _userCollection.FindAsync(user => user.Email == payload.Email)).FirstOrDefault();
            if (user == null)
            {
                return (false, "User Not Found", null);
            }
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return (false, "Password is wrong", null);
                }
            }
            return (true, "Success", new ResponseLogin
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            });
        }

        private async Task<bool> UserExit(string username)
        {
            var user = (await _userCollection.FindAsync(user => user.UserName == username)).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}