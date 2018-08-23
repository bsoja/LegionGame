using System.IO;
using System.Reflection;
using Autofac;

namespace Legion
{
    class Program
    {
        static void Main(string[] args)
        {
            // dotnet core sets current directory to the src folder by default
            // we need to change it to the folder where executable file location is
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

            var libsLoader = new MonoGameLibLoader();
            libsLoader.LoadLibs();

            using(var game = new LegionGame())
            {
                var container = new ContainerConfigurator();
                container.Configure(game);
                
                game.Run();
            }
        }
    }
}