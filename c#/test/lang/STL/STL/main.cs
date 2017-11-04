//#define TEST_HASHTABLE
//#define TEST_STRUCT_IN_HASH
//#define TEST_ADD_TO_STL_COLLECTION
//#define TEST_CLONE
//#define TEST_CLONE_FULL
//#define TEST_SELF_SEARCH
//#define ARRAY_LIST
//#define HASH_IN_HASH

using System;
using System.Collections;

#if TEST_ADD_TO_STL_COLLECTION
	using System.Data;
#endif

namespace STL
{
	#if TEST_STRUCT_IN_HASH
		interface IStruct
		{
			int A { get; set; }
		}

		struct Struct:IStruct
		{
			int _a;
			public int A { get { return _a;} set { if(_a!=value) _a=value; }}
		}

		struct TestStruct
		{
			private int
				FA,
				FB;

			public int
				pA,
				pB;

			public TestStruct(TestStruct obj):this(obj.A,obj.B,obj.pA,obj.pB)
			{}
			//---------------------------------------------------------------------------

			public TestStruct(int aA, int aB, int apA, int apB)
			{
				FA=aA;
				FB=aB;
				pA=apA;
				pB=apB;
			}
			//---------------------------------------------------------------------------

			public int A
			{
				set
				{
					if(FA!=value)
						FA=value;
				}
				get
				{
					return(FA);
				}
			}
			//---------------------------------------------------------------------------

			public int B
			{
				set
				{
					if(FB!=value)
						FB=value;
				}
				get
				{
					return(FB);
				}
			}
			//---------------------------------------------------------------------------
		}
		//---------------------------------------------------------------------------

		struct TestStructWToString
		{
			private int
				FA,
				FB;

			public int
				pA,
				pB;

			public TestStructWToString(TestStruct obj):this(obj.A,obj.B,obj.pA,obj.pB)
			{}
			//---------------------------------------------------------------------------

			public TestStructWToString(int aA, int aB, int apA, int apB)
			{
				FA=aA;
				FB=aB;
				pA=apA;
				pB=apB;
			}
			//---------------------------------------------------------------------------

			public int A
			{
				set
				{
					if(FA!=value)
						FA=value;
				}
				get
				{
					return(FA);
				}
			}
			//---------------------------------------------------------------------------

			public int B
			{
				set
				{
					if(FB!=value)
						FB=value;
				}
				get
				{
					return(FB);
				}
			}
			//---------------------------------------------------------------------------
			
			public override string ToString()
			{
				return("{A: "+A+", B: "+B+", pA: "+pA+", pB: "+pB+"}");
			}
			//---------------------------------------------------------------------------
		}
		//---------------------------------------------------------------------------
	#endif

	#if TEST_CLONE
		public class X
		{
			public int
				a;

			public X(int x)
			{
				a=x;
			}
		}

		public class TestClone:ICloneable
		{
			public X
				o;

			public int
				b;

			public TestClone(int x, int y)
			{
				o=new X(x);
				b=y;
			}

			public void show(string name)
			{
				Console.Write("Значение объекта "+name+" : ");
				Console.WriteLine("o.a: {0}, b: {1}",o.a,b);
			}

			public object Clone()
			{
				TestClone
					temp;
				
				#if TEST_CLONE_FULL
					temp=new TestClone(o.a, b);
				#else
					temp=(TestClone)MemberwiseClone();
				#endif

				return(temp);
			}
		}
	#endif

	#if TEST_SELF_SEARCH
		public class RelationFieldInfo:IComparable
		{
			public string
				FieldName;

			public object
				FieldValue;

			public RelationFieldInfo():this(string.Empty,null)
			{}

			public RelationFieldInfo(RelationFieldInfo aObj):this(aObj.FieldName,aObj.FieldValue)
			{}

			public RelationFieldInfo(string aFieldName, object aFieldValue)
			{
				FieldName=aFieldName;
				FieldValue=aFieldValue;
			}

			public static bool operator == (RelationFieldInfo left, RelationFieldInfo right)
			{
				return(left.FieldName==right.FieldName);
			}

			public static bool operator == (RelationFieldInfo left, string right)
			{
				return(left.FieldName==right);
			}

			public static bool operator == (string left, RelationFieldInfo right)
			{
				return(left==right.FieldName);
			}

			public static bool operator != (RelationFieldInfo left, RelationFieldInfo right)
			{
				return(!(left==right));
			}

