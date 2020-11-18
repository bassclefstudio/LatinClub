using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace LatinClub.Uno.Skia.Tizen
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new LatinClub.Uno.App(), args);
            host.Run();
        }
    }
}
