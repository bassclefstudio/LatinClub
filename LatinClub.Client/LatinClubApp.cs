using Autofac;
using BassClefStudio.AppModel.Lifecycle;
using System;
using System.Collections.Generic;
using System.Text;

namespace BassClefStudio.LatinClub.Client
{
    public class LatinClubApp : App
    {
        public LatinClubApp() : base("LatinClub.Client")
        { }

        protected override void ConfigureServices(ContainerBuilder builder)
        {
            builder.RegisterViewModels(typeof(LatinClubApp).Assembly);
        }
    }
}
