﻿using NSLogistics.Core.Application;
using NSLogistics.Core.Common;

using static NSLogistics.Core.User.Enums.Roles;

namespace NSLogistics.Core.User;

public class UserEntity : BaseEntity
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string IdNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime DateOfBirth { get; set; } = default!;
    public string Password { get; set; } = null!;
    public string Salt { get; set; } = null!;
    public UserRole Role { get; set; }

    public ICollection<ApplicationEntity> Applications { get; set; }
}
