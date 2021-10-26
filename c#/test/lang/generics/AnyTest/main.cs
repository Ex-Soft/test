#define OPERATOR_CANNOT_BE_APPLIED_TO_OPERANDS_OF_TYPE_T_AND_T

using System;
using System.Collections.Generic;

namespace AnyTest
{
    class Program
    {
        static void Main(string[] args)
        {
			BusinessEventSourceRunner.Run();

            DateTime
                tmpDateTime;

            int
                tmpInt;

            string
                tmpString;

            #if OPERATOR_CANNOT_BE_APPLIED_TO_OPERANDS_OF_TYPE_T_AND_T
   				tmpDateTime = Foo1(DateTime.Now);
				tmpInt = Foo1(5);

                int[] values = new int[] { 12, 3, 54, 234, 654, 3 };

			    tmpString = (Max(values) == 654).ToString();
			    tmpString = (Min(values) == 3).ToString();
			    tmpString = (Min(new int[] {}) == null).ToString();

            #endif
        }

        #if OPERATOR_CANNOT_BE_APPLIED_TO_OPERANDS_OF_TYPE_T_AND_T
   			static T Foo1<T>(T value) where T : struct, IComparable<T>
			{
				T?
					//min = null,
					//min = DateTime.Now.Date.AddDays(1) as T?,
					min = 13 as T?,
					//max = null;
					//max = DateTime.Now.Date.AddDays(-1) as T?;
					max = 1 as T?;

				if (min.HasValue && value.CompareTo(min.Value) < 0)
					value = min.Value;

				if (max.HasValue && value.CompareTo(max.Value) > 0)
					value = max.Value;

				return value;
			}

            static T? Max<T>(IEnumerable<T> values) where T : struct, IComparable<T>
		    {
			    return MinMaxImpl(values, delegate(T left, T right)
				    { return right.CompareTo(left); });
		    }

		    static T? Min<T>(IEnumerable<T> values) where T : struct, IComparable<T>
		    {
			    return MinMaxImpl(values, delegate(T left, T right)
				    { return left.CompareTo(right); });
		    }

		    static T? MinMaxImpl<T>(IEnumerable<T> values, Comparison<T> comparison) where T : struct, IComparable<T>
		    {
			    T? v = null;

			    foreach (T value in values)
				    if (v == null || comparison(v.Value, value) > 0)
					    v = value;

			    return v;
		    }
        #endif
    }
}
