using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ZI_17844
{
    public class CRC : HashAlgorithm
    {
        //CRC-B3


        public const UInt32 DefaultPoly = 0x4c11db7;
        public const UInt32 DefaultSeed = 0xffffffff;

        private UInt32 hash;
        private UInt32 seed;
        private UInt32[] table;
        private static UInt32[] defaultTable;

        public CRC()
        {
            table = InitializeTable(DefaultPoly);
            seed = DefaultSeed;
            Initialize();
        }

        public CRC(UInt32 polynomial, UInt32 seed)
        {
            table = InitializeTable(polynomial);
            this.seed = seed;
            Initialize();
        }

        public override void Initialize()
        {
            hash = seed;
        }

        protected override void HashCore(byte[] buff, int start, int length)
        {
            hash = CalculateHash(table, hash, buff, start, length);
        }

        protected override byte[] HashFinal()
        {
            var hashBuff = UInt32ToBigEndian(~hash);
            HashValue = hashBuff;
            return hashBuff;
        }

        public override int HashSize { get { return 32; } }

        public static UInt32 Compute(byte[] buff)
        {
            return ~CalculateHash(InitializeTable(DefaultPoly), DefaultSeed, buff, 0, buff.Length);
        }

        public static UInt32 Compute(UInt32 seed, byte[] buff)
        {
            return ~CalculateHash(InitializeTable(DefaultPoly), seed, buff, 0, buff.Length);
        }

        public static UInt32 Compute(UInt32 polynomial, UInt32 seed, byte[] buff)
        {
            return ~CalculateHash(InitializeTable(polynomial), seed, buff, 0, buff.Length);
        }

        private static UInt32[] InitializeTable(UInt32 polynomial)
        {
            if (polynomial == DefaultPoly && defaultTable != null)
                return defaultTable;

            var table = new UInt32[256];
            for (var i = 0; i <= 255; i++)
            {
                var entry = (UInt32)i;
                for (var j = 0; j <= 7; j++)
                    if ((entry & 1) == 1)
                        entry = (entry / 2) ^ polynomial;
                    else
                        entry = entry / 2;
                table[i] = entry;
            }

            if (polynomial == DefaultPoly)
                defaultTable = table;

            return table;
        }
        private static UInt32 CalculateHash(UInt32[] table, UInt32 seed, IList<byte> buff, int start, int size)
        {
            var crc = seed;
            for (var i = start; i < size; i++)
                unchecked
                {
                    crc = (crc / 256) ^ table[buff[i] ^ crc & 0xff];
                }
            return crc;
        }

        private byte[] UInt32ToBigEndian(UInt32 uint32)
        {
            var rez = BitConverter.GetBytes(uint32);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(rez);

            return rez;
        }

    }
}
