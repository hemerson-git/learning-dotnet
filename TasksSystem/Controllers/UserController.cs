using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksSystem.Models;
using TasksSystem.Repositories.Interfaces;

namespace TasksSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository) { 
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserModel>>> GetAllUsers()
    {
        List<UserModel> users = await _userRepository.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserModel>> GetUserById(int id)
    {
        UserModel user = await _userRepository.GetUserById(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserModel>> CreateUser([FromBody] UserModel userModel)
    {
        UserModel user = await _userRepository.AddUser(userModel);
        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel userModel, int id)
    {
        userModel.Id = id;
        UserModel user = await _userRepository.Update(userModel, id);
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteUser(int id)
    {
        bool deleted = await _userRepository.Delete(id);
        return Ok(deleted);
    }
}
