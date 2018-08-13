using System;
using System.Collections.Generic;
using System.Linq;
using Legion.Gui.Elements;
using Legion.Gui.Services;
using Legion.Model;
using Legion.Model.Repositories;
using Legion.Model.Types.Definitions;
using Legion.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Legion.Views.Terrain.Layers
{
    public class TerrainLayer : Layer
    {
        private TerrainGenerator terrainGenerator;
        private List<TerrainPart> terrainParts;

        public TerrainLayer(IGuiServices guiServices) : base(guiServices) { }

        public override void Initialize()
        {
            var context = Parent.Context as TerrainActionContext;
            terrainGenerator = new TerrainGenerator(GuiServices.ImagesProvider);
        }

        public override void OnShow()
        {
            //TODO: get terrainType from context
            terrainParts = terrainGenerator.Generate(TerrainType.Forest, false);
        }

        public override void Draw()
        {
            base.Draw();
            foreach (var part in terrainParts)
            {
                // item can be placeholder only and can have bounds only, to be used in obstacles detection
                if (part.Image != null)
                {
                    GuiServices.BasicDrawer.DrawImage(part.Image, part.X, part.Y);
                }
            }
        }
    }
}