using AutoMapper;
using MexicanFoodStore.Data.Services;
using MexicanFoodStore.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CategoryDbService(MexicanFoodStoreContext db, IMapper mapper) : DbService(db, mapper)
{
    public override async Task<List<TDto>> GetAsync<TEntity, TDto>()
    {
        //IncludeNavigationsFor<Filter>();
        //IncludeNavigationsFor<Product>();
        return await base.GetAsync<TEntity, TDto>();
    }
}
