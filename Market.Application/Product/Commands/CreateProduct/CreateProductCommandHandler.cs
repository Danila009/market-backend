using Market.Application.Interfaces;
using Market.Application.Common.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Market.Domain.Product;

namespace Market.Application.Product.Commands.CreateProduct
{
    internal class CreateProductCommandHandler
        : IRequestHandler<CreateProductCommand, CreateProductVm>
    {
        private readonly IMarketDbContext _dbContext;

        public CreateProductCommandHandler(IMarketDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<CreateProductVm> Handle(CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            if(request.ShopsId == null)
            {
                throw new ArgumentException("not found shop");
            }

            List<Domain.Shop.Shop> shops = new List<Domain.Shop.Shop>();

            foreach(int shopId in request.ShopsId)
            {
                var shop = await _dbContext.Shops.FindAsync(shopId);

                if (shop == null)
                {
                    throw new NotFoundException(nameof(Domain.Shop.Shop), shopId);
                }else
                {
                    shops.Add(shop);
                }
            }

            var category = await _dbContext.Categories.FindAsync(request.CategoryId);

            if (category == null)
            {
                throw new NotFoundException(nameof(Domain.Product.Filters.Category)
                    , request.CategoryId);
            }

            var product = new Domain.Product.Product
            {
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                Category = category,
                DateCreation = DateTime.Now,
                Shops = shops,
                Status = ProductStatus.ACTIVE
            };


            await _dbContext.Products.AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new CreateProductVm { ProductId = product.Id };
        }
    }
}
