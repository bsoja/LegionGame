using System;
using System.Runtime.InteropServices;

namespace Legion
{
    //TODO: add support for Open AL loading
    public class MonoGameLibLoader
    {
        // Hack for dotnet core, it loads SDL2.dll here to avoid DllNotFoundException thrown by Monogame
        public void LoadLibs()
        {
            Version version;
            GetVersion(out version);
            Console.WriteLine(string.Format("SDL version: {0}.{1}.{2}",
                version.Major, version.Minor, version.Patch));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetVersion")]
        public static extern void GetVersion(out Version version);
    }

    public struct Version
    {
        public byte Major;
        public byte Minor;
        public byte Patch;
    }
}