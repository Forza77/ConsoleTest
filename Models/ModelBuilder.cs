using ConsoleTest.Interfaces;
using ConsoleTest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.Models
{
    //ModelBuilder для создания моделей 
    public  class ModelBuilder
    {
        private readonly IDbRepository dbRepository;
        public ModelBuilder(IDbRepository dbRepository)
        {
            this.dbRepository = dbRepository;
        }
        public T CreateModel<T>()where T:BaseModel,new()
        {
            var model = new T();
            model.Create(dbRepository);
            return model;
        }
    }
}
