#define TEST_FIELD_WITH_INITIALIZATION
//#define TEST_OBJECT_INITIALIZER
//#define TEST_NEW_WITH_SET
//#define TEST_CYCLE
//#define TEST_CLASS_STATIC
//#define INHERITANCE
//#define CLASS_FACTORY
//#define TEST_CALL_BY

using System;
#if TEST_CLASS_STATIC || TEST_CYCLE
	using System.Collections;
#endif
using System.IO;

namespace Classes
{
    #if TEST_FIELD_WITH_INITIALIZATION
        class TestClassWithFieldWithInitialization
        {
            public TestClassWithFieldWithInitialization()
            {
                _fInt = 1; // _fInt == -111
                _fInt2 = 2; // _fInt2 == -222
                _fInt3 = 3; // _fInt3 == -333
                FInt4 = 4; // FInt == -444
            }

            public TestClassWithFieldWithInitialization(TestClassWithFieldWithInitialization obj)
            {
                _fInt = obj.FInt;  // _fInt == -111
                _fInt2 = obj.FInt2; // _fInt2 == -222
                _fInt3 = obj._fInt3; // _fInt3 == -333
                FInt4 = obj.FInt4; // FInt == -444
            }

            readonly int _fInt = -111; // execute before constructor
            int _fInt2 = -222; // execute before constructor
            int _fInt3 = -333; // execute before constructor

            public int FInt
            {
                get { System.Diagnostics.Debug.WriteLine($"get_FInt() {_fInt}"); return _fInt; }
            }

            public int FInt2
            {
                get { System.Diagnostics.Debug.WriteLine($"get_FInt2() {_fInt2}"); return _fInt2; }
            }
            public int FInt3
            {
                get { System.Diagnostics.Debug.WriteLine($"get_FInt3() {_fInt3}"); return _fInt2; }
                set { System.Diagnostics.Debug.WriteLine($"set_FInt3({value}) {_fInt3}"); _fInt3 = value; }
            }

            public int FInt4 { get; set; } = -444; // execute before constructor
        }
    #endif

    #if TEST_OBJECT_INITIALIZER
        class TestClassObjectInitializer
        {
            public int FInt1 { get; set; }
            public int FInt2 { get; set; }
        }

        class TestClassObjectInitializerII
        {
            int
                _fInt1,
                _fInt2;

            public int FInt1
            {
                get { return _fInt1; }
                set
                {
                    _fInt1 = value;
                    Console.WriteLine("set_FInt1(int32 = {0})", value);
                }
            }

            public int FInt2
            {
                get { return _fInt2; }
                set
                {
                    _fInt2 = value;
                    Console.WriteLine("set_FInt2(int32 = {0})", value);
                }
            }

            public TestClassObjectInitializerII()
            {
                _fInt1 = -1;
                _fInt2 = -1;
                Console.WriteLine("TestClassObjectInitializerII::.ctor()");
            }

            public TestClassObjectInitializerII(int fInt1)
            {
                _fInt1 = fInt1;
                _fInt2 = -1;
                Console.WriteLine("TestClassObjectInitializerII::.ctor(int32)");
            }

            public TestClassObjectInitializerII(int fInt1, int fInt2)
            {
                _fInt1 = fInt1;
                _fInt2 = fInt2;
                Console.WriteLine("TestClassObjectInitializerII::.ctor(int32, int32)");
            }

            public TestClassObjectInitializerII(TestClassObjectInitializerII obj)
            {
                _fInt1 = obj.FInt1;
                _fInt2 = obj.FInt2;
                Console.WriteLine("TestClassObjectInitializerII::.ctor(TestClassObjectInitializerII)");
            }
        }
    #endif

    #if TEST_NEW_WITH_SET
        class TestClassWithSet
        {
            public int FInt { get; set; }
            public int FIntRO { get; private set; }

            public TestClassWithSet(int intRO)
            {
                FIntRO = intRO;
            }
        }
    #endif

	#if TEST_VIRTUAL
		class A
		{
			public virtual void Test()
			{
				Console.WriteLine("A");
			}
		}

		class B:A
		{
			public override void Test()
			{
				Console.WriteLine("B");
			}
		}

		class C:B
		{
			public new virtual void Test()
			{
				Console.WriteLine("C");
			}
		}

		class D:C
		{
			public override void Test()
			{
				Console.WriteLine("D");
			}
		}
	#endif

