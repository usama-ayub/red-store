using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using eShopApi.DTOs;
using eShopApi.Helper;
using eShopApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShopApi.Controllers
{
    public class UserController : BaseApiController
    {
        private IUserService _userService;
        private readonly IMediaService _mediaService;
        public UserController(IUserService userService, IMediaService mediaService)
        {
            _userService = userService;
            _mediaService = mediaService;
        } 


        [HttpGet()]
        public async Task<IActionResult> GetUsers([FromQuery] PaginationDto paginationParams)
        {
            var result = await _userService.Get(paginationParams);
            if (result.status)
            {
                return BaseResponse(result.user, HttpStatusCode.OK, "Found");
            }
            return BaseResponse("", HttpStatusCode.NotFound, "Not Found", false, true);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto payload)
        {
            var result = await _userService.Register(payload);
            if (result.status)
            {
                return BaseResponse(result.register, HttpStatusCode.OK,result.message);
            }
            return BaseResponse("", HttpStatusCode.NotFound, result.message, false, true);
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto payload)
        {
            var result = await _userService.Login(payload);
            if (result.status)
            {
                return BaseResponse(result.login, HttpStatusCode.OK, result.message);
            }
            return BaseResponse("", HttpStatusCode.NotFound, result.message, false, true);
        }

    }
}