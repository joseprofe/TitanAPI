using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.DAL.Repositories.Contracts
{
    public interface IProvinciaRepository
    {
        public Provincia Get(int id);
        public List<Provincia> GetAll();
        public List<Provincia> Filter(Provincia criteria);
    }
}
