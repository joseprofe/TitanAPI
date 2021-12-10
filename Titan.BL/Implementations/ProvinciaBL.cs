using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Titan.BL.Contracts;
using Titan.Core.DTO;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Contracts;

namespace Titan.BL.Implementations
{
    public class ProvinciaBL : IProvinciaBL
    {
        public IProvinciaRepository provinciaRepository { get; set; }
        public IMapper mapper { get; set; }
        public ProvinciaBL(IProvinciaRepository provinciaRepository, IMapper mapper)
        {
            this.provinciaRepository = provinciaRepository;
            this.mapper = mapper;
        }
        public ProvinciaDTO Get(int id)
        {
            return mapper.Map<Provincia, ProvinciaDTO>(provinciaRepository.Get(id));
        }

        public List<ProvinciaDTO> GetAll()
        {
            return mapper.Map<List<Provincia>, List<ProvinciaDTO>> (provinciaRepository.GetAll());
        }

        public List<ProvinciaDTO> Filter(ProvinciaCriteriaDTO criteriaDTO)
        {
            var provincia = mapper.Map<ProvinciaCriteriaDTO, Provincia>(criteriaDTO);
            return mapper.Map<List<Provincia>, List<ProvinciaDTO>>(provinciaRepository.Filter(provincia));
        }
    }
}
