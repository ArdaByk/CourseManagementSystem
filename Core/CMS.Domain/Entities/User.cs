using CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities;

public class User : BaseEntity<Guid>
{
    public User(Guid id, string username, byte[] passwordHash, byte[] passwordSalt, string fullName, string email, Guid roleId, string phone)
       :base(id)
    {
        Username = username;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        FullName = fullName;
        Email = email;
        Phone = phone;
        RoleId = roleId;
    }
    public User()
    {
        
    }

    public string Username { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; }
}
