using AutoMapper;
using Charshyia.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Charshyia.Services
{
    public abstract class BaseService
    {
        private readonly CharshyiaDbContext context;
        private readonly IMapper mapper;

        protected BaseService(CharshyiaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        protected CharshyiaDbContext DbContext
        {
            get
            {
                return this.context;
            }
        }

        protected IMapper Mapper
        {
            get
            {
                return this.mapper;
            }
        }

    }
}
