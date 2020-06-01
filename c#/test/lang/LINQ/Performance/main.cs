using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using static System.Console;

namespace Performance
{
    public class Victim : IComparable, IComparable<Victim>, IEquatable<Victim>
    {
        int _fInt;

        public int PInt
        {
            get
            {
                WriteLine($"Victim.{MethodBase.GetCurrentMethod()?.Name}() {_fInt}");
                return _fInt;
            }
            set
            {
                WriteLine($"Victim.{MethodBase.GetCurrentMethod()?.Name}({value})");
                _fInt = value;
            }
        }

        public Victim(int pInt = default)
        {
            _fInt = pInt;
        }

        #region Object

        public override int GetHashCode()
        {
            WriteLine($"(Object)Victim.{MethodBase.GetCurrentMethod()?.Name}()");
            return PInt.GetHashCode();
        }
        
        public override bool Equals(object? obj)
        {
            WriteLine($"(Object)Victim.{MethodBase.GetCurrentMethod()?.Name}()");

            if (obj == null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            bool result;

            switch (Type.GetTypeCode(obj.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                {
                    result = PInt.Equals(Convert.ToInt32(obj));
                    break;
                }
                default:
                {
                    result = PInt.Equals(((Victim)obj).PInt);
                    break;
                }
            }

            return result;
        }

        public override string ToString()
        {
            return $"{{PInt:{PInt}}}";
        }

        #endregion

        #region IComparable

        public int CompareTo(object obj)
        {
            WriteLine($"(IComparable)Victim.{MethodBase.GetCurrentMethod()?.Name}({obj})");

            if (obj == null)
                return 1;

            if (ReferenceEquals(this, obj))
                return 0;

            int result;

            switch (Type.GetTypeCode(obj.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                {
                    result = PInt.CompareTo(Convert.ToInt32(obj));
                    break;
                }
                default:
                {
                    result = PInt.CompareTo(((Victim)obj).PInt);
                    break;
                }
            }

            return result;
        }

        #endregion

        #region IComparable<T>

        public int CompareTo(Victim other)
        {
            WriteLine($"(IComparable<T>)Victim.{MethodBase.GetCurrentMethod()?.Name}({other})");

            if (other == null)
                return 1;

            if (ReferenceEquals(this, other))
                return 0;

            return PInt.CompareTo(other.PInt);
        }

        #endregion

        #region IEquatable<T>

        public bool Equals(Victim other)
        {
            WriteLine($"(IEquatable<T>)Victim.{MethodBase.GetCurrentMethod()?.Name}({other})");

            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return PInt.Equals(other.PInt);
        }

        #endregion
    }

    public class GroupOfVictim : IComparable, IComparable<GroupOfVictim>, IEquatable<GroupOfVictim>
    {
        int _fValue, _fCount;

        public int Value
        {
            get
            {
                WriteLine($"GroupOfVictim.{MethodBase.GetCurrentMethod()?.Name}() {_fValue}");
                return _fValue;
            }
            set
            {
                WriteLine($"GroupOfVictim.{MethodBase.GetCurrentMethod()?.Name}({value})");
                _fValue = value;
            }
        }

        public int Count
        {
            get
            {
                WriteLine($"GroupOfVictim.{MethodBase.GetCurrentMethod()?.Name}() {_fCount}");
                return _fCount;
            }
            set
            {
                WriteLine($"GroupOfVictim.{MethodBase.GetCurrentMethod()?.Name}({value})");
                _fCount = value;
            }
        }

        public GroupOfVictim(int pValue = default, int pCount = default)
        {
            _fValue = pValue;
            _fCount = pCount;
        }

        #region Object

        public override int GetHashCode()
        {
            WriteLine($"(Object)GroupOfVictim.{MethodBase.GetCurrentMethod()?.Name}()");
            return $"{Value}_{Count}".GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            WriteLine($"(Object)GroupOfVictim.{MethodBase.GetCurrentMethod()?.Name}()");

            if (obj == null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (!(obj is GroupOfVictim other))
            {
                return false;
            }

            return Value.Equals(other.Value) && Count.Equals(other.Value);
        }

        public override string ToString()
        {
            return $"{{Value:{Value}, Count:{Count}}}";
        }

        #endregion

        #region IComparable

        public int CompareTo(object obj)
        {
            WriteLine($"(IComparable)GroupOfVictim.{MethodBase.GetCurrentMethod()?.Name}({obj})");

            if (obj == null)
                return 1;

            if (ReferenceEquals(this, obj))
                return 0;

            if (!(obj is GroupOfVictim other))
            {
                return 1;
            }

            int result;
            return (result = Value.CompareTo(other.Value)) == 0 ? Count.CompareTo(other.Count) : result;
        }

        #endregion

        #region IComparable<T>

        public int CompareTo(GroupOfVictim other)
        {
            WriteLine($"(IComparable<T>)GroupOfVictim.{MethodBase.GetCurrentMethod()?.Name}({other})");

            if (other == null)
                return 1;

            if (ReferenceEquals(this, other))
                return 0;

            int result;
            return (result = Value.CompareTo(other.Value)) == 0 ? Count.CompareTo(other.Count) : result;
        }

        #endregion

        #region IEquatable<T>

        public bool Equals(GroupOfVictim other)
        {
            WriteLine($"(IEquatable<T>)GroupOfVictim.{MethodBase.GetCurrentMethod()?.Name}({other})");

            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Value.Equals(other.Value) && Count.Equals(other.Count);
        }

        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            var listOfVictim = new List<Victim>
            {
                new Victim(1),
                new Victim(2),
                new Victim(2)
            };

            var max = listOfVictim
                .GroupBy(x => x)
                .Select(x => new GroupOfVictim (x.Key.PInt, x.Count()))
                .OrderByDescending(x => x)
                .FirstOrDefault();

            WriteLine(max);

            WriteLine(new string('-', 60));

            var maxValue = listOfVictim.Max(x => x);
            var count = listOfVictim.Count(x => x.Equals(maxValue));

            WriteLine(new string('-', 60));

            count = listOfVictim
                .Count(x => x.Equals(listOfVictim.Max(x => x)));

            WriteLine(new string('-', 60));

            count = (new List<Victim> {listOfVictim.Max(x => x)})
                .Join(listOfVictim,
                    outerKeySelector => outerKeySelector,
                    innerKeySelector => innerKeySelector,
                    (outer, inner) => inner)
                .Count();

            ReadKey();
        }
    }
}
