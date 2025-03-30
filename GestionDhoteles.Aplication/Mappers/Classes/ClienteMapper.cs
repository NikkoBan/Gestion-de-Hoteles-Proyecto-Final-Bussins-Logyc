using GestionDhoteles.Aplication.Dtos.ClienteServisDto;
using GestionDhoteles.Aplication.Mappers.Interfaces;
using GestionDhoteles.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Mappers.Classes
{
    public sealed class ClienteMapper : BaseMapper<SaveClienteSDtos, UpdateClienteSDtos, RemoveClienteSDto, Cliente>, IClienteMapper
    {
        public override List<UpdateClienteSDtos> DtoList(List<Cliente> entities)
        {
            return entities.Select(entity => new UpdateClienteSDtos()
            {
                IdCliente = entity.id,
                TipoDocumento = entity.TipoDocumento,
                Documento = entity.Documento,
                NombreCompleto = entity.NombreCompleto,
                Correo = entity.Correo,
                Usuario = (int)entity.CreadorPorU!
            }).ToList();
        }

        public override UpdateClienteSDtos EntityToDto(Cliente entity)
        {
            UpdateClienteSDtos dto = new UpdateClienteSDtos();
            dto.TipoDocumento = entity.TipoDocumento;
            dto.Documento = entity.Documento;
            dto.NombreCompleto = entity.NombreCompleto;
            dto.Correo = entity.Correo;
            return dto;
        }

        public override Cliente RemoveDtoToEntity(RemoveClienteSDto dto, Cliente entity)
        {
            entity.FechaModificacion = dto.Fecha;
            entity.UsuarioMod = dto.Usuario;
            entity.Borrado = dto.Borrado;
            return entity;
        }

        public override Cliente SaveDtoToEntity(SaveClienteSDtos dto)
        {
            Cliente entity = new Cliente();
            entity.TipoDocumento = dto.TipoDocumento;
            entity.Documento = dto.Documento;
            entity.NombreCompleto = dto.NombreCompleto;
            entity.Correo = dto.Correo;
            entity.CreadorPorU = dto.Usuario;
            entity.Borrado = false;
            return entity;
        }

        public override Cliente UpdateDtoToEntity(UpdateClienteSDtos dto, Cliente entity)
        {
            entity.TipoDocumento = dto.TipoDocumento;
            entity.Documento = dto.Documento;
            entity.NombreCompleto = dto.NombreCompleto;
            entity.Correo = dto.Correo;
            entity.FechaModificacion = dto.Fecha;
            entity.UsuarioMod = dto.Usuario;
            return entity;
        }
    }
}
