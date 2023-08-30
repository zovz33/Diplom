﻿using System;

namespace PrimeTableware.WPF.Models
{
    public class UserModel
    {
        public int idUser { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public int idRole { get; set; }
        public string MobilePhone { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FName { get; set; }
        public string Gender { get; set; }
        public string Adress { get; set; }
        public string HomePhone { get; set; }
        public DateTime DateOfBorn { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateEdit { get; set; }
        public string ProfileImage { get; set; }
    }
}