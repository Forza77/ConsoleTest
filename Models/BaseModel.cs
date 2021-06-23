using ConsoleTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.Models
{
    //базовый класс моделей
    public abstract class BaseModel
    {
        private protected IDbRepository dbRepository;
        public void Create(IDbRepository dbRepository)
        {
            this.dbRepository = dbRepository;
        }
    }
}
