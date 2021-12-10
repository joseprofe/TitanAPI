using System;
using System.Collections.Generic;
using System.Text;
using Titan.Core.DTO;

namespace Titan.BL.Contracts
{
    public interface IProvinciaBL
    {
        public ProvinciaDTO Get(int id);
        public List<ProvinciaDTO> GetAll();
        public List<ProvinciaDTO> Filter(ProvinciaCriteriaDTO criteriaDTO);
    }
}
