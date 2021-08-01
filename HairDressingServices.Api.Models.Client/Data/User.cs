﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairDressingServices.Api.Models.Client.Data
{
    public enum Role { Admin = 0, Member = 1, Professionnal = 2 }
    public class User
    {
        //private Role role;

        public int Id { get; private  set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string Passwd { get; private set; }
        public Role Role { get; set; } = Role.Member;
        public DateTime BirthDate { get; set; }
        public bool Status { get; set; }
        public string Token { get; set; }

        public User(string lastname, string firstname, string pseudo, string email, string passwd, Role Role, DateTime birthDate, bool status)
        {
            Lastname = lastname;
            Firstname = firstname;
            Pseudo = pseudo;
            Email = email;
            Passwd = passwd;
            this.Role = Role;
            BirthDate = birthDate;
            Status = status;
        }

        internal User(int id, string lastname, string firstname, string pseudo, string email, Role Role, DateTime birthDate, bool status)
            :this(lastname, firstname, pseudo, email, null, Role, birthDate, status)
        {
            Id = id;
        }

        public User(string lastname, string firstname, string pseudo, string email, string passwd, Role Role, DateTime birthDate)
        {
            Lastname = lastname;
            Firstname = firstname;
            Pseudo = pseudo;
            Email = email;
            Passwd = passwd;
            this.Role = Role;
            BirthDate = birthDate;
        }
    }
}