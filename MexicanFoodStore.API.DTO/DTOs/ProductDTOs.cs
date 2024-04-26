namespace MexicanFoodStore.API.DTO;

public class ProductPostDTO
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PictureURL { get; set; } = string.Empty;
}
public class ProductPutDTO : ProductPostDTO
{
    public int Id { get; set; }
}
public class ProductGetDTO : ProductPutDTO
{
    //public List<FilterGetDTO>? Filters { get; set; }

}
public class CartItemDTO : ProductGetDTO
{
    //public List<FilterGetDTO>? Filters { get; set; }

}

