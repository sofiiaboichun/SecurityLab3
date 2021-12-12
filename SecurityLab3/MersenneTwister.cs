using System;


namespace SecurityLab3
{
    class MersenneTwister
    {
        const int n = 624;
        const int m = 397;
        const int u = 11;
        const int s = 7;
        const int t = 15;
        const int l = 18;
        const uint a = 0x9908B0DF;
        const uint b = 0x9D2C5680;
        const uint c = 0xEFC60000;

        public uint[] mt = new uint[n + 1];
        uint mti = n + 1;

        public MersenneTwister() { }     //random
        public MersenneTwister(uint seed)
        {
            RandomInit(seed);
        }
        public void RandomInit(uint seed)
        {
            mt[0] = seed;
            for (mti = 1; mti < n; mti++)
                mt[mti] = (1812433253U * (mt[mti - 1] ^ (mt[mti - 1] >> 30)) + mti);
        }
        public uint Random()
        {
            uint y;

            if (mti >= n)
            {
                const uint LOWER_MASK = 2147483647;
                const uint UPPER_MASK = 0x80000000;
                uint[] mag01 = { 0, a };

                int kk;
                for (kk = 0; kk < n - m; kk++)
                {
                    y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
                    mt[kk] = mt[kk + m] ^ (y >> 1) ^ mag01[y & 1];
                }
                for (; kk < n - 1; kk++)
                {
                    y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
                    mt[kk] = mt[kk + (m - n)] ^ (y >> 1) ^ mag01[y & 1];
                }
                y = (mt[n - 1] & UPPER_MASK) | (mt[0] & LOWER_MASK);
                mt[n - 1] = mt[m - 1] ^ (y >> 1) ^ mag01[y & 1];
                mti = 0;
            }

            y = mt[mti++];

            y ^= y >> u;
            y ^= (y << s) & b;
            y ^= (y << t) & c;
            y ^= y >> l;
            return y;
        }
    }
}

