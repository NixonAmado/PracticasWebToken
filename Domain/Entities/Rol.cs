namespace Domain.Entities;

public class Rol : BaseEntity
{
    public string Description {get;set;}
    public ICollection<User> Users {get;set;} = new HashSet<User>();
    public ICollection<UserRol> UsersRols {get;set;}
}