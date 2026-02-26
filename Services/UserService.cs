using Microsoft.EntityFrameworkCore;
using StudentPR.Data;
using StudentPR.DTOs.Requests;
using StudentPR.Helpers;
using StudentPR.Models;

namespace StudentPR.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUserAsync(CreateUserDto dto)
        {
            var user = new User
            {
                UserID = dto.UserID,
                PasswordHash =
                    PasswordHelper.HashPassword(dto.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
        public async Task<User?> ValidateUserAsync(LoginDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserID == dto.UserID);

            if (user == null)
                return null;

            bool valid =
                PasswordHelper.VerifyPassword(
                    dto.Password,
                    user.PasswordHash);

            return valid ? user : null;
        }
    }
    }
