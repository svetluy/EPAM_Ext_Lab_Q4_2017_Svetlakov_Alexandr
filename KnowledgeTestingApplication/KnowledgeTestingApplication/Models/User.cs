﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTestingApplication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public List<Role> Role { get; set; }
    }
    public enum Role
    {
        User,
        Admin
    }
}