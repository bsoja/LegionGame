namespace Legion
{
    public enum TerrainActionType
    {
        Message, // Just show message and don't go to Action mode
        Simple, // Action just that, executed by user from army menu; checks if it is called inside city or in empty field
        Battle, // two armies battle, one of this armies must be user army; battle can be inside city or on empty field
        //Others??
    }
}