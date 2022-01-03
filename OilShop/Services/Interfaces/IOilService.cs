using OilShop.Models.Oil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilShop.Services.Interfaces
{
    public interface IOilService
    {
        OilViewModel GetById(long Id);
        ReplaceOilViewModel GetByIdFull(long Id);
        OilViewModelList GetOils(int page, string SearchData);
        List<OilViewModel> GetAll();
        void Delete(long Id);
        void Create(ReplaceOilViewModel model);
        void Update(ReplaceOilViewModel model);
    }
}
