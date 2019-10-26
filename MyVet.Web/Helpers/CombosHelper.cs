using Microsoft.AspNetCore.Mvc.Rendering;
using MyVet.Web.Data;
using System.Collections.Generic;
using System.Linq;

namespace MyVet.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _datacontext;

        public CombosHelper(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public IEnumerable<SelectListItem> GetComboPetTypes()
        {
            var list = _datacontext.PetTypes.Select(pt => new SelectListItem
            {
                Text = pt.Name,
                Value = $"{pt.Id}"
            }).OrderBy(pt => pt.Text)
              .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a pet type...]",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboServiceTypes()
        {
            var list = _datacontext.ServiceTypes.Select(pt => new SelectListItem
            {
                Text = pt.Name,
                Value = $"{pt.Id}"
            }).OrderBy(pt => pt.Text)
              .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a service type...]",
                Value = "0"
            });
            return list;
        }
    }
}
