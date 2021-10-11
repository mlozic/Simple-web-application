using AutoMapper;
using ProjektniZadatak.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektniZadatak.App_Start
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            Mapper.CreateMap<Kupac, KupciDto>();
            Mapper.CreateMap<KupciDto, Kupac>();
            Mapper.CreateMap<ProizvodiDto, Proizvod>();
            Mapper.CreateMap<Proizvod, ProizvodiDto>();
            Mapper.CreateMap<Potkategorija, PotkategorijeDto>();
            Mapper.CreateMap<PotkategorijeDto, Potkategorija>();
            Mapper.CreateMap<Kategorija, KategorijeDto>();
            Mapper.CreateMap<KategorijeDto, Kategorija>();
            Mapper.CreateMap<GradoviDto, Grad>();
            Mapper.CreateMap<Grad, GradoviDto>();
            
    }

    }
}