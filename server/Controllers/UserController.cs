using LearnQuickOnline.Helpers;
using LearnQuickOnline.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnQuickOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        Models.LearnQuickOnlineContext context = new Models.LearnQuickOnlineContext();

        // GET api/values
        [HttpGet("{id}")]
        public Response<ViewUserModel> GetUser(string id)
        {
            try
            {
                var _user = context.Users.Find(u => u.Id == id).FirstOrDefault();
                if (_user != null)
                {
                    return new Response<ViewUserModel> {
                        Data = ModelConverter.ConvertUserToViewModel(_user),
                        Message = "Found the user",
                        Status = true
                    };
                }
                else
                {
                    throw new Exception("Can not find the user of id " + id);
                }
            }
            catch (Exception ex)
            {
                return new Response<ViewUserModel>
                {
                    Data = null,
                    Message = ex.Message,
                    Status = false
                };
            }
        }

        // GET api/values/5
        [HttpGet("all/users")]
        public async Task<Response<List<ViewUserModel>>> GetAllUsersAsync()
        {
            try
            {
                var _allUsers = await context.Users.Find(u => true).ToListAsync();
                if (_allUsers != null)
                {
                    return new Response<List<ViewUserModel>>
                    {
                        Data = _allUsers.Select(v => ModelConverter.ConvertUserToViewModel(v)).ToList(),
                        Message = "Found the user",
                        Status = true
                    };
                }
                else
                {
                    throw new Exception("Can not find the users");
                }
            }
            catch (Exception ex)
            {
                return new Response<List<ViewUserModel>>
                {
                    Data = null,
                    Message = ex.Message,
                    Status = false
                };
            }
        }

        // POST api/values
        [HttpPost("login/user")]
        public Response<ViewUserModel> LoginUser(Models.User user)
        {
            try
            {
                var _user = context.Users.Find(u => u.Username == user.Username && u.Password == user.Password).ToList();
                return new Response<ViewUserModel>
                {
                    Data = ModelConverter.ConvertUserToViewModel(_user.FirstOrDefault()), 
                    Message = "success",
                    Status = true
                };
            }
            catch (Exception ex) {
                return new Response<ViewUserModel>
                {
                   Data = null,
                    Message = ex.Message + "specified user is unvailable",
                    Status = false
                };

            }

        }

        // POST api/values
        [HttpPost("register/user:Id")]
        public Response<Models.User>  RegisterUser(Models.User user)
        {
            try
            {
                var _user = context.Users.Find(u =>u.Username == user.Username);
                if (_user != null)
                {
                    return new Response<Models.User>
                    {
                        Data = user, 
                        Message = "user already exists",
                        Status = false
                    };
                }
                else if (_user == null) {
                    context.Users.InsertOne(new Models.User
                    {
                        Username = user.Username,
                        Password = user.Password,
                        Name = user.Name,
                        Surname = user.Surname,
                        Email = user.Email,
                        CellNumber = user.CellNumber
                    });
                    return new Response<Models.User>
                    {
                        Data =null ,
                        Message = "OK" + "successfully added new user",
                        Status= true
    };                   
                }
            }
            catch (Exception ex) {
                return new Response<Models.User>
                {
                    Data = null,
                    Message =ex.Message  +  "unable to add user",
                    Status = false
                };
            }

            return null;
        } 
    }
}
