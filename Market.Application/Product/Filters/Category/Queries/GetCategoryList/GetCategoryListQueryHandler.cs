using AutoMapper;
using Market.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace Market.Application.Product.Filters.Category.Queries.GetCategoryList
{
    internal class GetCategoryListQueryHandler
        : IRequestHandler<GetCategoryListQuery, CategoryListVm>
    {
        private readonly IMarketDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCategoryListQueryHandler(IMarketDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CategoryListVm> Handle(GetCategoryListQuery request,
            CancellationToken cancellationToken)
        {
            IQueryable<Domain.Product.Filters.Category> query = _dbContext.Categories;

            if (!string.IsNullOrEmpty(request.Search))
            {
                query = query.Where(u => u.Name.ToLower().Contains(request.Search.ToLower()));
            }


            var categories = await query
                .ProjectTo<CategoryLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CategoryListVm { Categories = categories };
        }
    }
}