			public static bool operator != (RelationFieldInfo left, string right)
			{
				return(!(left==right));
			}

			public static bool operator != (string left, RelationFieldInfo right)
			{
				return(!(left==right));
			}

			public override bool Equals(object obj)
			{
				return(this==(RelationFieldInfo)obj);
			}

			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			public int CompareTo(object obj)
			{
				int
					result=-1;

				Type
					t=obj.GetType();

				switch(Type.GetTypeCode(t))
				{
					case System.TypeCode.String :
					{
						result=this.FieldName.CompareTo(Convert.ToString(obj));

						break;	
					}
					default :
					{
						result=this.FieldName.CompareTo(((RelationFieldInfo)obj).FieldName);

						break;	
					}
				}

				return(result);
			}

			public override string ToString()
			{
				return("{FiledName: \""+FieldName+"\", FieldValue: "+FieldValue.ToString()+"}");
			}
		}

		public class PrimaryKeyFieldInfo:RelationFieldInfo
		{
			public object
				PrimaryKeyFieldValue;

			public PrimaryKeyFieldInfo():this(string.Empty,null,null)
			{}

			public PrimaryKeyFieldInfo(PrimaryKeyFieldInfo aObj):this(aObj.FieldName,aObj.PrimaryKeyFieldValue,aObj.FieldValue)
			{}

			public PrimaryKeyFieldInfo(string aFieldName, object aPrimaryKeyFieldValue, object aFieldValue):base(aFieldName,aFieldValue)
			{
				PrimaryKeyFieldValue=aPrimaryKeyFieldValue;
			}

			public override string ToString()
			{
				return("{FiledName: \""+FieldName+"\", PrimaryKeyFieldValue: "+PrimaryKeyFieldValue.ToString()+", FieldValue: "+FieldValue.ToString()+"}");
			}
		}
	#endif

	class TBaseParam:object
	{
		public object
			Value;

		public TBaseParam(object aValue)
		{
			Value=aValue;
		}

		public TBaseParam(TBaseParam obj):this(obj.Value)
		{}

		public TBaseParam():this(null)
		{}

		public static bool operator == (TBaseParam obj1, TBaseParam obj2)
		{
			bool
				Result=false;
			
			Type
				t1=obj1.Value.GetType();

			if(!t1.IsPrimitive
			   || t1!=obj2.Value.GetType()
			  )
				return(Result);

			switch(Type.GetTypeCode(t1))
			{
				case System.TypeCode.Int32 :
					{
						Result = Convert.ToInt32(obj1.Value)==Convert.ToInt32(obj2.Value);	
						break;
					}
			}

			return(Result);
		}

		public static bool operator != (TBaseParam obj1, TBaseParam obj2)
		{
			return(!(obj1==obj2));
		}