	#if TEST_CYCLE
		class ClassSimple
		{
			string
				FA;

			public ClassSimple():this(string.Empty)
			{}
			//---------------------------------------------------------------------------

			public ClassSimple(ClassSimple aObj):this(aObj.A)
			{}
			//---------------------------------------------------------------------------

			public ClassSimple(string aA)
			{
				FA=aA;
			}
			//---------------------------------------------------------------------------

			public string A
			{
				set
				{
					FA=value;
				}
				get
				{
					return(FA);
				}
			}
		}
		//---------------------------------------------------------------------------
	#endif

	#if TEST_CLASS_STATIC
		struct SItemInfo
		{
			public string
				Prop1,
				Prop2;

			public SItemInfo(SItemInfo aObj):this(aObj.Prop1,aObj.Prop2)
			{}

			public SItemInfo(string aProp1, string aProp2)
			{
				Prop1=aProp1;
				Prop2=aProp2;
			}
		}

		class TItemsInfo
		{
			public static Hashtable
				ItemsInfo;

			static TItemsInfo()
			{
				ItemsInfo=new Hashtable();

				ItemsInfo.Add(1,new SItemInfo("1_1","1_2"));
				ItemsInfo.Add(10,new SItemInfo("10_1","10_2"));
				ItemsInfo.Add(100,new SItemInfo("100_1","101_2"));
			}

			public TItemsInfo()
			{}
			
			public SItemInfo this[int idx]
			{
				get
				{
					if(ItemsInfo.Contains(idx))
						return((SItemInfo)ItemsInfo[idx]);
					else
						return(new SItemInfo(string.Empty,string.Empty));
				}
			}
		}
	#endif

	#if CLASS_FACTORY
		// initialize private variable ONLY by ClassWithFactory::factory()
		class ClassWithFactory
		{
			int
				a,
				b;
			
            public ClassWithFactory factory(int i, int j)
			{
				ClassWithFactory
					tmp=new ClassWithFactory();

				tmp.a=i;
				tmp.b=j;

				return(tmp);
			}

			public void show()
			{
				Console.WriteLine("a è b: "+a+" "+b);
			}
		}
	#endif

	#if TEST_CALL_BY
		class CallByTest
		{
			public int
				a,
				b;
			
			public void CallByValue(int i, int j)
			{
				i*=5;
				j/=5;
			}

			public void CallByReference(ref int i, ref int j)
			{
				i*=5;
				j/=5;
			}

			public void CallWithObject(CallByTest obj)
			{
				obj.a*=100;
				obj.b/=20;
			}

			public void swapBad(CallByTest obj1, CallByTest obj2)
			{
				CallByTest
					obj;

				obj=obj2;
				obj2=obj1;
				obj1=obj;
			}

			public void swapGood(ref CallByTest obj1, ref CallByTest obj2)
			{
				CallByTest
					obj;

				obj=obj2;
				obj2=obj1;
				obj1=obj;
			}
		}
	#endif

	#if INHERITANCE
		#region TBase
		/// <summary>
		/// summary 4 TBase (additional info in hint @ name of class)
		/// </summary>
		class TBase
		{
			char
				Private;

			protected char
				Protected;

			public char
				TBaseChar,
				Char;

			public int
				TBaseInt,
				Int;

			public long
				TBaseLong,
				Long;

			static StreamWriter
				fstr_out=null;

			public virtual void WriteToLog(string aStr)
			{
				string
					OutputFileName=Directory.GetCurrentDirectory()+"\\log.log";

				if(fstr_out==null)
				{
					if(File.Exists(OutputFileName))
						File.Delete(OutputFileName);

					fstr_out=new StreamWriter(OutputFileName);
					if(!fstr_out.AutoFlush)
						fstr_out.AutoFlush=true;
				}

				if(fstr_out!=null && fstr_out.BaseStream!=null && fstr_out.BaseStream.CanWrite)
					fstr_out.WriteLine(aStr);
			}

			public TBase(char aTBaseChar, int aTBaseInt, long aTBaseLong, char aChar, int aInt, long aLong)
			{
				Private='\x0';

				Protected='\x0'; 

				TBaseChar=aTBaseChar;
				TBaseInt=aTBaseInt;
				TBaseLong=aTBaseLong;

				Char=aChar;
				Int=aInt;
				Long=aLong;

				WriteToLog("TBase::TBase(char aTBaseChar, int aTBaseInt, long aTBaseLong, char aChar, int aInt, long aLong)");
			}

