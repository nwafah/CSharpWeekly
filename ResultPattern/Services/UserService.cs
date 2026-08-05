using Microsoft.EntityFrameworkCore;
using ResultPattern.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResultPattern.Services
{
    public class UserService(AppDbContext context)
    {
        public async Task<Result<User>> CreateUserAsync(string name, string email)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Result<User>.Failure(UserErrors.NameRequired);
            }
            if (!email.Contains("@"))
            {
                return Result<User>.Failure(UserErrors.InvalidEmail);
            }
            if (context.users.Any(u => u.Email == email))
            {
                return Result<User>.Failure(UserErrors.EmailToken);
            }

            var user = new User
            {
                Name = name,
                Email = email
            };
            context.users.Add(user);
            await context.SaveChangesAsync();
            return Result<User>.Success(user);
        }
    }
}
