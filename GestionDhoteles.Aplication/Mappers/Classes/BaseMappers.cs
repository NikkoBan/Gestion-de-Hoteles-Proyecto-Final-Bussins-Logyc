using GestionDhoteles.Aplication.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Mappers.Classes
{
    public abstract class BaseMapper<TDtoSave, TDtoUpdate, TDtoRemove, TENtity> : IBaseMapper<TDtoSave, TDtoUpdate, TDtoRemove, TENtity>
    {
        public abstract TDtoUpdate EntityToDto(TENtity entity);
        public abstract TENtity RemoveDtoToEntity(TDtoRemove dto, TENtity entity);
        public abstract TENtity SaveDtoToEntity(TDtoSave dto);
        public abstract TENtity UpdateDtoToEntity(TDtoUpdate dto, TENtity entity);
        public abstract List<TDtoUpdate> DtoList(List<TENtity> entities);
    }
}
