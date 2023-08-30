﻿using System;
using System.Collections.Generic;

namespace PrimeTableware.WPF.Models
{
    public class RoleModel
    {
        public int idRole { get; set; }
        public string NameRole { get; set; }
        public string DiscriptionRole { get; set; }
        public int CreatedByidUser { get; set; }
        public int EditedByidUser { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateEdit { get; set; }
        // список разрешенных функций для данной роли
     //   public List<string> AllowedFunctions { get; set; }
    }
}
