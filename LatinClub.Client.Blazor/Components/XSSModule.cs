using Autofac;
using BassClefStudio.AppModel.Lifecycle;
using Ganss.XSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BassClefStudio.LatinClub.Client.Blazor.Components
{
    public class XSSModule : Module, IPlatformModule
    {
        public string Name { get; } = "XSS Sanitizer";

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                // Configure sanitizer rules as needed here.
                // For now, just use default rules + allow class attributes
                var sanitizer = new HtmlSanitizer();
                sanitizer.AllowedAttributes.Add("class");
                return sanitizer;
            }).As<IHtmlSanitizer>();
        }
    }
}