		public override bool Equals(object obj)
		{
			return(this==(TBaseParam)obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}

	class TParam:TBaseParam
	{
		public string
			StringValue,
			StringValueAdd;

		public int
			IntValue;

		public TParam(object aValue, string aStringValue, string aStringValueAdd, int aIntValue):base(aValue)
		{
			StringValue=aStringValue;
			StringValueAdd=aStringValueAdd;
			IntValue=aIntValue;
		}

		public TParam(TParam obj):this(obj.Value,obj.StringValue,obj.StringValueAdd,obj.IntValue)
		{}

		public TParam():this(null,null,null,0)
		{}
	}

	class MainClass
	{
		static Hashtable
			mapBP=null;

		static SortedList
			mapBPSorted=null;

		static IDictionaryEnumerator
			myEnumerator=null;

		[STAThread]
		public static void Main(string[] args)
		{
			string
				tmpString=string.Empty;

			int
				idx;

		    object
		        tmpObject;

            #if TEST_HASHTABLE
                mapBP = new Hashtable();

		        tmpString = "1st";
                tmpObject = mapBP[tmpString];
		        if (tmpObject == null)
                    tmpObject = tmpString;

                tmpString = "2nd";
		        mapBP[tmpString] = tmpString;
                tmpObject = mapBP[tmpString];
                if (tmpObject == null)
                    tmpObject = tmpString;

		        mapBP = null;
            #endif

			#if TEST_STRUCT_IN_HASH
				TestStruct
					tmpTestStruct;

				if(mapBP==null)
					mapBP=new Hashtable();

				mapBP.Add(1,new Struct());
				((IStruct)mapBP[1]).A++;
				++((IStruct)mapBP[1]).A;
				((IStruct)mapBP[1]).A+=1;
				((IStruct)mapBP[1]).A=((IStruct)mapBP[1]).A+1;

				mapBP.Clear();
				mapBP.Add(1,new TestStruct(11,111,1111,11111));
				mapBP.Add(2,new TestStruct(22,222,2222,22222));
				mapBP.Add(3,new TestStruct(33,333,3333,33333));
				foreach(int ii in mapBP.Keys)
				{
					Console.WriteLine("mapBP[{0}]={{A:{1}, B:{2}, pA:{3}, pB:{4}}} (ToString(): \"{5}\")",ii,((TestStruct)mapBP[ii]).A,((TestStruct)mapBP[ii]).B,((TestStruct)mapBP[ii]).pA,((TestStruct)mapBP[ii]).pB,mapBP[ii].ToString());
					tmpTestStruct=(TestStruct)mapBP[ii];
					++tmpTestStruct.A;
					tmpTestStruct.A++;
					tmpTestStruct.A+=1;
					tmpTestStruct.A=tmpTestStruct.A+1;
					//((TestStruct)mapBP[ii]).A++;
					//((TestStruct)mapBP[ii]).A+=1;
					//((TestStruct)mapBP[ii]).A=((TestStruct)mapBP[ii]).A+1;
					//mapBP[ii]=tmpTestStruct;
					Console.WriteLine("mapBP[{0}]={{A:{1}, B:{2}, pA:{3}, pB:{4}}} (ToString(): \"{5}\")",ii,((TestStruct)mapBP[ii]).A,((TestStruct)mapBP[ii]).B,((TestStruct)mapBP[ii]).pA,((TestStruct)mapBP[ii]).pB,mapBP[ii].ToString());
				}
				Console.WriteLine();

				myEnumerator=mapBP.GetEnumerator();
				while(myEnumerator.MoveNext())
				{
					Console.WriteLine("mapBP[{0}]={{A:{1}, B:{2}, pA:{3}, pB:{4}}} (ToString(): \"{5}\")",myEnumerator.Key,((TestStruct)mapBP[myEnumerator.Key]).A,((TestStruct)mapBP[myEnumerator.Key]).B,((TestStruct)mapBP[myEnumerator.Key]).pA,((TestStruct)mapBP[myEnumerator.Key]).pB,mapBP[myEnumerator.Key].ToString());
					tmpTestStruct=(TestStruct)mapBP[myEnumerator.Key];
					++tmpTestStruct.A;
					tmpTestStruct.A++;
					tmpTestStruct.A+=1;
					tmpTestStruct.A=tmpTestStruct.A+1;
					//mapBP[myEnumerator.Key]=tmpTestStruct;
					Console.WriteLine("mapBP[{0}]={{A:{1}, B:{2}, pA:{3}, pB:{4}}} (ToString(): \"{5}\")",myEnumerator.Key,((TestStruct)mapBP[myEnumerator.Key]).A,((TestStruct)mapBP[myEnumerator.Key]).B,((TestStruct)mapBP[myEnumerator.Key]).pA,((TestStruct)mapBP[myEnumerator.Key]).pB,mapBP[myEnumerator.Key].ToString());
				}
				Console.WriteLine();

				mapBP.Clear();
				mapBP.Add(1,new TestStructWToString(111,1111,11111,111111));
				mapBP.Add(2,new TestStructWToString(222,2222,22222,222222));
				mapBP.Add(3,new TestStructWToString(333,3333,33333,333333));

				foreach(int ii in mapBP.Keys)
				{
					Console.WriteLine("mapBP[{0}]={{A:{1}, B:{2}}} (ToString(): \"{3}\")",ii,((TestStructWToString)mapBP[ii]).A,((TestStructWToString)mapBP[ii]).B,mapBP[ii].ToString());
				}
				Console.WriteLine();
			#endif

			#if TEST_ADD_TO_STL_COLLECTION
				mapBP=new Hashtable();

				DataSet
					DSOrg=new DataSet();

				mapBP.Add("DSOrg",DSOrg);
				Console.WriteLine("DSOrg.Tables.Count={0}",DSOrg.Tables.Count);
				Console.WriteLine("((DataSet)mapBP[\"DSOrg\"]).Tables.Count={0}",((DataSet)mapBP["DSOrg"]).Tables.Count);

				DSOrg.Tables.Add("Table1");
				Console.WriteLine("DSOrg.Tables.Count={0}",DSOrg.Tables.Count);
				Console.WriteLine("((DataSet)mapBP[\"DSOrg\"]).Tables.Count={0}",((DataSet)mapBP["DSOrg"]).Tables.Count);

				DSOrg.Tables.Add("Table2");
				Console.WriteLine("DSOrg.Tables.Count={0}",DSOrg.Tables.Count);
				Console.WriteLine("((DataSet)mapBP[\"DSOrg\"]).Tables.Count={0}",((DataSet)mapBP["DSOrg"]).Tables.Count);

				DataSet
					DSNew=new DataSet();
				
				DSNew.Tables.Add("Table1");
				DSNew.Tables.Add("Table2");
				DSNew.Tables.Add("Table3");

				DSOrg=DSNew;
				Console.WriteLine("DSOrg.Tables.Count={0}",DSOrg.Tables.Count);
				Console.WriteLine("((DataSet)mapBP[\"DSOrg\"]).Tables.Count={0}",((DataSet)mapBP["DSOrg"]).Tables.Count);
			#endif

			#if TEST_CLONE
				TestClone
					ob1=new TestClone(10,20);

				ob1.show("ob1");
				Console.WriteLine("Создаем объект ob2 как клон объекта ob1.");

				TestClone
					ob2=(TestClone)ob1.Clone();

				ob2.show("ob2");

				Console.WriteLine("Заменяем член ob1.o.a числом 99, а член ob1.b числом 88.");
				ob1.o.a=99;
				ob1.b=88;

				ob1.show("ob1");
				ob2.show("ob2");
			#endif

			#if TEST_SELF_SEARCH
				RelationFieldInfo[]
					RelationFieldInfo={	new RelationFieldInfo("1st",1),
										new RelationFieldInfo("2nd",2),
										new RelationFieldInfo("3rd",3)
									};

				Array.Sort(RelationFieldInfo);
				
				if((idx=Array.BinarySearch(RelationFieldInfo,tmpString="2nd"))>=0)
					tmpString="\""+tmpString+"\" was found @ RelationFieldInfo["+idx+"]=\""+RelationFieldInfo[idx].ToString()+"\"";
				else
				{
					if((idx=~idx)>=RelationFieldInfo.Length)
						--idx;

					tmpString="\""+tmpString+"\" was not found. The next larger object is at index "+idx+" (RelationFieldInfo["+idx+"]=\""+RelationFieldInfo[idx].ToString()+"\")";
				}
				Console.WriteLine(tmpString);

				if((idx=Array.BinarySearch(RelationFieldInfo,tmpString="3rd"))>=0)
					tmpString="\""+tmpString+"\" was found @ RelationFieldInfo["+idx+"]=\""+RelationFieldInfo[idx].ToString()+"\"";
				else
				{
					if((idx=~idx)>=RelationFieldInfo.Length)
						--idx;

					tmpString="\""+tmpString+"\" was not found. The next larger object is at index "+idx+" (RelationFieldInfo["+idx+"]=\""+RelationFieldInfo[idx].ToString()+"\")";
				}
				Console.WriteLine(tmpString);

				if((idx=Array.BinarySearch(RelationFieldInfo,tmpString="1st"))>=0)
					tmpString="\""+tmpString+"\" was found @ RelationFieldInfo["+idx+"]=\""+RelationFieldInfo[idx].ToString()+"\"";
				else
				{
					if((idx=~idx)>=RelationFieldInfo.Length)
						--idx;

					tmpString="\""+tmpString+"\" was not found. The next larger object is at index "+idx+" (RelationFieldInfo["+idx+"]=\""+RelationFieldInfo[idx].ToString()+"\")";
				}
				Console.WriteLine(tmpString);

				if((idx=Array.BinarySearch(RelationFieldInfo,tmpString="21nd"))>=0)
					tmpString="\""+tmpString+"\" was found @ RelationFieldInfo["+idx+"]=\""+RelationFieldInfo[idx].ToString()+"\"";
				else
				{
					if((idx=~idx)>=RelationFieldInfo.Length)
						--idx;

					tmpString="\""+tmpString+"\" was not found. The next larger object is at index "+idx+" (RelationFieldInfo["+idx+"]=\""+RelationFieldInfo[idx].ToString()+"\")";
				}
				Console.WriteLine(tmpString);

				PrimaryKeyFieldInfo[]
					PrimaryKeyFieldInfo={
											new PrimaryKeyFieldInfo("1st",1,1),
											new PrimaryKeyFieldInfo("2nd",2,2),
											new PrimaryKeyFieldInfo("3rd",3,3) 
										};

				Array.Sort(PrimaryKeyFieldInfo);
					
				if((idx=Array.BinarySearch(PrimaryKeyFieldInfo,tmpString="2nd"))>=0)
					tmpString="\""+tmpString+"\" was found @ PrimaryKeyFieldInfo["+idx+"]=\""+PrimaryKeyFieldInfo[idx].ToString()+"\"";
				else
				{
					if((idx=~idx)>=PrimaryKeyFieldInfo.Length)
						--idx;

					tmpString="\""+tmpString+"\" was not found. The next larger object is at index "+idx+" (PrimaryKeyFieldInfo["+idx+"]=\""+PrimaryKeyFieldInfo[idx].ToString()+"\")";
				}
				Console.WriteLine(tmpString);

				if((idx=Array.BinarySearch(PrimaryKeyFieldInfo,tmpString="3rd"))>=0)
					tmpString="\""+tmpString+"\" was found @ PrimaryKeyFieldInfo["+idx+"]=\""+PrimaryKeyFieldInfo[idx].ToString()+"\"";
				else
				{
					if((idx=~idx)>=PrimaryKeyFieldInfo.Length)
						--idx;

					tmpString="\""+tmpString+"\" was not found. The next larger object is at index "+idx+" (PrimaryKeyFieldInfo["+idx+"]=\""+PrimaryKeyFieldInfo[idx].ToString()+"\")";
				}
				Console.WriteLine(tmpString);

				if((idx=Array.BinarySearch(PrimaryKeyFieldInfo,tmpString="1st"))>=0)
					tmpString="\""+tmpString+"\" was found @ PrimaryKeyFieldInfo["+idx+"]=\""+PrimaryKeyFieldInfo[idx].ToString()+"\"";
				else
				{
					if((idx=~idx)>=PrimaryKeyFieldInfo.Length)
						--idx;

					tmpString="\""+tmpString+"\" was not found. The next larger object is at index "+idx+" (PrimaryKeyFieldInfo["+idx+"]=\""+PrimaryKeyFieldInfo[idx].ToString()+"\")";
				}
				Console.WriteLine(tmpString);

				if((idx=Array.BinarySearch(PrimaryKeyFieldInfo,tmpString="21nd"))>=0)
					tmpString="\""+tmpString+"\" was found @ PrimaryKeyFieldInfo["+idx+"]=\""+PrimaryKeyFieldInfo[idx].ToString()+"\"";
				else
				{
					if((idx=~idx)>=PrimaryKeyFieldInfo.Length)
						--idx;

					tmpString="\""+tmpString+"\" was not found. The next larger object is at index "+idx+" (PrimaryKeyFieldInfo["+idx+"]=\""+PrimaryKeyFieldInfo[idx].ToString()+"\")";
				}
				Console.WriteLine(tmpString);
			#endif

			#if ARRAY_LIST
				ArrayList
					vArrayList=new ArrayList();

				vArrayList.Add("A");
				vArrayList.Add("A1");
				vArrayList.Add("B");
				vArrayList.Add("B10");
				vArrayList.Add("D");
				vArrayList.Add("D1");
				vArrayList.Add("D10");
				vArrayList.Add("B1");

				vArrayList.Sort();

				idx=vArrayList.BinarySearch(tmpString="A1");
				if(idx>=0)
					tmpString="vArrayList["+idx+"]=\""+tmpString+"\"";
				else
				{
					if((idx=~idx)>=vArrayList.Count)
						--idx;

					tmpString="\""+tmpString+"\" was not found. The next larger object is at index "+idx+" (vArrayList["+idx+"]=\""+vArrayList[idx]+"\")";
				}

				idx=vArrayList.BinarySearch(tmpString="C");
				if(idx>=0)
					tmpString="vArrayList["+idx+"]=\""+tmpString+"\"";
				else
				{
					if((idx=~idx)>=vArrayList.Count)
						--idx;

					tmpString="\""+tmpString+"\" was not found. The next larger object is at index "+idx+" (vArrayList["+idx+"]=\""+vArrayList[idx]+"\")";
				}

				idx=vArrayList.BinarySearch(tmpString="F");
				if(idx>=0)
					tmpString="vArrayList["+idx+"]=\""+tmpString+"\"";
				else
				{
					if((idx=~idx)>=vArrayList.Count)
						--idx;

					tmpString="\""+tmpString+"\" was not found. The next larger object is at index "+idx+" (vArrayList["+idx+"]=\""+vArrayList[idx]+"\")";
				}

				idx=vArrayList.BinarySearch(tmpString="FDecimal_1");
				if(idx>=0)
					tmpString="vArrayList["+idx+"]=\""+tmpString+"\"";
				else
				{
					if((idx=~idx)>=vArrayList.Count)
						--idx;

					tmpString="\""+tmpString+"\" was not found. The next larger object is at index "+idx+" (vArrayList["+idx+"]=\""+vArrayList[idx]+"\")";
				}

				string[]
					tmpStringArray=new string[vArrayList.Count];

				vArrayList.CopyTo(tmpStringArray);

				tmpString=string.Empty;
				for(idx=0; idx<tmpStringArray.Length; ++idx)
				{
					if(tmpString!=string.Empty)
						tmpString+=Environment.NewLine;

					tmpString+=tmpStringArray[idx];
				}

				vArrayList=new ArrayList();
				vArrayList.Add(500000000000988);
				vArrayList.Add(500000000000978);
				vArrayList.Add(500000000000998);
				vArrayList.Add(500000000000938);
				vArrayList.Add(500000000000928);
				vArrayList.Sort();
				tmpString=500000000000938.ToString();
				idx=vArrayList.BinarySearch(500000000000938);
				if(idx>=0)
					tmpString="vArrayList["+idx+"]=\""+tmpString+"\"";
				else
				{
					if((idx=~idx)>=vArrayList.Count)
						--idx;

					tmpString="\""+tmpString+"\" was not found. The next larger object is at index "+idx+" (vArrayList["+idx+"]=\""+vArrayList[idx]+"\")";
				}

				IEnumerator
					tmpEnumerator;

				tmpEnumerator=vArrayList.GetEnumerator();
				while(tmpEnumerator.MoveNext())
				{
					tmpString=tmpEnumerator.Current.ToString();
				}
			#endif

			#if HASH_IN_HASH
				Hashtable
					Coeff=new Hashtable(),
					HashtableII,
					HashtableIII;

				int
					maxI=3,
					maxJ=4,
					maxK=4;

				string
					lValue,
					rValue;

				for(int ii=0; ii<maxI; ++ii)
				{
					if(!Coeff.ContainsKey(ii))
						Coeff.Add(ii,new Hashtable());

					for(int jj=0; jj<maxJ; ++jj)
					{
						if(!(Coeff[ii] as Hashtable).ContainsKey(jj))
							(Coeff[ii] as Hashtable).Add(jj,new Hashtable());

						for(int kk=0; kk<maxK; ++kk)
						{
							if(!((Coeff[ii] as Hashtable)[jj] as Hashtable).ContainsKey(kk))
								((Coeff[ii] as Hashtable)[jj] as Hashtable).Add(kk,"["+ii.ToString()+"]["+jj.ToString()+"]["+kk.ToString()+"]");
						}
					}
				}

				ICollection
					FirstLevel=Coeff.Keys,
					SecondLevel,
					ThirdLevel;

				foreach(int ii in FirstLevel)
				{
					tmpString="";
					HashtableII=Coeff[ii] as Hashtable;
					SecondLevel=HashtableII.Keys;

					foreach(int jj in SecondLevel)
					{
						if(tmpString.Length!=0)
							tmpString+="\n";

						HashtableIII=HashtableII[jj] as Hashtable;
						ThirdLevel=HashtableIII.Keys;

						foreach(int kk in ThirdLevel)
						{
							if(tmpString.Length!=0 && !tmpString.EndsWith("\n"))
								tmpString+=" ";
							lValue="["+ii.ToString()+"]["+jj.ToString()+"]["+kk.ToString()+"]";
							rValue=HashtableIII[kk] as string;
							tmpString+=lValue+(lValue==rValue ? "=" : "!=")+rValue;
						}
					}
					Console.WriteLine(tmpString+"\n");
				}

				for(int ii=0; ii<maxI; ++ii)
				{
					tmpString="";
					for(int jj=0; jj<maxJ; ++jj)
					{
						if(tmpString.Length!=0)
							tmpString+="\n";

						for(int kk=0; kk<maxK; ++kk)
						{
							if(tmpString.Length!=0 && !tmpString.EndsWith("\n"))
								tmpString+=" ";
							
							lValue="["+ii.ToString()+"]["+jj.ToString()+"]["+kk.ToString()+"]";
							rValue=((Coeff[ii] as Hashtable)[jj] as Hashtable)[kk] as string;
							tmpString+=lValue+(lValue==rValue ? "=" : "!=")+rValue;
						}
					}
					Console.WriteLine(tmpString+"\n");
				}
			#endif

			TParam
				a=new TParam(),
				b=null;

			a.Value=1;
			a.StringValue="1";
			a.StringValueAdd="11";
			a.IntValue=1;
			b=new TParam(a);

			mapBP=new Hashtable();
			mapBP.Add("First",new TBaseParam(1));
			mapBP.Add("Second",new TBaseParam(2));
			mapBP.Add("Third",new TBaseParam(3));
			mapBP.Add("Fourth",new TBaseParam(4));
			mapBP.Add("Fifth",new TBaseParam(5));
			mapBP.Add("Sixth",new TBaseParam(6));
			mapBP.Add("Seventh",new TBaseParam(7));
			mapBP.Add("Eighth",new TBaseParam(8));
			mapBP.Add("Ninth",new TBaseParam(9));

			mapBPSorted=new SortedList();
			mapBPSorted.Add("First",new TBaseParam(1));
			mapBPSorted.Add("Second",new TBaseParam(2));
			mapBPSorted.Add("Third",new TBaseParam(3));
			mapBPSorted.Add("Fourth",new TBaseParam(4));
			mapBPSorted.Add("Fifth",new TBaseParam(5));
			mapBPSorted.Add("Sixth",new TBaseParam(6));
			mapBPSorted.Add("Seventh",new TBaseParam(7));
			mapBPSorted.Add("Eighth",new TBaseParam(8));
			mapBPSorted.Add("Ninth",new TBaseParam(9));

			int
				i=0;

			Console.WriteLine("By Enumerator.Key (Hashtable)\n\t-INDEX-\t-KEY-\t-VALUE-");
			myEnumerator=mapBP.GetEnumerator();
			while(myEnumerator.MoveNext())
				Console.WriteLine("\t[{0}]:\t{1}\t{2}",i++,myEnumerator.Key,((TBaseParam)myEnumerator.Value).Value.ToString());
			Console.WriteLine();

			Console.WriteLine("By Enumerator.Entry.Key (Hashtable)\n\t-INDEX-\t-KEY-\t-VALUE-");
			i=0;
			myEnumerator.Reset();
			while(myEnumerator.MoveNext())
				Console.WriteLine("\t[{0}]:\t{1}\t{2}",i++,myEnumerator.Entry.Key,((TBaseParam)myEnumerator.Entry.Value).Value.ToString());
			Console.WriteLine();

			myEnumerator=mapBPSorted.GetEnumerator();
			i=0;
			Console.WriteLine("By Enumerator.Key (SortedList)\n\t-INDEX-\t-KEY-\t-VALUE-");
			while(myEnumerator.MoveNext())
				Console.WriteLine("\t[{0}]:\t{1}\t{2}",i++,myEnumerator.Key,((TBaseParam)myEnumerator.Value).Value.ToString());
			Console.WriteLine();
			
			myEnumerator.Reset();
			i=0;
			Console.WriteLine("By Enumerator.Entry.Key (SortedList)\n\t-INDEX-\t-KEY-\t-VALUE-");
			while(myEnumerator.MoveNext())
				Console.WriteLine("\t[{0}]:\t{1}\t{2}",i++,myEnumerator.Entry.Key,((TBaseParam)myEnumerator.Entry.Value).Value.ToString());
			Console.WriteLine();

			ICollection
				c=mapBP.Keys;

			i=0;
			Console.WriteLine("By Collection (Hashtable)\n\t-INDEX-\t-KEY-\t-VALUE-");
			foreach (string strKey in c)
			{
				Console.WriteLine("\t[{0}]:\t{1}\t{2}",i++,strKey,((TBaseParam)mapBP[strKey]).Value.ToString());
			}
			Console.WriteLine();

			c=mapBPSorted.Keys;
			i=0;
			Console.WriteLine("By Collection (SortedList)\n\t-INDEX-\t-KEY-\t-VALUE-");
			foreach (string strKey in c)
			{
				Console.WriteLine("\t[{0}]:\t{1}\t{2}",i++,strKey,((TBaseParam)mapBPSorted[strKey]).Value.ToString());
			}
			Console.WriteLine();

			c=mapBP.Values;
			i=0;
			Console.WriteLine("(Hashtable)");
			foreach (object objValue in c)
			{
				Console.WriteLine("\t[{0}]:\t{1}",i++,((TBaseParam)objValue).Value.ToString());
			}
			Console.WriteLine();

			c=mapBPSorted.Values;
			i=0;
			Console.WriteLine("(SortedList)");
			foreach (object objValue in c)
			{
				Console.WriteLine("\t[{0}]:\t{1}",i++,((TBaseParam)objValue).Value.ToString());
			}
			Console.WriteLine();

			Console.WriteLine("(SortedList[i])");
			for(i=0; i<mapBPSorted.Count; ++i)
				Console.WriteLine("\t[{0}]:\t{1}",i,((TBaseParam)mapBPSorted.GetByIndex(i)).Value.ToString());
			Console.WriteLine();

			string
				key="First";

			if(mapBP.ContainsKey(key))
				Console.WriteLine(((TBaseParam)mapBP[key]).Value.ToString());
			if(mapBPSorted.ContainsKey(key))
				Console.WriteLine(((TBaseParam)mapBPSorted[key]).Value.ToString());

			key="Third";
			if(mapBP.ContainsKey(key))
				Console.WriteLine(((TBaseParam)mapBP[key]).Value.ToString());
			if(mapBPSorted.ContainsKey(key))
				Console.WriteLine(((TBaseParam)mapBPSorted[key]).Value.ToString());

			key="Second";
			if(mapBP.Contains(key))
				Console.WriteLine(((TBaseParam)mapBP[key]).Value.ToString());
			if(mapBPSorted.Contains(key))
				Console.WriteLine(((TBaseParam)mapBPSorted[key]).Value.ToString());

			TBaseParam
				tmpBaseParam=GetParam("First");

			tmpBaseParam=new TBaseParam(2);
			if(mapBP.ContainsValue(tmpBaseParam))
				Console.WriteLine("Ok!!!");
			if(mapBPSorted.ContainsValue(tmpBaseParam))
				Console.WriteLine("Ok!!!");

			mapBPSorted.Clear();
			mapBPSorted.Add(8,"Eighth");
			mapBPSorted.Add(5,"Fifth");
			mapBPSorted.Add(3,"Third");
			mapBPSorted.Add(1,"First");
			mapBPSorted.Add(2,"Second");
			mapBPSorted.Add(4,"Fourth");
			mapBPSorted.Add(6,"Sixth");
			mapBPSorted.Add(7,"Seventh");
			mapBPSorted.Add(9,"Ninth");

			Console.WriteLine("(SortedList[i])");
			for(i=0; i<mapBPSorted.Count; ++i)
				Console.WriteLine("\t[{0}]:\t{1}\t{2}",i,Convert.ToInt32(mapBPSorted.GetKey(i)),mapBPSorted.GetByIndex(i).ToString());
			Console.WriteLine();

			mapBPSorted=new SortedList();

			try
			{
				mapBPSorted.Add(1L,1L);
				mapBPSorted.Add(500000000000988,500000000000988);
				mapBPSorted.Add(500000000000978,500000000000978);
				mapBPSorted.Add(500000000000998,500000000000998);
				mapBPSorted.Add(500000000000938,500000000000938);
				mapBPSorted.Add(500000000000928,500000000000928);

				IDictionaryEnumerator
					tmpDictionaryEnumerator;

				tmpDictionaryEnumerator=mapBPSorted.GetEnumerator();
				while(tmpDictionaryEnumerator.MoveNext())
				{
					tmpString="Key: "+tmpDictionaryEnumerator.Key.ToString();
					tmpString+=" Value: "+tmpDictionaryEnumerator.Value.ToString();
				}
			}
			catch(Exception eException)
			{
				tmpString=eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace;
			}
		}

		static TBaseParam GetParam(string aParamName)
		{
			if(mapBP.Contains(aParamName))
				return((TBaseParam)mapBP[aParamName]);
			else
				return(null);
		}
	}
}
