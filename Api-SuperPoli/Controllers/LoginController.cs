﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Api_SuperPoli.Core.UserManager;
using Api_SuperPoli.Data;
using Api_SuperPoli.Models;
using Api_SuperPoli.Core.LoginManager;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Api_SuperPoli.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginManager _loginManager;
        private readonly IConfiguration config;

        public LoginController(ILoginManager loginManager, IConfiguration _config)
        {
            _loginManager = loginManager;
            config = _config;
        }
        [AllowAnonymous]
        [HttpGet("BuscarEmail")]
        public async Task<ActionResult> GetById(string email)
        {
            var ordenResult = await _loginManager.GetByIdAsync(email);
            if (ordenResult.Success)
            {
                return Ok(ordenResult.Value);
            }
            return NotFound(ordenResult.Errors);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> PostLogin(User user)
        {
            var result = await _loginManager.LoginAsync(user);
            if (result.Success)
            {
                // return CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value);
                var secretKey = config.GetValue<string>("SecretKey");
                var key = Encoding.ASCII.GetBytes(secretKey);

                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Email));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddHours(4),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                string bearer_token = tokenHandler.WriteToken(createdToken);
                return Ok(bearer_token);
            }
            return Ok(result.Errors);
        }
        [HttpGet]
        public ActionResult Get()
        {
            var r = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier);
            return Ok(r == null ? "" : r.Value);
        }
    }
}
