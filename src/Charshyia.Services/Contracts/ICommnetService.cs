using System;
using System.Collections.Generic;
using System.Text;

namespace Charshyia.Services.Contracts
{
    public interface ICommnetService
    {
        void AddCommentToProduct(int productId, string commentContent);

        void AddCommentToShop(int shopId, string commentContent);
    }
}
