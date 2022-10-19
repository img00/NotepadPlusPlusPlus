using System;
using System.Runtime.Serialization;

namespace NotepadPlusPlusPlus.Model
{
    public class User
    {
        public string Username { get; }
        public string Password { get; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   Username == user.Username;
        }
    }
}
