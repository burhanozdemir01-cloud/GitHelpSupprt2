using Destek.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Helpers
{
    public static class UnitOfMeasureHelper
    {
        public static string GetDisplayName(UnitOfMeasureType unitOfMeasureType)
        {
            return unitOfMeasureType switch
            {
                UnitOfMeasureType.Piece => "Adet",
                UnitOfMeasureType.Meter => "Metre",
                UnitOfMeasureType.Centimeter => "Santimetre",
                UnitOfMeasureType.Package => "Paket",
                UnitOfMeasureType.Kilogram => "Kilogram",
                UnitOfMeasureType.Gram => "Gram",
                _ => "Bilinmiyor"
            };
        }
    }
}
