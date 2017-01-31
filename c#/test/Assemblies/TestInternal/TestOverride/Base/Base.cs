namespace Base
{
    public class Base
    {
        private int
            _privateIntProperty,

            _protectedIntProperty,
            _internalIntProperty,
            _protectedInternalIntProperty,

            _protectedVirtualIntProperty,
            _internalVirtualIntProperty,
            _protectedInternalVirtualIntProperty,

            _publicIntProperty,
            _publicIntPropertyProtectedSet,
            _publicIntPropertyInternalSet,
            _publicIntPropertyProtectedInternalSet,

            _publicVirtualIntProperty,
            _publicVirtualIntPropertyProtectedSet,
            _publicVirtualIntPropertyInternalSet,
            _publicVirtualIntPropertyProtectedInternalSet;

        private int PrivateIntProperty
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.get_PrivateIntProperty()");
                return _privateIntProperty;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.set_PrivateIntProperty()");
                if (_privateIntProperty != value)
                    _privateIntProperty = value;
            }
        }

        protected int ProtectedIntProperty
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.get_ProtectedIntProperty()");
                return _protectedIntProperty;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.set_ProtectedIntProperty()");
                if (_protectedIntProperty != value)
                    _protectedIntProperty = value;
            }
        }

        internal int InternalIntProperty
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.get_InternalIntProperty()");
                return _internalIntProperty;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.set_InternalIntProperty()");
                if (_internalIntProperty != value)
                    _internalIntProperty = value;
            }
        }

        protected internal int ProtectedInternalIntProperty
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.get_ProtectedInternalIntProperty()");
                return _protectedInternalIntProperty;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.set_ProtectedInternalIntProperty()");
                if (_protectedInternalIntProperty != value)
                    _protectedInternalIntProperty = value;
            }
        }

        protected virtual int ProtectedVirtualIntProperty
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.get_ProtectedVirtualIntProperty()");
                return _protectedVirtualIntProperty;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.set_ProtectedVirtualIntProperty()");
                if (_protectedVirtualIntProperty != value)
                    _protectedVirtualIntProperty = value;
            }
        }

        internal virtual int InternalVirtualIntProperty
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.get_InternalVirtualIntProperty()");
                return _internalVirtualIntProperty;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.set_InternalVirtualIntProperty()");
                if (_internalVirtualIntProperty != value)
                    _internalVirtualIntProperty = value;
            }
        }

        protected internal virtual int ProtectedInternalVirtualIntProperty
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.get_ProtectedInternalVirtualIntProperty()");
                return _protectedInternalVirtualIntProperty;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.set_ProtectedInternalVirtualIntProperty()");
                if (_protectedInternalVirtualIntProperty != value)
                    _protectedInternalVirtualIntProperty = value;
            }
        }

        public int PublicIntProperty
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.get_PublicIntProperty()");
                return _publicIntProperty;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.set_PublicIntProperty()");
                if (_publicIntProperty != value)
                    _publicIntProperty = value;
            }
        }

        public int PublicIntPropertyProtectedSet
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.get_PublicIntPropertyProtectedSet()");
                return _publicIntPropertyProtectedSet;
            }
            protected set
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.set_PublicIntPropertyProtectedSet()");
                if (_publicIntPropertyProtectedSet != value)
                    _publicIntPropertyProtectedSet = value;
            }
        }

        public int PublicIntPropertyInternalSet
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.get_PublicIntPropertyInternalSet()");
                return _publicIntPropertyInternalSet;
            }
            internal set
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.set_PublicIntPropertyInternalSet()");
                if (_publicIntPropertyInternalSet != value)
                    _publicIntPropertyInternalSet = value;
            }
        }

        public int PublicIntPropertyProtectedInternalSet
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.get_PublicIntPropertyProtectedInternalSet()");
                return _publicIntPropertyProtectedInternalSet;
            }
            protected internal set
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.set_PublicIntPropertyProtectedInternalSet()");
                if (_publicIntPropertyProtectedInternalSet != value)
                    _publicIntPropertyProtectedInternalSet = value;
            }
        }

        public virtual int PublicVirtualIntProperty
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.get_PublicVirtualIntProperty()");
                return _publicVirtualIntProperty;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.set_PublicVirtualIntProperty()");
                if (_publicVirtualIntProperty != value)
                    _publicVirtualIntProperty = value;
            }
        }

        public virtual int PublicVirtualIntPropertyProtectedSet
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.get_PublicVirtualIntPropertyProtectedSet()");
                return _publicVirtualIntPropertyProtectedSet;
            }
            protected set
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.set_PublicVirtualIntPropertyProtectedSet()");
                if (_publicVirtualIntPropertyProtectedSet != value)
                    _publicVirtualIntPropertyProtectedSet = value;
            }
        }

        public virtual int PublicVirtualIntPropertyInternalSet
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.get_PublicVirtualIntPropertyInternalSet()");
                return _publicVirtualIntPropertyInternalSet;
            }
            internal set
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.set_PublicVirtualIntPropertyInternalSet()");
                if (_publicVirtualIntPropertyInternalSet != value)
                    _publicVirtualIntPropertyInternalSet = value;
            }
        }

        public virtual int PublicVirtualIntPropertyProtectedInternalSet
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.get_PublicVirtualIntPropertyProtectedInternalSet()");
                return _publicVirtualIntPropertyProtectedInternalSet;
            }
            protected internal set
            {
                System.Diagnostics.Debug.WriteLine("Base.Base.set_PublicVirtualIntPropertyPropertyProtectedInternalSet()");
                if (_publicVirtualIntPropertyProtectedInternalSet != value)
                    _publicVirtualIntPropertyProtectedInternalSet = value;
            }
        }

        private void PrivateMethod()
        {
            PrivateIntProperty = 1;

            ProtectedIntProperty = 1;
            InternalIntProperty = 1;
            ProtectedInternalIntProperty = 1;

            ProtectedVirtualIntProperty = 1;
            InternalVirtualIntProperty = 1;
            ProtectedInternalVirtualIntProperty = 1;

            PublicIntProperty = 1;
            PublicIntPropertyProtectedSet = 1;
            PublicIntPropertyInternalSet = 1;
            PublicIntPropertyProtectedInternalSet = 1;

            PublicVirtualIntProperty = 1;
            PublicVirtualIntPropertyProtectedSet = 1;
            PublicVirtualIntPropertyInternalSet = 1;
            PublicVirtualIntPropertyProtectedInternalSet = 1;

            System.Diagnostics.Debug.WriteLine("Base.Base.PrivateMethod()");
        }

        protected virtual void ProtectedMethod()
        {
            PrivateIntProperty = 1;

            ProtectedIntProperty = 1;
            InternalIntProperty = 1;
            ProtectedInternalIntProperty = 1;

            ProtectedVirtualIntProperty = 1;
            InternalVirtualIntProperty = 1;
            ProtectedInternalVirtualIntProperty = 1;

            PublicIntProperty = 1;
            PublicIntPropertyProtectedSet = 1;
            PublicIntPropertyInternalSet = 1;
            PublicIntPropertyProtectedInternalSet = 1;

            PublicVirtualIntProperty = 1;
            PublicVirtualIntPropertyProtectedSet = 1;
            PublicVirtualIntPropertyInternalSet = 1;
            PublicVirtualIntPropertyProtectedInternalSet = 1;

            System.Diagnostics.Debug.WriteLine("Base.Base.ProtectedMethod()");
        }

        internal virtual void InternalMethod()
        {
            PrivateIntProperty = 1;

            ProtectedIntProperty = 1;
            InternalIntProperty = 1;
            ProtectedInternalIntProperty = 1;

            ProtectedVirtualIntProperty = 1;
            InternalVirtualIntProperty = 1;
            ProtectedInternalVirtualIntProperty = 1;

            PublicIntProperty = 1;
            PublicIntPropertyProtectedSet = 1;
            PublicIntPropertyInternalSet = 1;
            PublicIntPropertyProtectedInternalSet = 1;

            PublicVirtualIntProperty = 1;
            PublicVirtualIntPropertyProtectedSet = 1;
            PublicVirtualIntPropertyInternalSet = 1;
            PublicVirtualIntPropertyProtectedInternalSet = 1;

            System.Diagnostics.Debug.WriteLine("Base.Base.InternalMethod()");
        }

        protected internal virtual void ProtectedInternalMethod()
        {
            PrivateIntProperty = 1;

            ProtectedIntProperty = 1;
            InternalIntProperty = 1;
            ProtectedInternalIntProperty = 1;

            ProtectedVirtualIntProperty = 1;
            InternalVirtualIntProperty = 1;
            ProtectedInternalVirtualIntProperty = 1;

            PublicIntProperty = 1;
            PublicIntPropertyProtectedSet = 1;
            PublicIntPropertyInternalSet = 1;
            PublicIntPropertyProtectedInternalSet = 1;

            PublicVirtualIntProperty = 1;
            PublicVirtualIntPropertyProtectedSet = 1;
            PublicVirtualIntPropertyInternalSet = 1;
            PublicVirtualIntPropertyProtectedInternalSet = 1;

            System.Diagnostics.Debug.WriteLine("Base.Base.ProtectedInternalMethod()");
        }

        public virtual void PublicMethod()
        {
            PrivateIntProperty = 1;

            ProtectedIntProperty = 1;
            InternalIntProperty = 1;
            ProtectedInternalIntProperty = 1;

            ProtectedVirtualIntProperty = 1;
            InternalVirtualIntProperty = 1;
            ProtectedInternalVirtualIntProperty = 1;

            PublicIntProperty = 1;
            PublicIntPropertyProtectedSet = 1;
            PublicIntPropertyInternalSet = 1;
            PublicIntPropertyProtectedInternalSet = 1;

            PublicVirtualIntProperty = 1;
            PublicVirtualIntPropertyProtectedSet = 1;
            PublicVirtualIntPropertyInternalSet = 1;
            PublicVirtualIntPropertyProtectedInternalSet = 1;

            System.Diagnostics.Debug.WriteLine("Base.Base.PublicMethod()");
        }
    }
}
