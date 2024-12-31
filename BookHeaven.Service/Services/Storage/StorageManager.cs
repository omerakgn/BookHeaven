using BookHeaven.Core.Repositories;
using BookHeaven.Core.Service.Storage;
using BookHeaven.Core.Services;
using BookHeaven.Core.Services.Storage;
using BookHeaven.Core.Services.Storage.Azure;
using BookHeaven.Core.Services.Storage.Local;
using BookHeaven.Core.UnitOfWorks;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Service.Services.Storage
{
    public class StorageManager : IStorageManager
    {
        public IStorage AzureStorage { get; set; }
        public IStorage LocalStorage { get; set; }


        public StorageManager(IAzureStorage azureStorage, ILocalStorage localStorage)
        {
           AzureStorage = azureStorage;
           LocalStorage = localStorage;
        }

        public IStorage GetStorage(string key)
        {
           if(key == "azure")
            {
                return AzureStorage;
            }
           else if(key == "local")
            {
                return LocalStorage;
            }
            else
            {
                return LocalStorage;
            }
            
        }

        public IStorage GetStorage()
        {
            return LocalStorage;
        }
    }
}
