using Blazored.SessionStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazored.SessionStorage;

namespace MexicanFoodStore.UI.Storage.Services
{
    public class SessionStorage(ISessionStorageService sessionStorage) : IStorageService
    {
        public async Task<T> GetAsync<T>(string key) =>
            await sessionStorage.GetItemAsync<T>(key);
        public async Task RemoveAsync(string key) =>
       await sessionStorage.RemoveItemAsync(key);
        public async Task SetAsync<T>(string key, T value) =>
       await sessionStorage.SetItemAsync(key, value);
    }
}
