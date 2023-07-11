using cashierAPI.database;
using cashierAPI.dto;
using cashierAPI.Models;

namespace cashierAPI.Repositories;

public class UserRepo
{
    private readonly DatabaseContext _context;

    public UserRepo(DatabaseContext context){
        _context = context;
    }

    public List<UserDto> GetUser(){
        return _context.users
            .Select(p => new UserDto{
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
