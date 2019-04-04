﻿
using AutoMapper;
using CopaFilmes.DomainApp.Entities;
using CopaFilmes.Model;

namespace CopaFilmes.AutoMapper
{
    public class DomainToViewModelMapping : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMapping";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Movie, MovieModel>().ReverseMap();
        }
    }
}
