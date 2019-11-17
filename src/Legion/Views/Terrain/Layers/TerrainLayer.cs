using System.Collections.Generic;
using Gui.Elements;
using Gui.Services;
using Legion.Model;

namespace Legion.Views.Terrain.Layers
{
    public class TerrainLayer : Layer
    {
        private TerrainGenerator _terrainGenerator;
        private List<TerrainPart> _terrainParts;

        public TerrainLayer(IGuiServices guiServices) : base(guiServices) { }

        public override void Initialize()
        {
            _terrainGenerator = new TerrainGenerator(GuiServices.ImagesStore);
        }

        public override void OnShow()
        {
            var context = Parent.Context as TerrainActionContext;
            //TODO: get terrainType from context
            _terrainParts = _terrainGenerator.Generate(TerrainType.Forest, false);
        }

        public override void Draw()
        {
            base.Draw();
            foreach (var part in _terrainParts)
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