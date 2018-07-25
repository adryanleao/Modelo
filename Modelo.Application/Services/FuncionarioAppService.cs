using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Modelo.Application.Interfaces;
using Modelo.Application.ViewModels;
using Modelo.Domain.Commands.Funcionario;
using Modelo.Domain.Core.Bus;
using Modelo.Domain.Interfaces;

namespace Modelo.Application.Services
{
    public class FuncionarioAppService : IFuncionarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMediatorHandler Bus;

        public FuncionarioAppService(IMapper mapper,
                                  IFuncionarioRepository funcionarioRepository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _funcionarioRepository = funcionarioRepository;
            Bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<FuncionarioViewModel> GetAll()
        {
            return _funcionarioRepository.GetAll().ProjectTo<FuncionarioViewModel>();
        }

        public FuncionarioViewModel GetById(Guid id)
        {
            return _mapper.Map<FuncionarioViewModel>(_funcionarioRepository.GetById(id));
        }

        public void Register(FuncionarioViewModel funcionarioViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewFuncionarioCommand>(funcionarioViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveFuncionarioCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Update(FuncionarioViewModel funcionarioViewModel)
        {
            var updateCommand = _mapper.Map<UpdateFuncionarioCommand>(funcionarioViewModel);
            Bus.SendCommand(updateCommand);
        }
    }
}
