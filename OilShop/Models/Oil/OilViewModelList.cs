using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilShop.Models.Oil
{
    public class OilViewModelList
    {
        public int Page { get; set; }
        public int MaxPage { get; set; }
        public List<OilViewModel> List { get; set; }
    }
}
