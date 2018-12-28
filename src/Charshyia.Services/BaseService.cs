using AutoMapper;
using Charshyia.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Charshyia.Services
{
    public abstract class BaseService
    {
        protected readonly CharshyiaDbContext context;
        protected readonly IMapper mapper;

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
