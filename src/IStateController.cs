namespace Legion
{
    public interface IStateController
    {
        void EnterMenu();
        void EnterMap();
        void ExitMap();
        void EnterTerrainAction(TerrainActionContext context);
        void ExitTerrainAction(TerrainActionContext context);
    }
}