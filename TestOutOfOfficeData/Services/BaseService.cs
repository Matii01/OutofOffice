using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeData.Services
{
    public abstract class BaseService
    {
        protected ApplicationDbContext _context;
        protected readonly IMapper _mapper;
        protected BaseService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
