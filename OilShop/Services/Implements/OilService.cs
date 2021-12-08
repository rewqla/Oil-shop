using AutoMapper;
using OilShop.Entities;
using OilShop.Models.Oil;
using OilShop.Repo.Implement;
using OilShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilShop.Services.Implements
{
    public class OilService : IOilService
    {
        private readonly IOilRepo _oilRepo;
        private readonly IMapper _mapper;
        public OilService(IOilRepo oilRepo, IMapper mapper)
        {
            _oilRepo = oilRepo;
            _mapper = mapper;
        }

        public void Create(ReplaceOilViewModel model)
        {
            _oilRepo.Add(_mapper.Map<Oil>(model));
        }

        public void Delete(long Id)
        {
            var model = _oilRepo.GetAll().FirstOrDefault(x => x.Id == Id);
            _oilRepo.Delete(model);
        }

        public OilViewModel GetById(long Id)
        {
            var model = _oilRepo.GetAll().FirstOrDefault(x => x.Id == Id);
            return _mapper.Map<OilViewModel>(model);
        }

        public List<OilViewModel> GetAll()
        {
            var models = _oilRepo.GetAll();
            return _mapper.Map<List<OilViewModel>>(models);
        }

        public void Update(ReplaceOilViewModel model)
        {
            _oilRepo.Update(_mapper.Map<Oil>(model));
        }

        public ReplaceOilViewModel GetByIdFull(long Id)
        {
            var model = _oilRepo.GetAll().FirstOrDefault(x => x.Id == Id);
            return _mapper.Map<ReplaceOilViewModel>(model);
        }
    }
}
