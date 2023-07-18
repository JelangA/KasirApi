using cashierAPI.database;

using cashierAPI.Models;

namespace cashierAPI.Repositories;

public class UserRepo
{
    private readonly DatabaseContext _context;

    public UserRepo(DatabaseContext context){
        _context = context;
    }

    public List<User> GetUser(){
        return _context.users
            .Select(p => new User{
                nama_user = p.nama_user,
                email = p.email,
                password = p.password,
                gender = p.gender,
                no_telpon = p.no_telpon,
                alamat = p.alamat
            }).ToList();
    }

    public User CreateUser(User user){
        _context.users.Add(user);
        _context.SaveChanges();
        return user;
    }
}
