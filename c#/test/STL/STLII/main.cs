using System;
using System.Collections.Generic;

namespace STLII
{
    public struct Point<T>
    {
        private T
            xPos,
            yPos;

        public Point(T xVal, T yVal)
        {
            xPos = xVal;
            yPos = yVal;
        }

        public T X
        {
            get
            {
                return (xPos);
            }
            set
            {
                xPos = value;
            }
        }

        public T Y
        {
            get
            {
                return (yPos);
            }
            set
            {
                yPos = value;
            }
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]",xPos,yPos);
        }

        public void ResetPoint()
        {
            xPos = default(T);
            yPos = default(T);
        }
    }

    class Program
    {
        static void Main()
        {
            string
                tmpString;

            List<int> ListInt = new List<int>(new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            int
                maxCount = 3;

            ListInt.RemoveRange(maxCount, ListInt.Count - maxCount);

            ListInt = new List<int>(new[] { 0 });
            List<int> ListIntToAdd = new List<int>(new[] { 2, 3, 4, 5, 6, 7, 8, 9 });

            if (ListInt.Count + ListIntToAdd.Count > maxCount)
            {
                int itemToRemove;

                if ((itemToRemove = maxCount - ListInt.Count) > 0)
                    ListIntToAdd.RemoveRange(itemToRemove, ListIntToAdd.Count - itemToRemove);
            }

            ListInt=new List<int>();
            ListInt.Add(5);
            ListInt.Add(3);
            ListInt.Add(1);

            if(ListInt.Contains(1))
                Console.WriteLine("ListInt.Contains(1)");

            int
                a=1,
                idx;

            if ((idx = ListInt.BinarySearch(a)) >= 0)
                tmpString = "\"" + a + "\" was found @ ListInt[" + idx + "]=\"" + ListInt[idx] + "\"";
            else
            {
                if ((idx = ~idx) >= ListInt.Count)
                    --idx;

                tmpString = "\"" + a + "\" was not found. The next larger object is at index " + idx + " (ListInt[" + idx + "]=\"" + ListInt[idx] + "\")";
            }
            Console.WriteLine(tmpString);

            ListInt.Sort();

            if ((idx = ListInt.BinarySearch(a)) >= 0)
                tmpString = "\"" + a + "\" was found @ ListInt[" + idx + "]=\"" + ListInt[idx] + "\"";
            else
            {
                if ((idx = ~idx) >= ListInt.Count)
                    --idx;

                tmpString = "\"" + a + "\" was not found. The next larger object is at index " + idx + " (ListInt[" + idx + "]=\"" + ListInt[idx] + "\")";
            }
            Console.WriteLine(tmpString);

            a = 4;
            if ((idx = ListInt.BinarySearch(a)) >= 0)
                tmpString = "\"" + a + "\" was found @ ListInt[" + idx + "]=\"" + ListInt[idx] + "\"";
            else
            {
                if ((idx = ~idx) >= ListInt.Count)
                    --idx;

                tmpString = "\"" + a + "\" was not found. The next larger object is at index " + idx + " (ListInt[" + idx + "]=\"" + ListInt[idx] + "\")";
            }
            Console.WriteLine(tmpString);

            Point<int>
                Point=new Point<int>(10,20);

            Console.WriteLine(Point.ToString());
            Point.ResetPoint();
            Console.WriteLine(Point.ToString());

			List<string>
				ListString=new List<string>();

			ListString.Add("First");
			ListString.Add("Second");
			ListString.Add("Third");
			ListString.Add("Fourth");
			ListString.Add("Fifth");

			for(int i=0; i<ListString.Count; ++i)
				Console.WriteLine("ListString[{0}]=\"{1}\"",i,ListString[i]);

        	foreach(string s in ListString)
				Console.WriteLine(s);

        	List<string>.Enumerator
				e = ListString.GetEnumerator();

			while(e.MoveNext())
				Console.WriteLine(e.Current);
        }
	}
}
