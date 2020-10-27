﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Identity.Models;
using Identity.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Account;
using Models.ResponseModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public AdminController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpGet("alluser")]
        public async Task<IActionResult> GetAllUser()
        {
            var userList = await _accountService.GetUsers();

            var data = _mapper
                .Map<IReadOnlyList<ApplicationUser>, IReadOnlyList<UserDto>>(userList);

            return Ok(new BaseResponse<IReadOnlyList<UserDto>>(data, $"User List"));
        }
    }
}

