using ResultPattern;
using ResultPattern.Model;
using ResultPattern.Services;
using System.ComponentModel.DataAnnotations;

using var _context = new AppDbContext();


//try
//{
//    await new UserServiceThrowException(_context).CreateUserAsync("John Doe", "john.doe@example.com");
//}
//catch (ValidationException ex)
//{
//    Console.WriteLine($"Validation error: {ex.Message}");
//}
//catch (ConflictException ex)
//{
//    Console.WriteLine($"Conflict error: {ex.Message}");
//}


var result = await new UserService(_context).CreateUserAsync("", "john.doe@example.com");

if(result.IsSuccess)
{
    Console.WriteLine($"User created successfully: {result.Value?.Name}, {result.Value?.Email}");
}
else
{
    Console.WriteLine($"Error creating user: {result.Error?.code} - {result.Error?.description}");
} 