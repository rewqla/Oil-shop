﻿using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using OilShop.Entities;
using OilShop.Helpers;
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
        private readonly IWebHostEnvironment _env;

        public OilService(IOilRepo oilRepo, IMapper mapper, IWebHostEnvironment env)
        {
            _oilRepo = oilRepo;
            _mapper = mapper;
            _env = env;
        }

        public void Create(ReplaceOilViewModel model)
        {
            string base64 = model.Image;
            model.Image = base64.urlCreator(_env, "");

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
            if (!model.Image.Contains("https"))
            {
                model.Image = "/" + model.Image;
            }
            return _mapper.Map<OilViewModel>(model);
        }

        public List<OilViewModel> GetAll()
        {
            var models = _oilRepo.GetAll();
            return _mapper.Map<List<OilViewModel>>(models);
        }

        public void Update(ReplaceOilViewModel model)
        {
            string base64 = model.Image;
            model.Image = base64.urlCreator(_env, "");
            _oilRepo.Update(_mapper.Map<Oil>(model));
        }

        public ReplaceOilViewModel GetByIdFull(long Id)
        {
            var model = _oilRepo.GetAll().FirstOrDefault(x => x.Id == Id);
            if (!model.Image.Contains("https"))
            {
                model.Image = "/" + model.Image;
            }
            return _mapper.Map<ReplaceOilViewModel>(model);
        }
    }
}
