using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Users.Data;
using Users.Dtos;
using Users.Models;

namespace Users.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repo;
        public readonly IMapper _mapper;
        public UsersController(IUserRepo repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }


        [HttpGet]
        public ActionResult<IEnumerable<UserForReadDto>> GetAllUsers()
        {
            var UsersFromRepo = _repo.GetAllUsers();
            if (UsersFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<UserForReadDto>>(UsersFromRepo));
        }

        [HttpGet("{id}", Name="GetUserById")]
        public ActionResult<UserForReadDto> GetUserById(int id)
        {
            var userItem = _repo.GetUserById(id);
            
            if (userItem != null)
            {
                return Ok(_mapper.Map<UserForReadDto>(userItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<UserForReadDto> CreateUser(UserForCreateDto userForCreateDto)
        {
            var userModel = _mapper.Map<User>(userForCreateDto);
            _repo.CreateUser(userModel);
            _repo.SaveChanges();
            var userForReadDto = _mapper.Map<UserForReadDto>(userModel);
            return CreatedAtRoute(nameof(GetUserById), new {Id = userForReadDto.Id}, userForReadDto);
            //return Ok(userForReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserForUpdateDto userForUpdateDto)
        {
            var userItem = _repo.GetUserById(id);
            
            if (userItem == null)
            {
                return NotFound();
            }
            _mapper.Map(userForUpdateDto, userItem);
            _repo.UpdateUser(userItem);
            _repo.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult partialUserUpdate(int id, JsonPatchDocument<UserForUpdateDto> patchDoc)
        {
            var userItem = _repo.GetUserById(id);
            
            if (userItem == null)
            {
                return NotFound();
            }
            var userToPatch = _mapper.Map<UserForUpdateDto>(userItem);
            patchDoc.ApplyTo(userToPatch, ModelState);
            if(!TryValidateModel(userToPatch))
            {
                return ValidationProblem(ModelState);
            }
             _mapper.Map(userToPatch, userItem);

            _repo.UpdateUser(userItem);
            _repo.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult deleteUser(int id)
        {
            var userItem = _repo.GetUserById(id);
            
            if (userItem == null)
            {
                return NotFound();
            }
            _repo.DeleteUser(userItem);
            _repo.SaveChanges();
            return NoContent();
        }

    }
}