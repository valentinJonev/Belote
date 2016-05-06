using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Belot.Backend.ViewModels;

namespace Belot.Backend.Common
{
    public abstract class BaseService
    {
        protected static IQueryable<T> ApplyPaging<T>(IQueryable<T> query, PagingModel paging)
        {
            if (paging.Offset.HasValue && paging.Offset.Value > 0)
            {
                query = query.Skip(paging.Offset.Value);
            }

            if (paging.Limit.HasValue && paging.Limit.Value > 0)
            {
                query = query.Take(paging.Limit.Value);
            }

            return query;
        }
    }
}
