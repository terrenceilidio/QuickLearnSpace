using LearnQuickOnline.Helpers;
using LearnQuickOnline.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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

        // GET api/user/id
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

        // GET api/user/all/users
        [HttpGet("all/users")]
        public async Task<Response<List<ViewUserModel>>> GetAllUsersAsync()
        {
            try
            {
                var _allUsers = await context.Users.Find(u => true).ToListAsync();
                if (_allUsers.Any())
                {
                    return new Response<List<ViewUserModel>>
                    {
                        Data = _allUsers.Select(v => ModelConverter.ConvertUserToViewModel(v)).ToList(),
                        Message = "success " + "returned all users",
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

        // POST api/user/login/user
        [HttpPost("login/user")]
        public Response<ViewUserModel> LoginUser(Models.User user)
        {
            try
            {
                var _user = context.Users.Find(u => u.Username == user.Username && u.Password == user.Password);
                if (_user.Any())
                {
                    return new Response<ViewUserModel>
                    {
                        Data = ModelConverter.ConvertUserToViewModel(_user.FirstOrDefault()),
                        Message = "Success",
                        Status = true
                    };
                }
                else
                {
                    throw new Exception("Incorrect login details");
                }
            }
            catch (Exception ex) {
                return new Response<ViewUserModel>
                {
                    Data = null,
                    Message = ex.Message,
                    Status = false
                };
            }
        }

        // POST api/user/register/users
        [HttpPost("register/user")]
        public Response<bool>  RegisterUser(Models.User user)
        {
            try
            {
                var _user = context.Users.Find(u =>u.Username == user.Username);
                if (_user.Any())
                {
                    return new Response<bool>
                    {
                        Data = true,
                        Message = "User already exists",
                        Status = false
                    };
                }
                else
                {
                    context.Users.InsertOne(user);
                    return new Response<bool>
                    {
                        Data = true,
                        Message = "OK successfully added new user",
                        Status = true
                    };
                }
            }
            catch (Exception ex) {
                return new Response<bool>
                {
                    Data = false,
                    Message =ex.Message  +  "unable to add user",
                    Status = false
                };
            }
        }

        [HttpPost("update/profile/{id}")]
        public async Task<Response<Models.User>> RegisterUser(string id, Models.User user)
        {
            try
            {
                var _user = context.Users.Find(u => u.Id == id).FirstOrDefault();
                if (_user != null)
                {
                    var newNetworks = user.SocialNetworks.ToList();
                    if (_user.SocialNetworks != null && _user.SocialNetworks.Length > 0)
                    {
                        if (newNetworks != null && newNetworks.Count > 0)
                        {
                            foreach(var networkInDb in _user.SocialNetworks)
                            {
                                if(newNetworks.FirstOrDefault(n => n == networkInDb) == null)
                                {
                                    newNetworks.Add(networkInDb);
                                }
                            } 
                        }
                        else if(newNetworks == null || newNetworks.Count == 0)
                        {
                            newNetworks = _user.SocialNetworks.ToList();
                        }
                    }
                    
                    var updatingList = new List<UpdateDefinition<Models.User>> {
                        Builders<Models.User>.Update.Set(v => v.Username, string.IsNullOrEmpty(user.Username) ? _user.Username : user.Username),
                        Builders<Models.User>.Update.Set(v => v.Password ,string.IsNullOrEmpty(user.Password) ? _user.Password : user.Password),
                        Builders<Models.User>.Update.Set(v => v.Name ,string.IsNullOrEmpty(user.Name) ? _user.Name : user.Name),
                        Builders<Models.User>.Update.Set(v => v.Surname ,string.IsNullOrEmpty(user.Surname) ? _user.Surname : user.Surname),
                        Builders<Models.User>.Update.Set(v => v.Email ,string.IsNullOrEmpty(user.Email) ? _user.Email : user.Email),
                        Builders<Models.User>.Update.Set(v => v.CellNumber ,string.IsNullOrEmpty(user.CellNumber) ? _user.CellNumber : user.CellNumber),
                        Builders<Models.User>.Update.Set(v => v.SocialNetworks ,newNetworks.ToArray()),
                        Builders<Models.User>.Update.Set(v => v.NumberOfFollowers ,user.NumberOfFollowers == 0 ? _user.NumberOfFollowers : user.NumberOfFollowers),
                        Builders<Models.User>.Update.Set(v => v.TopicsOfInterest, user.TopicsOfInterest)
                    };
                    
                    var answer = await context.Users.UpdateOneAsync(
                        Builders<Models.User>.Filter.Eq(u => u.Id, id),
                        Builders<Models.User>.Update.Combine(updatingList)
                    );
                    
                }       
            }
            catch (Exception ex) {
                return new Response<Models.User>
                {
                    Data = null,
                    Message = ex.Message + "update user",
                    Status = false
                };
            }
            return null;
        }
    }
}
