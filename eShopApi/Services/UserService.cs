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
        public UserService(
            IDBConnection dbconnection,
            ITokenService tokenService,
            IMapper mapper
            )
        {
            _tokenService = tokenService;
            _userCollection = dbconnection.DataBase.GetCollection<User>("User");
            _mapper = mapper;
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