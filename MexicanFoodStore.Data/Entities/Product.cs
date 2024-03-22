namespace MexicanFoodStore.Data.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
