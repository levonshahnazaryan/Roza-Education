using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class EduRepasitory : IEduRepasitory
    {
        private EduDBContext _dbContext;
        public EduRepasitory()
        {
            _dbContext = new EduDBContext();
        }
    }
}