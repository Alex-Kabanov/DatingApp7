using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController(
    IUserRepository userRepository, 
    IMapper mapper) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsersAsync()
    {
        var users = await userRepository.GetMembersAsync();

        return Ok(users);
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUserAsync(string username)
    {
        var user = await userRepository.GetMemberAsync(username);

        if (user == null)
        {
            return NotFound();
        }
        
        return user;
    }

    [HttpGet("powerUsers")]
    public async Task<ActionResult<List<PowerUserWithAttribute>>> GetPowerUserAsync()
    {
        var iteration = 5;
        var listPowerUsers = new List<PowerUserWithAttribute>();
        for(int i = 0; i < iteration; i++)
        {
            var availableTiers = Enum
                    .GetValues(typeof(Tiers))
                    .Cast<Tiers>()
                    .Select(x => x.ToString())
                    .ToList();
            var user = new PowerUserWithAttribute(){
                UserId = i,
                Email = "test@gmail.com",
                FirstName = "test@gmail.com",
                LastName = "test@gmail.com",
                AttributeValue = "test@gmail.com",
                AvailableTiers = availableTiers,
            };
            listPowerUsers.Add(user);
        }
        return listPowerUsers;
    }
}
public class PowerUserWithAttribute
{
    public int UserId { get; set; }

    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string AttributeValue { get; set; }

    public List<string> AvailableTiers { get; set; }
}

public enum Tiers
{
    Tier1 = 1,
    Tier2 = 2,
    Tier3 = 3,

    Tier4 = 4,

    Tier5 = 5,
}