using BookHeaven.Core.Service.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Core.Services.Storage
{
    public interface IStorageManager 
    {
        IStorage GetStorage(string key);
        IStorage GetStorage();

    }
}
