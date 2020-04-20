using System;
namespace SMS.Data.Models {
    public enum Role { Admin, Manager, Guest }

    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
