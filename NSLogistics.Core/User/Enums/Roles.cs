namespace NSLogistics.Core.User.Enums;

public static class Roles
{
    public enum UserRole
    {
        Customer = 1,
        Admin = 2
    }


    public const string AdminPolicy = "AdminOnly";
    public const string Admin = "Admin";
    public const string Customer = "Customer";


    public static UserRole[] RegularUserRoles => new UserRole[] { UserRole.Customer };
    public static string[] RegularUsers => new string[] { Customer };
    public static UserRole[] AdminUserRoles => new UserRole[] { UserRole.Admin };
    public static string[] AdminUsers => new string[] { Admin };
}

