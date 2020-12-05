using BassClefStudio.AppModel.Lifecycle;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BassClefStudio.LatinClub.Client.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var app = new BlazorApplication(new LatinClubApp(), typeof(Program).Assembly);
            await app.ActivateAsync<App>(args);
        }
    }
}
