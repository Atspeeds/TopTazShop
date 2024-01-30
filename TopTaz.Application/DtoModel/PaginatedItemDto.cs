using System.Collections.Generic;

namespace TopTaz.Application.DtoModel
{
    public class PaginatedItemDto<TEntity> where TEntity : class
    {
        public IList<TEntity> Models { get;private set; }
        public int PageIndex { get; private set; }
        public long Count { get; private set; }
        public int PageSize { get; private set; }

        public PaginatedItemDto(IList<TEntity> models, int pageIndex, long count, int pageSize)
        {
            Models = models;
            PageIndex = pageIndex;
            Count = count;
            PageSize = pageSize;
        }

    }
}
