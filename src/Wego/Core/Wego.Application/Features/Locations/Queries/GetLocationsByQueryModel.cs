using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wego.Application.Features.Locations.Queries
{
    public class GetLocationsByQueryModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string ParentName { get; set; }
        public LocationType LocationType { get; set; }
    }

    public enum LocationType
    {
        ZipCode = 1,
        City = 2,
        Region = 3,
    }
}
