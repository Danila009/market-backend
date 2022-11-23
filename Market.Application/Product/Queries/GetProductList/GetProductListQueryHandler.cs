using AutoMapper;
using AutoMapper.QueryableExtensions;
using Market.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Application.Product.Queries.GetProductList
{
    internal class GetProductListQueryHandler
        : IRequestHandler<GetProductListQuery, ProductListVm>
    {
        private readonly IMarketDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductListQueryHandler(IMarketDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ProductListVm> Handle(GetProductListQuery request,
            CancellationToken cancellationToken)
        {
            IQueryable<Domain.Product.Product> query = _dbContext.Products
                .Include(u => u.Category)
                .Include(u => u.Images);

            if(request.Status != null)
            {
                query = query.Where(u => u.Status == request.Status);
            }

            if (!string.IsNullOrEmpty(request.Seacrh))
            {
                string search = request.Seacrh.ToLower();
                query = query.Where(u => u.Title.ToLower().Contains(search) 
                    || u.Title.ToLower().Contains(search));
            }

            if (request.ShopsId != null && request.ShopsId.Count > 0)
            {
                query = query.Where(u => u.Shops.Any(s => request.ShopsId.Contains(s.Id)));
            }

            if (request.CategoriesId != null && request.CategoriesId.Count > 0)
            {
                query = query.Where(u => request.CategoriesId.Contains(u.Category.Id));
            }

            var products =  await query
                .ProjectTo<ProductLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProductListVm { Products = products };
        }
    }
}
