using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotLiquid;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
    public class ServiceReference : ILiquidizable
    {
        private Models.NavigationProperty Navigation {get; set;}
        public ServiceReference(Models.NavigationProperty navigation)
        {
            Navigation = navigation;
        }

        public string Name => this.Navigation.Name;

        public object ToLiquid()
        {
            return new {Name=this.Name};
        }
    }
}