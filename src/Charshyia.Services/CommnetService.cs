using AutoMapper;
using Charshyia.Data;
using Charshyia.Data.Models;
using Charshyia.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Charshyia.Services
{
    public class CommnetService : BaseService, ICommnetService
    {
        public CommnetService(CharshyiaDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public void AddCommentToProduct(int productId, string commentContent)
        {
            this.DbContext
                .ProductComments
                .Add(new ProductComment { ProductId = productId, Content = commentContent});

            this.DbContext.SaveChanges();
        }
    }
}
