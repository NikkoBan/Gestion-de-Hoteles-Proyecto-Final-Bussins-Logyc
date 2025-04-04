﻿

using GestionDhoteles.Domain.Base;

namespace GestionDhoteles.Aplication.Dtos
{
    public interface IBaseService<TDtoSave, TDtoUpdate, TDtoRemove>
    {
        Task<OperationResult> GetAll();
        Task<OperationResult> GetById(int Id);
        Task<OperationResult> Update(TDtoUpdate dto);
        Task<OperationResult> Remove(TDtoRemove dto);
        Task<OperationResult> Save(TDtoSave dto);
    }
    public class DtoBase
    {
        public DateTime Fecha { get; set; }
        public int Usuario { get; set; }
    }
}
