using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.API.Mappers
{
    public interface IMapper<TIn, TOut>
    {
        void Fill(TIn input, TOut output);
        TOut Map(TIn input);
    }
}
