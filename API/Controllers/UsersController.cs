using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            //return await _context.Users.ToListAsync();
            //return Ok(await _userRepository.GetUsersAsync());
            var users = await _userRepository.GetUsersAsync();

            //specifiy what to map too with MAP<>
            var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);

            return Ok(users);
        }

        [HttpGet("{username}")]
        public async Task <ActionResult<MemberDto>> GetUser(string username)
        {
            //return await _context.Users.FindAsync(id);
            var user = await _userRepository.GetUserByNameAsync(username);

            return _mapper.Map<MemberDto>(user);
        }
    }
}
