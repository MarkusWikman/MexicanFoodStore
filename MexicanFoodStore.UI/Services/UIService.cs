using MexicanFoodStore.API.DTO.DTOs;
using MexicanFoodStore.API.DTO;
using MexicanFoodStore.UI.Models.Link;
using MexicanFoodStore.UI.Http.Clients;

namespace MexicanFoodStore.UI.Services
{
    public class UIService(CategoryHttpClient categoryHttp,
    ProductHttpClient productHttp, IMapper mapper, IStorageService storage)
    {
        public List<CategoryGetDTO> Categories { get; set; } = [];
        public List<ProductGetDTO> Products { get; private set; } = [];
        public List<ProductGetDTO> CartItems { get; private set; } = [];
        public List<LinkGroup> CaregoryLinkGroups { get; private set; } =
        [
            new LinkGroup {
            Name = "Categories"
        }
        ];
        public int CurrentCategoryId { get; set; }

        //public async Task<List<CategoryGetDTO>> GetAllCategories()
        //{
        //    var list = await categoryHttp.GetCategoriesAsync();
        //    return list.ToList();
        //}
        public async Task GetLinkGroup()
        {
            Categories = await categoryHttp.GetCategoriesAsync();
            CaregoryLinkGroups[0].LinkOptions = mapper.Map<List<LinkOption>>(Categories);
            var linkOption = CaregoryLinkGroups[0].LinkOptions.FirstOrDefault();
            linkOption!.IsSelected = true;
        }

        public async Task OnCategoryLinkClick(int id)
        {
            CurrentCategoryId = id;
            await GetProductsAsync();

            CaregoryLinkGroups[0].LinkOptions.ForEach(l => l.IsSelected = false);
            CaregoryLinkGroups[0].LinkOptions.Single(l => l.Id.Equals(CurrentCategoryId)).IsSelected = true;
        }

        public async Task GetProductsAsync() =>
            Products = await productHttp.GetProductsAsync(CurrentCategoryId);
        //public async Task<List<T>> ReadStorage<T>(string key) /*where T : class*/
        //{
        //    if (string.IsNullOrEmpty(key) || storage is not null) return [];
        //    return await storage.GetAsync<List<T>>(key);
        //}
        //public async Task<T> ReadSingleStorage<T>(string key) /*where T : class*/
        //{
        //    return await storage.GetAsync<T>(key);
        //}
        //public async Task SaveToStorage<T>(string key, T value) /*where T : class*/
        //{
        //    if (string.IsNullOrEmpty(key) || storage is not null) return;
        //    await storage.SetAsync<T>(key, value);
        //}
        //public async Task RemoveFromStorage(string key) /*where T : class*/
        //{
        //    if (string.IsNullOrEmpty(key) || storage is not null) return;
        //    await storage.RemoveAsync(key);
        //}
    }
}
