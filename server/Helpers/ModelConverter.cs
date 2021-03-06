﻿using LearnQuickOnline.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnQuickOnline.Helpers
{
    public static class ModelConverter
    {
        public static Models.User ConvertUserToDatabaseFormat(ViewUserModel user)
        {
            return new Models.User
            {
                Id = user.Id,
                Username = user.Username,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                CellNumber = user.CellNumber,
                SocialNetworks = user.SocialNetworks,
                TopicsOfInterest = user.TopicsOfInterest,
                IsActive = user.IsActive,
                NumberOfFollowers = user.NumberOfFollowers,
            };
        }

        public static ViewUserModel ConvertUserToViewModel(Models.User user)
        {
            return new ViewUserModel
            {
                Id = user.Id,
                Username = user.Username,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                CellNumber = user.CellNumber,
                SocialNetworks = user.SocialNetworks,
                TopicsOfInterest = user.TopicsOfInterest,
                IsActive = user.IsActive,
                NumberOfFollowers = user.NumberOfFollowers,
            };

        }
    }
    }
