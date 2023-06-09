using AutoMapper;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writely.BLL.ErrorCodes.Address;
using Writely.BLL.Infrastructure.Domains;
using Writely.BLL.ServiceModels.ResponseModels.Address;
using Writely.BLL.Services.IService.Address;
using Writely.DAL.Repositories.IRepository.Address;

namespace Writely.BLL.Services.Service.Address
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;
        public StateService(IStateRepository stateRepository, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }
        public async Task<OneOf<List<StateDisplayModel>, WritelyError>> GetAllStates(CancellationToken cancellationToken = default)
        {
            try
            {
                var stateList = await _stateRepository.GetAllState();
                if (stateList.Count <= 0)
                {
                    return new ErrorFetchingState();
                }
                else
                {
                    var returnModel = _mapper.Map<List<StateDisplayModel>>(stateList);
                    return returnModel;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OneOf<List<StateDisplayModel>, WritelyError>> GetStatesByCountryId(int countryId, CancellationToken cancellationToken = default)
        {
            try
            {
                var stateList = await _stateRepository.GetStatesByCountryId(countryId);
                return stateList.Count <= 0 ? new List<StateDisplayModel>() : _mapper.Map<List<StateDisplayModel>>(stateList);
            }
            catch (Exception ex)
            {
                var error = new ErrorFetchingState(ex);
                return error;
            }
        }
    }
}
