﻿using Api.Data;
using Api.Entities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() => await _context.Users.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id) => await _context.Users.FindAsync(id);
    }
}