			public TBase(TBase aBase):this(aBase.TBaseChar,aBase.TBaseInt,aBase.TBaseLong,aBase.Char,aBase.Int,aBase.Long)
			{
				WriteToLog("TBase::TBase(TBase aBase)");
			}

			public TBase():this('\x0',0,0L,'\x0',0,0L)
			{
				WriteToLog("TBase::TBase()");
			}

			~TBase()
			{
				WriteToLog("TBase::~TBase()");
			}

			public virtual void Show()
			{
				WriteToLog("TBaseChar="+TBaseChar.ToString()+"\tTBaseInt="+TBaseInt.ToString()+"\tTBaseLong="+TBaseLong.ToString()+"\tChar="+Char.ToString()+"\tInt="+Int.ToString()+"\tLong="+Long.ToString());
			}

			public virtual void Test()
			{
				Private='\x1';
				Protected='\x1';
				WriteToLog("TBase::Test()");
			}

			public virtual void TestTest()
			{
				Private='\x2';
				Protected='\x2';
				WriteToLog("TBase::TestTest()");
			}

			public void TestTestTest()
			{
				Private='\x3';
				Protected='\x3';
				WriteToLog("TBase::TestTestTest()");
			}
		}
		#endregion

		#region TDerivedBad
		class TDerivedBad:TBase
		{
			public char
				TDerivedBadChar;

			public int
				TDerivedBadInt;

			public long
				TDerivedBadLong;

			public TDerivedBad(char aTDerivedBadChar, int aTDerivedBadInt, long aTDerivedBadLong, char aTBaseChar, int aTBaseInt, long aTBaseLong, char aChar, int aInt, long aLong)
			// !!! WRONG !!!
			// call TBase::TBase()
			// needs :base(aTBaseChar,aTBaseInt,aTBaseLong,aChar,aInt,aLong)
			{
				TDerivedBadChar=aTDerivedBadChar;
				TDerivedBadInt=aTDerivedBadInt;
				TDerivedBadLong=aTDerivedBadLong;

				WriteToLog("TDerivedBad::TDerivedBad(char aTDerivedBadChar, int aTDerivedBadInt, long aTDerivedBadLong, char aTBaseChar, int aTBaseInt, long aTBaseLong, char aChar, int aInt, long aLong)");
			}

			public TDerivedBad(TDerivedBad aDerivedBad)
			// !!! WRONG !!!
			// call TBase::TBase()
			// needs :this(aDerivedBad.TDerivedBadChar,aDerivedBad.TDerivedBadInt,aDerivedBad.TDerivedBadLong,aDerivedBad.TBaseChar,aDerivedBad.TBaseInt,aDerivedBad.TBaseLong,aDerivedBad.Char,aDerivedBad.Int,aDerivedBad.Long)
			// ||
			// :base(aDerivedBad.TBaseChar,aDerivedBad.TBaseInt,aDerivedBad.TBaseLong,aDerivedBad.Char,aDerivedBad.Int,aDerivedBad.Long)
			// {
			// TDerivedBadChar=aDerivedBad.TDerivedBadChar;
			// TDerivedBadInt=aDerivedBad.TDerivedBadInt;
			// TDerivedBadLong=aDerivedBad.TDerivedBadLong;
			// }
			{
				WriteToLog("TDerived1:TDerivedBad(TDerivedBad aDerivedBad)");
			}

			public TDerivedBad()
			// !!! WRONG !!!
			// call TBase::TBase()
			// needs :this('\x0',0,0L,'\x0',0,0L,'\x0',0,0L)
			// ||
			// :base('\x0',0,0L,'\x0',0,0L)
			// {
			// TDerivedBadChar='\x0';
			// TDerivedBadInt=0;
			// TDerivedBadLong=0L;
			// }
			{
				WriteToLog("TDerivedBad::TDerivedBad()");
			}

			~TDerivedBad()
			{
				WriteToLog("TDerivedBad::~TDerivedBad()");
			}

			public override void Show()
			{
				WriteToLog("TDerivedBadChar="+TDerivedBadChar.ToString()+"\tTDerivedBadInt="+TDerivedBadInt.ToString()+"\tTDerivedBadLong="+TDerivedBadLong.ToString());
				base.Show();
			}

			public void Test()
			// !!! WRONG !!!
			// without override by TBaseRef call TBase::Test();
			{
				Protected='\x11';
				WriteToLog("TDerivedBad::Test()");
			}

