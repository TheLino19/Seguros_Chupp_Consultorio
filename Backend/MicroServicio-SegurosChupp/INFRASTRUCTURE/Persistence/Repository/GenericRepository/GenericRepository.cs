using INFRASTRUCTURE.Commons.Bases.Request;
using INFRASTRUCTURE.Helpers;
using System.Linq.Dynamic.Core;
namespace INFRASTRUCTURE.Persistence.Repository.GenericRepository;

public class GenericRepository<T>: IGenericRepository<T> where T : class
{
   protected IQueryable<TDTO> Ordening<TDTO>(BasePaginationRequest request, IQueryable<TDTO> queryable,
      bool pagination = false) where TDTO : class
   {
      IQueryable<TDTO> queryDto = request.Order?.ToLower() == "desc" 
         ? queryable.OrderBy(request.Sort + " descending")
         : queryable.OrderBy(request.Sort + " ascending");

      if( pagination)
        {
            queryDto.Paginate(request);
        }
      return queryDto;
   }
}   