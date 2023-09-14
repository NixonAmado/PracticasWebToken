namespace Domain.Entities;

public class User : BaseEntity
{
    public string Name {get;set;}
    public string Email{get;set;}
    public string Password{get;set;}
    public ICollection<Rol> Rols {get;set;} = new HashSet<Rol>();
    public ICollection<UserRol> UsersRols {get;set;}
    public ICollection<RefreshToken> RefreshTokens {get;set;}

}