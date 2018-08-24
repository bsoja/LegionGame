using System;
using System.Text;

namespace Legion.Archive
{
    public class BytesHelper : IBytesHelper
    {
        public short ReadInt16(byte[] bytes, int pos)
        {
            byte[] bytesCut = bytes;
            if (BitConverter.IsLittleEndian)
            {
                // convert to big endian
                bytesCut = new byte[2] { bytes[pos + 1], bytes[pos] };
                pos = 0;
            }
            var number = BitConverter.ToInt16(bytesCut, pos);
            return number;
        }

        public int ReadInt32(byte[] bytes, int pos)
        {
            byte[] bytesCut = bytes;
            if (BitConverter.IsLittleEndian)
            {
                // convert to big endian
                bytesCut = new byte[4] { bytes[pos + 3], bytes[pos + 2], bytes[pos + 1], bytes[pos] };
                pos = 0;
            }
            var number = BitConverter.ToInt32(bytesCut, pos);
            return number;
        }

        public string ReadText(byte[] bytes, int pos)
        {
            var length = bytes[pos];
            var text = Encoding.Default.GetString(bytes, pos + 1, length);
            return text;
        }
    }
}