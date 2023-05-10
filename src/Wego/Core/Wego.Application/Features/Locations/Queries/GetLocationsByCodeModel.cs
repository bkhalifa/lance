using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wego.Application.Features.Locations.Queries
{
    public  class GetLocationsByCodeModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
    }
}
