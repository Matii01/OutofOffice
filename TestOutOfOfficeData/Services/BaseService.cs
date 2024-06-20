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

        protected BaseService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
