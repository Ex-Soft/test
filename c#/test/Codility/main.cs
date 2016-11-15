using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility
{
    class Program
    {
        static void Main(string[] args)
        {
            //var n = 1041;
            var n = 20;
            solution(n);
            var a = new int[] { -7, 1, 5, 2, -4, 3, 0 };
            //var a = new int[] { -1, 3, -4, 5, 1, -6, 2, 1 };
            solution(a);
        }

        public static int solution(int N)
        {
            var tmp = Convert.ToString(N, 2);

            bool binaryGapStart = false;

            int
                binaryGapMaxLength = 0,
                binaryGapCurrentLength = 0;

            for (var i = tmp.Length - 1; i >= 0; --i)
            {
                if (tmp[i] == '1' && i > 0 && tmp[i - 1] == '0')
                {
                    binaryGapStart = true;
                    binaryGapCurrentLength = 0;
                    continue;
                }

                if (binaryGapStart)
                {
                    if (tmp[i] == '0')
                    {
                        ++binaryGapCurrentLength;

                        if (i > 0 && tmp[i - 1] == '1')
                        {
                            binaryGapStart = false;

                            if (binaryGapMaxLength < binaryGapCurrentLength)
                                binaryGapMaxLength = binaryGapCurrentLength;
                        }
                    }
                }
            }

            return binaryGapMaxLength;
        }

        public static int solution(int[] A)
        {
            long
                sumLeft = 0L,
                sumRight = 0L;

            for(int i=0; i < A.Length; ++i)
                sumRight += A[i];

            for (int i = 0; i < A.Length; ++i)
            {
                sumLeft += A[i];

                if (sumLeft == sumRight)
                    Console.WriteLine(i);

                sumRight -= A[i];
            }

            return -1;
        }
    }
}
