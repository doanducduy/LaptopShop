﻿using LaptopShop.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LaptopShop.Controllers
{
	public class AuthController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public static User user = new User();
		private readonly IConfiguration _configuration;

		public AuthController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		[HttpPost("register")]
		public ActionResult<User> Register(UserDto request)
		{
			string passwordHash
				= BCrypt.Net.BCrypt.HashPassword(request.Password);

			user.Username = request.Username;
			user.PasswordHash = passwordHash;

			return Ok(user);
		}

		[HttpPost("login")]
		public ActionResult<User> Login(UserDto request)
		{
			if (user.Username != request.Username)
			{
				return BadRequest("User not found.");
			}

			if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
			{
				return BadRequest("Wrong password.");
			}

			string token = CreateToken(user);

			return Ok(token);
		}

		private string CreateToken(User user)
		{
			List<Claim> claims = new List<Claim> {
				new Claim(ClaimTypes.Name, user.Username),
				new Claim(ClaimTypes.Role, "Admin"),
				new Claim(ClaimTypes.Role, "User"),
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
				_configuration.GetSection("JWT:Key").Value!));

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var token = new JwtSecurityToken(
					claims: claims,
					expires: DateTime.Now.AddDays(1),
					signingCredentials: creds
				);

			var jwt = new JwtSecurityTokenHandler().WriteToken(token);

			return jwt;
		}
	}
}
