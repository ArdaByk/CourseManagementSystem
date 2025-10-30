using CMS.Application.Abstractions.Services;
using System;
using System.Threading.Tasks;

namespace CMS.Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserService _userService;
        public UserBusinessRules(IUserService userService)
        {
            _userService = userService;
        }
        public async Task EnsureUsernameIsUniqueAsync(string username)
        {
            var exists = await _userService.AnyAsync(u => u.Username == username);
            if (exists) throw new Exception("Bu kullanıcı adı zaten kullanılıyor.");
        }
        public async Task EnsureEmailIsUniqueAsync(string email)
        {
            var exists = await _userService.AnyAsync(u => u.Email == email);
            if (exists) throw new Exception("Bu e-posta zaten kullanılıyor.");
        }
        public async Task EnsureUserExistsAsync(Guid userId)
        {
            var exists = await _userService.AnyAsync(u => u.Id == userId);
            if (!exists) throw new Exception("Kullanıcı bulunamadı.");
        }
    }
}
