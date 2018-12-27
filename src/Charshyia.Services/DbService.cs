using Charshyia.Data;
using Charshyia.Services.Contracts;
using System;
using System.Linq;

namespace Charshyia.Services
{
    public class DbService : IDbService
    {
        private readonly CharshyiaDbContext db;

        public DbService(CharshyiaDbContext context)
        {
            this.db = context;
        }
    }
}
