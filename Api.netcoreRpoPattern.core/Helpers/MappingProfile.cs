using Api.netcoreRpoPattern.core.Data;
using Api.netcoreRpoPattern.core.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.netcoreRpoPattern.core.Helpers
{
	public class MappingProfile:Profile
	{
        public MappingProfile()
        {
            CreateMap<Book, BookDetailsDTO>();
                
        }
    }
}
