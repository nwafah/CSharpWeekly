using ResultPattern.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResultPattern.Services
{
    public class UserServiceThrowException(AppDbContext context)
    {
        public async Task<User> CreateUserAsync(string name, string email)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ValidationException("Name is requeried");
            }
            if(!email.Contains("@"))
            {
                throw new ValidationException("Email is not valid");
            }
            if(context.users.Any(u => u.Email == email))
            {
                throw new ConflictException("Email is already in use");
            }

            var user =new User
            {
                Name = name,
                Email = email
            };
            context.users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

    }
}
