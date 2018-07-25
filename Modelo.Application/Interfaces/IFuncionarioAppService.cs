using Modelo.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Modelo.Application.Interfaces
{
    public interface IFuncionarioAppService : IDisposable
    {
        void Register(FuncionarioViewModel funcionarioViewModel);
        IEnumerable<FuncionarioViewModel> GetAll();
        FuncionarioViewModel GetById(Guid id);
        void Update(FuncionarioViewModel funcionarioViewModel);
        void Remove(Guid id);
    }
}
