﻿using System.ComponentModel.DataAnnotations;
using Diplom.ASPNET.Domain.Entities.Identity;
using MediatR;

namespace Diplom.ASPNET.Application.Items.User.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<Unit>
{
    [Required] public int Id { get; set; }

    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public int RoleId { get; set; }
    public string PhoneNumber { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public Gender? Gender { get; set; }
    public string Address { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string ProfileImage { get; set; }
}