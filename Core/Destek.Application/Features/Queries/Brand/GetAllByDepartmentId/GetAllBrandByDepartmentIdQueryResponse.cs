using Destek.Application.DTOs.Brand;
using Destek.Application.DTOs.WarehouseCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.Brand.GetAllByDepartmentId
{
    public class GetAllBrandByDepartmentIdQueryResponse
    {
        public int TotalCount { get; set; }

        public List<BrandModelDto> Brands { get; set; }
    }
}
