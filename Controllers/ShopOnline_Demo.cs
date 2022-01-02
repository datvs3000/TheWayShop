using ShopOnlineDemo.Models;
using System;
using System.Collections.Generic;

namespace ShopOnlineDemo.Controllers
{
    internal class ShopOnline_Demo
    {
        public IEnumerable<object> SanPhams { get; internal set; }

        public static implicit operator ShopOnline_Demo(ShopOnline_DemoEntities v)
        {
            throw new NotImplementedException();
        }
    }
}