			public void TestTest()
			// !!! WRONG !!!
			// without override by TBaseRef call TBase::TestTest();
			{
				Protected='\x21';
				WriteToLog("TDerivedBad::TestTest()");
			}

			public virtual void TestTestTest()
			// !!! WRONG !!!
			// without new generate
			// Compiler Warning (level 2) CS0108
			// The keyword new is required on 'member1' because it hides inherited member 'member2'
			{
				Protected='\x31';
				WriteToLog("TDerivedBad::TestTestTest()");
			}

			public virtual void TestTestTestTest()
			{
				Protected='\x41';
				WriteToLog("TDerivedBad::TestTestTestTest()");
			}
		}
		#endregion

		#region TDerived1
		class TDerived1:TBase
		{
			public char
				TDerived1Char;

			public int
				TDerived1Int;

			public long
				TDerived1Long;

			public TDerived1(char aTDerived1Char, int aTDerived1Int, long aTDerived1Long, char aTBaseChar, int aTBaseInt, long aTBaseLong, char aChar, int aInt, long aLong):base(aTBaseChar,aTBaseInt,aTBaseLong,aChar,aInt,aLong)
			{
				TDerived1Char=aTDerived1Char;
				TDerived1Int=aTDerived1Int;
				TDerived1Long=aTDerived1Long;

				WriteToLog("TDerived1::TDerived1(char aTDerived1Char, int aTDerived1Int, long aTDerived1Long, char aTBaseChar, int aTBaseInt, long aTBaseLong, char aChar, int aInt, long aLong)");
			}

			public TDerived1(TDerived1 aDerived1):this(aDerived1.TDerived1Char,aDerived1.TDerived1Int,aDerived1.TDerived1Long,aDerived1.TBaseChar,aDerived1.TBaseInt,aDerived1.TBaseLong,aDerived1.Char,aDerived1.Int,aDerived1.Long)
			{
				WriteToLog("TDerived1:TDerived1(TDerived1 aDerived1)");
			}

			public TDerived1():this('\x0',0,0L,'\x0',0,0L,'\x0',0,0L)
			{
				WriteToLog("TDerived1::TDerived1()");
			}

			~TDerived1()
			{
				WriteToLog("TDerived1::~TDerived1()");
			}
	
			public override void Show()
			{
				WriteToLog("TDerived1Char="+TDerived1Char.ToString()+"\tTDerived1Int="+TDerived1Int.ToString()+"\tTDerived1Long="+TDerived1Long.ToString());
				base.Show();
			}

			public override void Test()
			{
				Protected='\x11';
				WriteToLog("TDerived1::Test()");
			}

			public override void TestTest()
			{
				Protected='\x21';
				WriteToLog("TDerived1::TestTest()");
			}

			new public virtual void TestTestTest()
			{
				Protected='\x31';
				WriteToLog("TDerived1::TestTestTest()");
			}

			public virtual void TestTestTestTest()
			{
				Protected='\x41';
				WriteToLog("TDerived1::TestTestTestTest()");
			}
		}
		#endregion

		#region TDerived2
		class TDerived2:TDerived1
		{
			public char
				TDerived2Char;

			public int
				TDerived2Int;

			public long
				TDerived2Long;

			public TDerived2(char aTDerived2Char, int aTDerived2Int, long aTDerived2Long, char aTDerived1Char, int aTDerived1Int, long aTDerived1Long, char aTBaseChar, int aTBaseInt, long aTBaseLong, char aChar, int aInt, long aLong):base(aTDerived1Char,aTDerived1Int,aTDerived1Long,aTBaseChar,aTBaseInt,aTBaseLong,aChar,aInt,aLong)
			{
				TDerived2Char=aTDerived2Char;
				TDerived2Int=aTDerived2Int;
				TDerived2Long=aTDerived2Long;

				WriteToLog("TDerived2::TDerived2(char aTDerived2Char, int aTDerived2Int, long aTDerived2Long, char aTDerived1Char, int aTDerived1Int, long aTDerived1Long, char aTBaseChar, int aTBaseInt, long aTBaseLong, char aChar, int aInt, long aLong)");
			}

