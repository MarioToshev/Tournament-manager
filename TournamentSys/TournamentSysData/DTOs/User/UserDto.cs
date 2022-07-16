using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TournamentSysData.DTOs
{
    public class UserDto
    {
        private string id;
        private string firstName;
        private string lastName;
        private string password;
        private string email;
        private string role;
        private string passwordSalt;



        public UserDto()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public UserDto(string firstName, string lastName, string password, string email, string roleId)
        {
            this.Id = Guid.NewGuid().ToString();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Email = email;
            this.role = roleId;
        }

        public string Id
        {
            get => id;
            set => id = value;
        }
        public string FirstName
        {
            get => firstName;
            set
            {
                if (!string.IsNullOrEmpty(value) && value.ToArray().Count() >= 2)
                {
                    firstName = value;
                }
                else throw new ArgumentException("First name should be at least 2 simbols");
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (!string.IsNullOrEmpty(value) && value.ToArray().Count() >= 2)
                {
                    lastName = value;
                }
                else throw new ArgumentException("Second name should be at least 2 simbols");
            }
        }
        public string Password
        {
            get => password;
            set
            {
                if (!string.IsNullOrEmpty(value) && value.ToArray().Count() >= 3)
                {
                    password = value;
                }
                else throw new ArgumentException("Password should be at least 3 simbols");
            }
        }
        public string Email
        {
            get => email;
            set
            {
                string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
                if (Regex.IsMatch(value, regex, RegexOptions.IgnoreCase))
                {
                    email = value;
                }
                else throw new ArgumentException("Email is not valid.");
            }
        }
        public string Role
        {
            get => role;
            set => role = value;
        }
        public string PasswordSalt
        {
            get => passwordSalt;
            set => passwordSalt = value;
        }
        public override string ToString()
        {
            return $"{firstName} {LastName} {role} ";
        }
    }
}
