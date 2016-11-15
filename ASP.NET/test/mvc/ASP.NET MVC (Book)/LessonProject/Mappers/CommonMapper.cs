using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using LessonProject.Models;
using LessonProject.Models.ViewModels;

namespace LessonProject.Mappers
{
    public class CommonMapper : IMapper
    {
        static CommonMapper()
        {
            Mapper.CreateMap<User, UserView>()
                    .ForMember(dest => dest.BirthdateDay, opt => opt.MapFrom(src => src.Birthdate.Day))
                    .ForMember(dest => dest.BirthdateMonth, opt => opt.MapFrom(src => src.Birthdate.Month))
                    .ForMember(dest => dest.BirthdateYear, opt => opt.MapFrom(src =>src.Birthdate.Year));
            Mapper.CreateMap<UserView, User>()
                    .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => new DateTime(src.BirthdateYear, src.BirthdateMonth, src.BirthdateDay)));


            Mapper.CreateMap<Post, PostView>();
            Mapper.CreateMap<PostView, Post>();
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}