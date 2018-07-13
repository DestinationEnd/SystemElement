using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemElement.Models;

namespace SystemElement.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IElementRepository>().To<ElementRepository>();
        }
    }
}