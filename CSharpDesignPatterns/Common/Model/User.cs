namespace CSharpDesignPatterns.Common.Model
{
    using System;

    public enum UserRole
    {
        User,
        Moderator,
        Admin
    }

    public class User
    {
        public readonly Guid     Id;
        public readonly UserRole Role;
        public readonly string   Username;

        public User(string username, UserRole role)
        {
            this.Role     = role;
            this.Id       = Guid.NewGuid();
            this.Username = username;
        }
    }
}