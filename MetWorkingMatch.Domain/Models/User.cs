using System;

namespace MetWorkingMatch.Domain.Models
{
    public class UserResponse
    {
        public bool isOk { get; set; }
        public User data { get; set; }
    }

    public class User
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string description { get; set; }
        public string company { get; set; }
        public string role { get; set; }
        public string image { get; set; }
    }
}