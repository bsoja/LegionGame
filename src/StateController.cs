using Legion.View;
using Microsoft.Xna.Framework;

namespace Legion
{
    public class StateController : IStateController
    {
        private readonly IViewsProvider viewsProvider;

        public StateController(IViewsProvider viewsProvider)
        {
            this.viewsProvider = viewsProvider;
        }

        public void EnterMenu()
        {
            viewsProvider.Menu.Show(null);
            viewsProvider.Terrain.Hide();
            viewsProvider.Map.Hide();
        }

        public void EnterMap()
        {
            viewsProvider.Menu.Hide();
            viewsProvider.Map.Show(null);
        }

        public void ExitMap()
        {
            viewsProvider.Menu.Show(null);
            viewsProvider.Map.Hide();
        }

        public void EnterTerrainAction(TerrainActionContext context)
        {
            viewsProvider.Terrain.Show(context);
            viewsProvider.Map.Hide();
        }

        public void ExitTerrainAction(TerrainActionContext context)
        {
            viewsProvider.Terrain.Hide();
            viewsProvider.Map.Show(context);

            context.ActionAfter();
        }
    }
}