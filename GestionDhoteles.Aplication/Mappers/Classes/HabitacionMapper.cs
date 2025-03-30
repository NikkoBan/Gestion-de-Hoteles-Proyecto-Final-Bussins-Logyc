using GestionDhoteles.Aplication.Dtos.HabitacionServiceDto;
using GestionDhoteles.Aplication.Mappers.Interfaces;
using GestionDhoteles.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Mappers.Classes
{
    public class HabitacionMapper : BaseMapper<SaveHabitacionSDto, UpdateHabitacionSDto, RemoveHabitacionSDto, Habitacion>, IHabitacionMapper
    {
        public override List<UpdateHabitacionSDto> DtoList(List<Habitacion> entities)
        {
            return entities.Select(entity => new UpdateHabitacionSDto()
            {
                IdHabitacion = entity.id,
                IdCategoria = entity.IdCategoria,
                IdEstadoHabitacion = entity.IdEstadoHabitacion,
                IdPiso = entity.IdPiso,
                Detalle = entity.Detalle!,
                Estado = entity.EstadoYFecha.Estado,
                Numero = entity.Numero!,
                Fecha = (DateTime)entity.EstadoYFecha.FechaCreacion!,
                Usuario = (int)entity.CreadorPorU!
            }).ToList();
        }

        public override UpdateHabitacionSDto EntityToDto(Habitacion entity)
        {
            UpdateHabitacionSDto dto = new UpdateHabitacionSDto();
            dto.IdHabitacion = entity.id;
            dto.IdEstadoHabitacion = entity.IdEstadoHabitacion;
            dto.IdCategoria = entity.IdCategoria;
            dto.IdPiso = entity.IdPiso;
            dto.Estado = entity.EstadoYFecha.Estado;
            dto.Fecha = (DateTime)entity.EstadoYFecha.FechaCreacion!;
            dto.Usuario = (int)entity.CreadorPorU!;
            dto.Numero = entity.Numero!;
            return dto;
        }

        public override Habitacion RemoveDtoToEntity(RemoveHabitacionSDto dto, Habitacion entity)
        {
            entity.FechaModificacion = dto.Fecha;
            entity.UsuarioMod = dto.Usuario;
            entity.Borrado = true;
            entity.BorradoPorU = dto.Usuario;
            return entity;
        }

        public override Habitacion SaveDtoToEntity(SaveHabitacionSDto dto)
        {
            Habitacion h = new Habitacion();
            h.Capacidad = dto.Capacidad;
            h.IdEstadoHabitacion = dto.IdEstadoHabitacion;
            h.IdCategoria = dto.IdCategoria;
            h.CreadorPorU = dto.Usuario;
            h.Numero = dto.Numero;
            h.IdPiso = dto.IdPiso;
            h.Detalle = dto.Detalle;
            h.EstadoYFecha.Estado = dto.Estado;
            h.EstadoYFecha.FechaCreacion = dto.Fecha;
            h.Borrado = false;
            return h;
        }

        public override Habitacion UpdateDtoToEntity(UpdateHabitacionSDto dto, Habitacion h)
        {
            h.Capacidad = dto.Capacidad;
            h.IdEstadoHabitacion = dto.IdEstadoHabitacion;
            h.IdCategoria = dto.IdCategoria;
            h.UsuarioMod = dto.Usuario;
            h.Numero = dto.Numero;
            h.IdPiso = dto.IdPiso;
            h.Detalle = dto.Detalle;
            h.EstadoYFecha.Estado = dto.Estado;
            h.FechaModificacion = dto.Fecha;
            return h;
        }
    }
}
