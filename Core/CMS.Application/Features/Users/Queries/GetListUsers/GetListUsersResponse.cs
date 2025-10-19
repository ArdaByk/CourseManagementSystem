using CMS.Domain.Entities;

namespace CMS.Application.Features.Users.Queries.GetListUsers
{
    public class GetListUsersResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}