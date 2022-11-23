using Market.Application.Interfaces;
using Market.Application.Common.Exceptions;
using Market.Application.Repositories.ImageRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Market.Application.Product.Commands.SaveImageProduct
{
    public class SaveImageProductCommandHandler
        : IRequestHandler<SaveImageProductCommand, SaveImageProductVm>
    {
        private readonly IMarketDbContext _dbContext;
        private readonly IImageRepository _imageRepository;

        public SaveImageProductCommandHandler(IMarketDbContext dbContext,
            IImageRepository imageRepository) =>
            (_dbContext, _imageRepository) = (dbContext, imageRepository);

        public async Task<SaveImageProductVm> Handle(SaveImageProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(u => u.Id == request.ProductId);
            if (product == null)
            {
                throw new NotFoundException(nameof(Domain.Product.Product), request.ProductId);
            }
            /*
            var memoryStream = new MemoryStream();
            string path = "images/";

            await request.Image.CopyToAsync(memoryStream);
            var imageId = _imageRepository.Save(memoryStream.ToArray(), path);

            var url = $"/api/Product/{imageId}_image.jpg";

            product.Images.Add(new Domain.Image
            {
                Id = imageId,
                Url = url
            });

            await _dbContext.SaveChangesAsync(cancellationToken);
            */
            return new SaveImageProductVm
            {
                Url = "url"
            };
        }
    }
}
