using AutoMapper;
using Charshyia.Data;
using Charshyia.Data.Models;
using Charshyia.Services.Contracts;
using Charshyia.Services.Models;
using Charshyia.Services.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Charshyia.Services
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(CharshyiaDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        //public int AddProduct(ProductCreateInputModel inputModel, string producerId)
        //{
        //    var product = this.mapper.Map<Product>(inputModel);
        //    product.ProducerId = producerId;
        //    this.context.Products.Add(product);
        //    this.context.SaveChanges();

        //    return product.Id;
        //}

        //public ProductDetailsViewModel GetProductById(int productId)
        //{
        //    var product = this.context.Products.Find(productId);
        //    var viewModel = this.mapper.Map<ProductDetailsViewModel>(product);

        //    return viewModel;
        //}
    }
}
