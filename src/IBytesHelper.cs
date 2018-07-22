namespace Legion
{
    public interface IBytesHelper
    {
        short ReadInt16(byte[] bytes, int pos);
        int ReadInt32(byte[] bytes, int pos);
        string ReadText(byte[] bytes, int pos);
    }
}