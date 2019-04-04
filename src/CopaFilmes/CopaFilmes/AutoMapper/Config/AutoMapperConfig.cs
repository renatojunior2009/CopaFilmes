using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CopaFilmes.AutoMapper.Config
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize
                (
                    c =>
                    {
                        c.AddProfile<DomainToViewModelMapping>();                        
                    }
                );
        }
    }
}
