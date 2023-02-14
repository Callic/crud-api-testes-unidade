using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Application.Responses
{
    public class GenericResponseList<T> : GenericResponseBase<GenericResponseList<T>>
    {
        public IEnumerable<T>Data{ get; set; } = new List<T>();
    }
}
