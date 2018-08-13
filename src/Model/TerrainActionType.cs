namespace Legion.Model
{
    public enum TerrainActionType
    {
        Simple, // Action just that, executed by user from army menu; checks if it is called inside city or in empty field
        Battle, // two armies battle, one of this armies must be user army; battle can be inside city or on empty field
        //Others??
    }
}