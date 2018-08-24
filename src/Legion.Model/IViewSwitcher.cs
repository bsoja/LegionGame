namespace Legion.Model
{
    public interface IViewSwitcher
    {
        // switching between Views
        void OpenMenu();
        void OpenMap(TerrainActionContext context);
        void OpenTerrain(TerrainActionContext context);
    }
}