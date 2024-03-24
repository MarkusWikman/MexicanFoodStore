using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MexicanFoodStore.API.DTO.DTOs
{
    public class CategoryPostDTO
    {
        public string Name { get; set; } = string.Empty;
    }
    public class CategoryPutDTO : CategoryPostDTO
    {
        public int Id { get; set; }
    }
    public class CategoryGetDTO : CategoryPutDTO
    {
        //public List<FilterGetDTO>? Filters { get; set; }

    }

    public class CategorySmallGetDTO : CategoryPutDTO
    {
    }
}
