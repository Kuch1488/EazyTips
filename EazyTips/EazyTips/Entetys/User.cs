﻿using System;

namespace EazyTips.Repository
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int IsAdmin { get; set; }
    }
}
