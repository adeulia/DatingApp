using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .FindAsync(id);
        }

        public async Task<AppUser> GetUserByNameAsync(string username)
        {
            return await _context.Users
                .Include(y => y.Photos)
                .SingleOrDefaultAsync(predicate: x => x.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users
                .Include(AppUser => AppUser.Photos)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            //returning a bool, make sure > 0 changes are saved to db
            return await _context
                .SaveChangesAsync() > 0;
        }

        public async void Update(AppUser user)
        {
            //lets EF update and add a flag 
            //_context.Update(user);
            _context.Entry(user).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
        }
    }
}
