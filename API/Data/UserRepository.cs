﻿using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<MemberDto> GetMemberAsync(string username)
        {
            return await _context.Users
                .Where(x => x.UserName == username)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _context.Users
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider).ToListAsync();
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
