using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Contracts;

namespace Titan.DAL.Repositories.Implementations
{
    public class ProvinciaRepository : IProvinciaRepository
    {
        public pitufoContext context { get; set; }
        public ProvinciaRepository(pitufoContext context)
        {
            this.context = context;
        }
        public Provincia Get(int id)
        {
            return context.Provincias.FirstOrDefault(p => p.Id == id);
        }

        public List<Provincia> GetAll()
        {
            return context.Provincias.ToList();
        }

        public List<Provincia> Filter(Provincia criteria)
        {
            return context.Provincias.Where(p => p.Nombre.Contains(criteria.Nombre)).ToList();
        }
    }
}
