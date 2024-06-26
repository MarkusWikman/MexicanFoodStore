﻿namespace MexicanFoodStore.Data.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; } = string.Empty;
        public string? PictureURL { get; set; } = string.Empty;
        public int Amount { get; set; } = 1; // Customer will be able to choose more but its always automatically one
        public List<Category>? Categories { get; set; }
    }
}
