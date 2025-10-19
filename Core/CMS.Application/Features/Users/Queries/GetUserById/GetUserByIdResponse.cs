using CMS.Domain.Entities;

namespace CMS.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdResponse
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual Role Role { get; set; }
    }
}