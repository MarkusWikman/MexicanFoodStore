using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace MexicanFoodStore.UI.Storage.Services
{
    public class LocalStorage(ILocalStorageService localStorage) : IStorageService
    {
        public async Task<T> GetAsync<T>(string key) =>
            await localStorage.GetItemAsync<T>(key);
        public async Task RemoveAsync(string key) =>
       await localStorage.RemoveItemAsync(key);
        public async Task SetAsync<T>(string key, T value) =>
       await localStorage.SetItemAsync(key, value);
    }

}
