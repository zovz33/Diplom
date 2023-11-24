﻿using System.ComponentModel.DataAnnotations;

namespace PrimeTableware.ASPNET.API.Models.Auth
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