			public TDerived2(TDerived2 aDerived2):this(aDerived2.TDerived2Char,aDerived2.TDerived2Int,aDerived2.TDerived2Long,aDerived2.TDerived1Char,aDerived2.TDerived1Int,aDerived2.TDerived1Long,aDerived2.TBaseChar,aDerived2.TBaseInt,aDerived2.TBaseLong,aDerived2.Char,aDerived2.Int,aDerived2.Long)
			{
				WriteToLog("TDerived2::TDerived2(TDerived2 aDerived2)");
			}

			public TDerived2():this('\x0',0,0L,'\x0',0,0L,'\x0',0,0L,'\x0',0,0L)
			{
				WriteToLog("TDerived2::TDerived2()");
			}

			~TDerived2()
			{
				WriteToLog("TDerived2::~TDerived2()");
			}

			public override void Show()
			{
				WriteToLog("TDerived2Char="+TDerived2Char.ToString()+"\tTDerived2Int="+TDerived2Int.ToString()+"\tTDerived2Long="+TDerived2Long.ToString());
				base.Show();
			}

			public override void Test()
			{
				WriteToLog("TDerived2::Test()");
			}

			public override void TestTest()
			{
				WriteToLog("TDerived2::TestTest()");
			}

			public override void TestTestTest()
			{
				WriteToLog("TDerived2::TestTestTest()");
			}

			public override void TestTestTestTest()
			{
				WriteToLog("TDerived2::TestTestTestTest()");
			}
		}
		#endregion
	#endif

