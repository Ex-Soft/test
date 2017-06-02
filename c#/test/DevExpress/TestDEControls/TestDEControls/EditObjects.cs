using System.Diagnostics;

namespace TestDEControls
{
    public class EditObjectWithBool
    {
        bool _fBool;

        public bool FBool {
            get
            {
                Debug.WriteLine(string.Format("{0}.FBool.get()", GetType().Name));
                return _fBool;
            }
            set
            {
                Debug.WriteLine(string.Format("{0}.FBool.set({1})", GetType().Name, value));
                _fBool = value;
            }
        }

        public EditObjectWithBool(EditObjectWithBool obj) : this(obj.FBool)
        {}

        public EditObjectWithBool(bool fBool=false)
        {
            _fBool = fBool;
        }
    }

    public class EditObjectWithNullableBool
    {
        bool? _fBool;

        public bool? FBool
        {
            get
            {
                Debug.WriteLine(string.Format("{0}.FBool.get()", GetType().Name));
                return _fBool;
            }
            set
            {
                Debug.WriteLine(string.Format("{0}.FBool.set({1})", GetType().Name, value));
                _fBool = value;
            }
        }

        public EditObjectWithNullableBool(EditObjectWithNullableBool obj) : this(obj.FBool)
        {}

        public EditObjectWithNullableBool(bool? fBool=null)
        {
            _fBool = fBool;
        }
    }

    public class EditObjectWithDevExpressDefaultBoolean
    {
        DevExpress.Utils.DefaultBoolean _fBool;

        public DevExpress.Utils.DefaultBoolean FBool
        {
            get
            {
                Debug.WriteLine(string.Format("{0}.FBool.get()", GetType().Name));
                return _fBool;
            }
            set
            {
                Debug.WriteLine(string.Format("{0}.FBool.set({1})", GetType().Name, value));
                _fBool = value;
            }
        }

        public EditObjectWithDevExpressDefaultBoolean(EditObjectWithDevExpressDefaultBoolean obj) : this(obj.FBool)
        {}

        public EditObjectWithDevExpressDefaultBoolean(DevExpress.Utils.DefaultBoolean fBool = DevExpress.Utils.DefaultBoolean.Default)
        {
            _fBool = fBool;
        }
    }

    public class EditObjectWithInt
    {
        int _fInt;

        public int FInt
        {
            get
            {
                Debug.WriteLine(string.Format("{0}.FInt.get()", GetType().Name));
                return _fInt;
            }
            set
            {
                Debug.WriteLine(string.Format("{0}.FInt.set({1})", GetType().Name, value));
                _fInt = value;
            }
        }

        public EditObjectWithInt(EditObjectWithInt obj) : this(obj.FInt)
        {}

        public EditObjectWithInt(int fInt = 0)
        {
            _fInt = fInt;
        }
    }
}
