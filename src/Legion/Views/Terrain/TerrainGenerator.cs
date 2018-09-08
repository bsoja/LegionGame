using System.Collections.Generic;
using System.Drawing;
using Gui.Services;
using Legion.Utils;

namespace Legion.Views.Terrain
{
    /*
       SCENERIA=TYP
       Screen 0
       Screen Hide 0
       'Auto View Off 
       Cls 20
       LX=20 : LY=20 : LSZER=600 : LWYS=490
       If WIES=-1
          D=1
       Else 
          D=2
       End If 
       If WIES>-1 : FUNDAMENTY[WIES] : End If 
        */
    public class TerrainGenerator
    {
        private readonly IImagesStore imagesStore;

        public TerrainGenerator(IImagesStore imagesStore)
        {
            this.imagesStore = imagesStore;
        }

        public List<TerrainPart> Generate(TerrainType terrainType, bool isCity)
        {
            // TODO: support all types
            return GenerateForest(isCity);
        }

        private List<TerrainPart> GenerateForest(bool isCity)
        {
            var parts = new List<TerrainPart>();

            // 'las
            var images = imagesStore.GetImages("scene.forest");

            for (var y = 0; y <= 11; y++)
            {
                for (var x = 0; x <= 15; x++)
                {
                    //Paste Bob X*50,Y*50,BIBY+1
                    parts.Add(new TerrainPart(images[0], x * 50, y * 50));
                }
            }

            var visibility = 150;
            for (var i = 0; i <= 30; i++)
            {
                var x = GlobalUtils.Rand(620) + 20;
                var y = i * 20;
                var nr = GlobalUtils.Rand(1) + 5;
                // Paste Bob X,Y,BIBY+NR
                parts.Add(new TerrainPart(images[nr - 1], x, y));
            }

            var d = isCity ? 2 : 1;
            for (var i = 0; i <= 15 / d; i++)
            {
                var b = GlobalUtils.Rand(2) + 2;
                // TODO: Gosub LOSUJ
                /*
                LOSUJ:
                If Rnd(1)=0
                    B=Hrev(B)  // Hrev -> AMOS function to flip an image horizontally
                End If 
                */

                // Paste Bob X,Y,BIBY+B
                // Set Zone 60+I,X+4,Y+4 To X+28,Y+22
                var x = GlobalUtils.Rand(620) + 20;
                var y = 29 * 20;
                parts.Add(new TerrainPart(images[b - 1], x, y, new Rectangle(x + 4, y + 4, x + 28, y + 22)));
            }

            if (!isCity)
            {
                for (var j = 0; j <= 3; j++)
                {
                    var x2 = GlobalUtils.Rand(640);
                    for (var i = 0; i <= 18; i++)
                    {
                        var x = x2 + GlobalUtils.Rand(100) - 50;
                        var y = (j * 100) + (i * 4) - 60;
                        var nr = GlobalUtils.Rand(2) + 7;
                        // Paste Bob X,Y,NR+BIBY
                        parts.Add(new TerrainPart(images[nr - 1], x, y));
                    }

                    var zx1 = x2 - 50;
                    var zy1 = (j * 100) - 60;
                    var zx2 = zx1 + 190;
                    var zy2 = zy1 + 130;
                    var zx3 = zx1 + 40;
                    var zx4 = zx2 - 45;
                    var zy3 = zy1 + 130;
                    var zy4 = zy1 + 180;

                    if (zx1 < 0) zx1 = 0;
                    if (zy1 < 0) zy1 = 0;
                    if (zx2 > 640) zx2 = 640;
                    if (zy2 > 512) zy2 = 512;
                    if (zx3 < 0) zx3 = 0;
                    if (zy3 < 0) zy3 = 0;
                    if (zx4 > 640) zx4 = 640;
                    if (zy4 > 512) zy4 = 512;

                    // Set Zone 90+J,ZX1,ZY1 To ZX2,ZY2
                    // Set Zone 94+J,ZX3,ZY3 To ZX4,ZY4

                    // bounds only, to be used in obstacles detection
                    parts.Add(new TerrainPart(null, zx1, zy1, new Rectangle(zx1, zy1, zx2, zy2)));
                    parts.Add(new TerrainPart(null, zx3, zy3, new Rectangle(zx3, zy3, zx4, zy4)));
                }
            }

            return parts;
        }
    }
}