	/// <summary>
	/// Summary description for MainClass.
	/// </summary>
	class MainClass
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static int Main(string[] args)
		{
            #if TEST_FIELD_WITH_INITIALIZATION
		        var a = new TestClassWithFieldWithInitialization();
		        var b = new TestClassWithFieldWithInitialization(a);

                Console.WriteLine(a.FInt);
                Console.WriteLine(b.FInt);
            #endif

            #if TEST_OBJECT_INITIALIZER
		        int
		            _b_;

                TestClassObjectInitializer
                    testClassObjectInitializer = new TestClassObjectInitializer
                                                     {
                                                         FInt1 = IntFuncOutInt(1, out _b_),
                                                         FInt2 = _b_
                                                     };

                Console.WriteLine("{{FInt1: {0}, FInt2: {1}}}", testClassObjectInitializer.FInt1, testClassObjectInitializer.FInt2);

		        var a = new TestClassObjectInitializerII {FInt1 = 1, FInt2 = 1};
            #endif

            #if TEST_NEW_WITH_SET
                TestClassWithSet
                    testClassWithSet = new TestClassWithSet(13) {FInt = 169};

		        testClassWithSet.FInt *= testClassWithSet.FIntRO;
            #endif

			#if TEST_CLASS_STATIC
				TItemsInfo
					Obj1=new TItemsInfo(),
					Obj2=new TItemsInfo();

				Console.WriteLine(TItemsInfo.ItemsInfo.Count);
				Console.WriteLine(((SItemInfo)TItemsInfo.ItemsInfo[1]).Prop1);
				Console.WriteLine(((SItemInfo)TItemsInfo.ItemsInfo[10]).Prop2);
				// Console.WriteLine(TItemsInfo[1].Prop1);
			#endif

			#if CLASS_FACTORY
				ClassWithFactory
					tmpClassWithFactory=new ClassWithFactory();

				int
					i,
					j;

				for(i=0, j=10; i<10; ++i, --j)
				{
					ClassWithFactory
						anotherClassWithFactory=tmpClassWithFactory.factory(i,j);
					
					anotherClassWithFactory.show();
				}
			#endif
			#if TEST_CALL_BY
				int
					a=15,
					b=20;

				CallByTest
					tmpCallByTest=new CallByTest(),
					swapCallByTest=new CallByTest();
	
				tmpCallByTest.a=300;
				tmpCallByTest.b=800;
				swapCallByTest.a=13000;
				swapCallByTest.b=26000;

				Console.WriteLine("by value (integral)");
				Console.WriteLine("Before: a={0}\tb={1}",a,b);
				tmpCallByTest.CallByValue(a,b);
				Console.WriteLine("After: a={0}\tb={1}",a,b);
				Console.WriteLine();

				Console.WriteLine("by reference (integral)");
				Console.WriteLine("Before: a={0}\tb={1}",a,b);
				tmpCallByTest.CallByReference(ref a, ref b);
				Console.WriteLine("After: a={0}\tb={1}",a,b);
				Console.WriteLine();

				Console.WriteLine("by value (reference)");
				Console.WriteLine("Before: a={0}\tb={1}",tmpCallByTest.a,tmpCallByTest.b);
				tmpCallByTest.CallWithObject(tmpCallByTest);
				Console.WriteLine("After: a={0}\tb={1}",tmpCallByTest.a,tmpCallByTest.b);
				Console.WriteLine();

				Console.WriteLine("by value (reference)");	
				Console.WriteLine("Before: a={0}\tb={1}",tmpCallByTest.a,tmpCallByTest.b);
				Console.WriteLine("Before: a={0}\tb={1}",swapCallByTest.a,swapCallByTest.b);
				tmpCallByTest.swapBad(tmpCallByTest,swapCallByTest);
				Console.WriteLine("After: a={0}\tb={1}",tmpCallByTest.a,tmpCallByTest.b);
				Console.WriteLine("After: a={0}\tb={1}",swapCallByTest.a,swapCallByTest.b);
				Console.WriteLine();

				Console.WriteLine("by reference (reference)");
				Console.WriteLine("Before: a={0}\tb={1}",tmpCallByTest.a,tmpCallByTest.b);
				Console.WriteLine("Before: a={0}\tb={1}",swapCallByTest.a,swapCallByTest.b);
				tmpCallByTest.swapGood(ref tmpCallByTest, ref swapCallByTest);
				Console.WriteLine("After: a={0}\tb={1}",tmpCallByTest.a,tmpCallByTest.b);
				Console.WriteLine("After: a={0}\tb={1}",swapCallByTest.a,swapCallByTest.b);
				Console.WriteLine();
			#endif
			
			#if INHERITANCE
				#region TBase
				TBase
					BaseRef=null; // nothing call

				TBase
					b1=new TBase();
				
				b1.WriteToLog("");

				b1.TBaseChar='\x1';
				b1.TBaseInt=1;
				b1.TBaseLong=1L;
				b1.Char='\x1';
				b1.Int=1;
				b1.Long=1L;
				b1.Show();
				b1.WriteToLog("");

				b1.Test();
				b1.TestTest();
				b1.TestTestTest();
				b1.WriteToLog("");

				TBase
					b2=new TBase(b1);
				
				b2.WriteToLog("");

				b2.TBaseChar='\x2';
				b2.TBaseInt=2;
				b2.TBaseLong=2L;
				b2.Char='\x2';
				b2.Int=2;
				b2.Long=2L;
				b2.Show();
				b2.WriteToLog("");

				TBase
					b3=b2; // nothing call 

				b3.TBaseChar='\x3'; // equ b2.TBaseChar='\x3';
				b3.TBaseInt=3; // equ b2.TBaseInt=3;
				b3.TBaseLong=3L; // equ b2.TBaseLong=3L;
				b3.Char='\x3'; // equ b2.Char='\x3';
				b3.Int=3; // equ b2.Int=3;
				b3.Long=3L; // equ b2.Long=3L;
				b2.Show();
				b3.Show();
				b2.WriteToLog("");

				TBase
					b4; // nothing call

				b4=b3;
				b3.Show();
				b3.WriteToLog("");
				b4.Show();
				b3=b1;
				b1.Show();
				b3.Show();
				b1.WriteToLog("");
				b4.TBaseChar='\x4'; // equ b2.TBaseChar='\x4';
				b4.TBaseInt=4; // equ b2.TBaseInt=4;
				b4.TBaseLong=4L; // equ b2.TBaseLong=4L;
				b4.Char='\x4'; // equ b2.Char='\x4';
				b4.Int=4; // equ b2.Int=4;
				b4.Long=4L; // equ b2.Long=4L;
				b1.Show();
				b2.Show();
				b3.Show();
				b4.Show();
				b4.WriteToLog("");
				#endregion

				#region TDerivedBad
				TDerivedBad
					db1=new TDerivedBad('\x1',1,1L,'\x1',1,1L,'\x1',1,1L);

				db1.WriteToLog("");
				db1.Show();
				db1.Test();
				db1.TestTest();
				db1.TestTestTest();
				db1.TestTestTestTest();

				TDerivedBad
					db2=new TDerivedBad(db1);

				db2.WriteToLog("");
				db2.Show();	

				TDerivedBad
					db3=new TDerivedBad();

				db3.WriteToLog("");
				db3.Show();
				#endregion

				TDerived1
					Derived1Ref;

				TDerived1
					d11=new TDerived1('\x1',1,1L,'\x1',1,1L,'\x1',1,1L);

				d11.WriteToLog("");

				d11.TDerived1Char='\x11';
				d11.TDerived1Int=11;
				d11.TDerived1Long=11L;
				d11.TBaseChar='\x11';
				d11.TBaseInt=11;
				d11.TBaseLong=11L;
				d11.Char='\x11';
				d11.Int=11;
				d11.Long=11L;
				d11.Show();

				d11.Test();
				d11.TestTest();
				d11.TestTestTest();
				d11.TestTestTestTest();
				d11.WriteToLog("");

				TDerived2
					d21=new TDerived2('\x2',2,2L,'\x2',2,2L,'\x2',2,2L,'\x2',2,2L),
					d22=null;

				d21.WriteToLog("");
				
				d21.TDerived2Char='\x21';
				d21.TDerived2Int=21;
				d21.TDerived2Long=21L;
				d21.TDerived1Char='\x21';
				d21.TDerived1Int=21;
				d21.TDerived1Long=21L;
				d21.TBaseChar='\x21';
				d21.TBaseInt=21;
				d21.TBaseLong=21L;
				d21.Char='\x21';
				d21.Int=21;
				d21.Long=21L;

				d21.Test();
				d21.TestTest();
				d21.TestTestTest();
				d21.TestTestTestTest();
				d21.WriteToLog("");

				BaseRef=b1;
                BaseRef.WriteToLog(string.Format("BaseRef.GetType() = \"{0}\"", BaseRef.GetType()));
                BaseRef.WriteToLog(string.Format("null {0}is TBase", null is TBase ? string.Empty : "!"));
                BaseRef.WriteToLog(string.Format("BaseRef {0}is TBase", BaseRef is TBase ? string.Empty : "!"));
                BaseRef.WriteToLog(string.Format("BaseRef {0}is TDerivedBad", BaseRef is TDerivedBad ? string.Empty : "!"));
                BaseRef.WriteToLog(string.Format("BaseRef {0}is TDerived1", BaseRef is TDerived1 ? string.Empty : "!"));
                BaseRef.WriteToLog(string.Format("BaseRef {0}is TDerived2", BaseRef is TDerived2 ? string.Empty : "!"));
				BaseRef.Test();
				BaseRef.TestTest();
				BaseRef.TestTestTest();
				BaseRef.WriteToLog("");

				BaseRef=db1;
                BaseRef.WriteToLog(string.Format("BaseRef.GetType() = \"{0}\"", BaseRef.GetType()));
                BaseRef.WriteToLog(string.Format("BaseRef {0}is TBase", BaseRef is TBase ? string.Empty : "!"));
                BaseRef.WriteToLog(string.Format("BaseRef {0}is TDerivedBad", BaseRef is TDerivedBad ? string.Empty : "!"));
                BaseRef.WriteToLog(string.Format("BaseRef {0}is TDerived1", BaseRef is TDerived1 ? string.Empty : "!"));
                BaseRef.WriteToLog(string.Format("BaseRef {0}is TDerived2", BaseRef is TDerived2 ? string.Empty : "!"));
                BaseRef.Test();
				BaseRef.TestTest();
				BaseRef.TestTestTest();
				BaseRef.WriteToLog("");

				BaseRef=d11;
                BaseRef.WriteToLog(string.Format("BaseRef.GetType() = \"{0}\"", BaseRef.GetType()));
                BaseRef.WriteToLog(string.Format("BaseRef {0}is TBase", BaseRef is TBase ? string.Empty : "!"));
                BaseRef.WriteToLog(string.Format("BaseRef {0}is TDerivedBad", BaseRef is TDerivedBad ? string.Empty : "!"));
                BaseRef.WriteToLog(string.Format("BaseRef {0}is TDerived1", BaseRef is TDerived1 ? string.Empty : "!"));
                BaseRef.WriteToLog(string.Format("BaseRef {0}is TDerived2", BaseRef is TDerived2 ? string.Empty : "!"));
                BaseRef.Test();
				BaseRef.TestTest();
				BaseRef.TestTestTest();
				BaseRef.WriteToLog("");

                Type
                    tmpType = BaseRef.GetType();

				BaseRef=d21;
                BaseRef.WriteToLog(string.Format("BaseRef.GetType() = \"{0}\"", BaseRef.GetType()));
                BaseRef.WriteToLog(string.Format("BaseRef {0}is TBase", BaseRef is TBase ? string.Empty : "!"));
                BaseRef.WriteToLog(string.Format("BaseRef {0}is TDerivedBad", BaseRef is TDerivedBad ? string.Empty : "!"));
                BaseRef.WriteToLog(string.Format("BaseRef {0}is TDerived1", BaseRef is TDerived1 ? string.Empty : "!"));
                BaseRef.WriteToLog(string.Format("BaseRef {0}is TDerived2", BaseRef is TDerived2 ? string.Empty : "!"));
                BaseRef.WriteToLog(string.Format("{0}typeof(TBase).IsInstanceOfType(BaseRef)", typeof(TBase).IsInstanceOfType(BaseRef) ? string.Empty : "!"));
                BaseRef.WriteToLog(string.Format("{0}typeof(TDerivedBad).IsInstanceOfType(BaseRef)", typeof(TDerivedBad).IsInstanceOfType(BaseRef) ? string.Empty : "!"));
                BaseRef.WriteToLog(string.Format("{0}typeof(TDerived1).IsInstanceOfType(BaseRef)", typeof(TDerived1).IsInstanceOfType(BaseRef) ? string.Empty : "!"));
                BaseRef.WriteToLog(string.Format("{0}typeof(TDerived2).IsInstanceOfType(BaseRef)", typeof(TDerived2).IsInstanceOfType(BaseRef) ? string.Empty : "!"));
                BaseRef.Test();
				BaseRef.TestTest();
				BaseRef.TestTestTest();
				BaseRef.WriteToLog("");

				Derived1Ref=d11;
                Derived1Ref.WriteToLog(string.Format("Derived1Ref.GetType() = \"{0}\"", Derived1Ref.GetType()));
                Derived1Ref.WriteToLog(string.Format("Derived1Ref {0}is TBase", Derived1Ref is TBase ? string.Empty : "!"));
                Derived1Ref.WriteToLog(string.Format("Derived1Ref {0}is TDerivedBad", Derived1Ref is TDerivedBad ? string.Empty : "!"));
                Derived1Ref.WriteToLog(string.Format("Derived1Ref {0}is TDerived1", Derived1Ref is TDerived1 ? string.Empty : "!"));
                Derived1Ref.WriteToLog(string.Format("Derived1Ref {0}is TDerived2", Derived1Ref is TDerived2 ? string.Empty : "!"));
                Derived1Ref.Test();
				Derived1Ref.TestTest();
				Derived1Ref.TestTestTest();
				Derived1Ref.TestTestTestTest();
				Derived1Ref.WriteToLog("");

				Derived1Ref=d21;
                Derived1Ref.WriteToLog(string.Format("Derived1Ref.GetType() = \"{0}\"", Derived1Ref.GetType()));
                Derived1Ref.WriteToLog(string.Format("Derived1Ref {0}is TBase", Derived1Ref is TBase ? string.Empty : "!"));
                Derived1Ref.WriteToLog(string.Format("Derived1Ref {0}is TDerivedBad", Derived1Ref is TDerivedBad ? string.Empty : "!"));
                Derived1Ref.WriteToLog(string.Format("Derived1Ref {0}is TDerived1", Derived1Ref is TDerived1 ? string.Empty : "!"));
                Derived1Ref.WriteToLog(string.Format("Derived1Ref {0}is TDerived2", Derived1Ref is TDerived2 ? string.Empty : "!"));
                Derived1Ref.Test();
				Derived1Ref.TestTest();
				Derived1Ref.TestTestTest();
				Derived1Ref.TestTestTestTest();
				Derived1Ref.WriteToLog("");

		        object tmpObject = d21;
		        var tmpVar = tmpObject as TBase;
		        tmpType = tmpVar.GetType();
			#endif

			#if TEST_CYCLE
				ArrayList
					al=new ArrayList();

				al.Add("First");
				al.Add("Second");
				al.Add("Third");
				al.Add("Fourth");
				al.Add("Fifth");
				al.Add("Sixth");
				al.Add("Seventh");
				al.Add("Eighth");
				al.Add("Ninth");

				foreach(string s in al)
				{
					ClassSimple
						tmpClassSimple;

					string
						tmpString;

					tmpClassSimple=new ClassSimple(s);
					tmpString=tmpClassSimple.A;
				}
			#endif

			return(0);
        }

        #if TEST_OBJECT_INITIALIZER
            static int IntFuncOutInt(int a, out int b)
            {
                b = a*3;
                return a*2;
            }
        #endif
	}
}
