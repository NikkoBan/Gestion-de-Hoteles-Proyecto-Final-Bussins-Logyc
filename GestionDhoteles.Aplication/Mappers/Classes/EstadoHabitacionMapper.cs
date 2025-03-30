using GestionDhoteles.Aplication.Dtos.EstadoHabitacionServiceDto;
using GestionDhoteles.Aplication.Mappers.Interfaces;
using GestionDhoteles.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Mappers.Classes
{
    public class EstadoHabitacionMapper : BaseMapper<SaveEstadoHabitacionSDto, UpdateEstadoHabitacionSDto, RemoveEstadoHabitacionSDto, EstadoHabitacion>, IEstadoHabitacionMapper
    {
        public override List<UpdateEstadoHabitacionSDto> DtoList(List<EstadoHabitacion> entities)
        {
            return entities.Select(e => new UpdateEstadoHabitacionSDto()
            {
                Descripcion = e.Descripcion!,
                Estado = (bool)e.EstadoYFecha.Estado!,
                Fecha = (DateTime)e.EstadoYFecha.FechaCreacion!,
                IdEstadoHabitacion = e.id,
                Usuario = (int)e.Creador!,
            }).ToList();
        }

        public override UpdateEstadoHabitacionSDto EntityToDto(EstadoHabitacion entity)
        {
            UpdateEstadoHabitacionSDto dto = new UpdateEstadoHabitacionSDto();
            dto.IdEstadoHabitacion = entity.id;
            dto.Descripcion = entity.Descripcion!;
            dto.Usuario = (int)entity.Creador!;
            dto.Fecha = (DateTime)entity.EstadoYFecha.FechaCreacion!;
            dto.Estado = (bool)entity.EstadoYFecha.Estado!;
            return dto;
        }

        public override EstadoHabitacion RemoveDtoToEntity(RemoveEstadoHabitacionSDto dto, EstadoHabitacion entity)
        {
            entity.FechaModificacion = dto.Fecha;
            entity.UsuarioMod = dto.Usuario;
            entity.Borrado = true
            entity.Borrador = dto.Usuario;
            return entity;
        }

        public override EstadoHabitacion SaveDtoToEntity(SaveEstadoHabitacionSDto dto)
        {
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = dto.Descripcion;
            estado.EstadoYFecha.FechaCreacion = dto.Fecha;
            estado.EstadoYFecha.Estado = dto.Estado;
            estado.CreadorforU = dto.Usuario;
            estado.Borrado = false;
            return estado;
        }

        public override EstadoHabitacion UpdateDtoToEntity(UpdateEstadoHabitacionSDto dto, EstadoHabitacion entity)
        {
            entity.Descripcion = dto.Descripcion;
            entity.FechaModificacion = dto.Fecha;
            entity.EstadoYFecha.Estado = dto.Estado;
            entity.UsuarioMod = dto.Usuario;
            return entity;
        }
    }
}
