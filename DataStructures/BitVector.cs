using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BitVector
    {
        private byte[] arr;

        public BitVector()
        {
            arr = new byte[(int.MaxValue / 8) + 1];
        }

        public bool IsSet(int n)
        {
            var byteInArr = n / 8;
            var bitInByte = n % 8;
            var @byte = arr[byteInArr];

            // Build a mask with a bit set to 1 only on the relevant bit
            return (@byte & (1 << bitInByte)) != 0;
        }

        public void Add(int n)
        {
            var byteInArr = n / 8;
            var bitInByte = n % 8;
            var @byte = arr[byteInArr];

            arr[byteInArr] |= (byte)(1 << bitInByte);
        }
    }
}
