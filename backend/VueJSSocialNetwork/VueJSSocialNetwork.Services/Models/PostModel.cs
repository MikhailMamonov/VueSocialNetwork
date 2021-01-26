using AutoMapper;

using System;
using VueJSSocialNetwork.Common.Mapping;
using VueJSSocialNetwork.Data.Entities;

namespace VueJSSocialNetwork.Services.Models
{
    public class PostModel : IMapFrom<Post>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public int Likes { get; set; }

        public byte[] Photo { get; set; }

        public byte[] UserProfilePicture { get; set; }

        public string UserId { get; set; }

        public string UserFullName { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            //profile.CreateMap<Post, PostModel>()
            //    .ForMember(p => p.UserProfilePicture, cfg => cfg.MapFrom(p => p.User.PictureUrl))
            //    .ForMember(p => p.UserFullName, cfg => cfg.MapFrom(p => p.User.FirstName + " " + p.User.LastName));
        }
    }
}