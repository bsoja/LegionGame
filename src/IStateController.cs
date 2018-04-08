namespace Legion
{
    public interface IStateController
    {
        void EnterMap();
        void ExitMap();
        void EnterTerrainAction(TerrainActionContext context);
        void ExitTerrainAction(TerrainActionContext context);
    }
}