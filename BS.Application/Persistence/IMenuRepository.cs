using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BS.Domain.MenuAggregates;

namespace BS.Application.Persistence
{
    public interface IMenuRepository
    {
        void Add(BS.Domain.MenuAggregates.Menu menu);
    }
}
