using System;
using System.Data;

namespace AbstractVsInterface
{
	#region DataSet
	#region DataSet1
	public class DataSet1:DataSet
	{
		public DataSet1()
		{
			string
				TableName;

			TableName="DataSet1_Table1";
			Tables.Add(TableName);
			Tables[TableName].Columns.Add("Id",typeof(int));
			Tables[TableName].Columns.Add("ActualDate",typeof(DateTime));
		}
		//---------------------------------------------------------------------------
	}
	#endregion

	#region DataSet2
	public class DataSet2:DataSet
	{
		public DataSet2()
		{
			string
				TableName;

			TableName="DataSet2_Table1";
			Tables.Add(TableName);
			Tables[TableName].Columns.Add("Id",typeof(int));
			Tables[TableName].Columns.Add("ActualDate",typeof(DateTime));

			TableName="DataSet2_Table2";
			Tables.Add(TableName);
			Tables[TableName].Columns.Add("Id",typeof(int));
			Tables[TableName].Columns.Add("ActualDate",typeof(DateTime));
		}
		//---------------------------------------------------------------------------
	}
	#endregion
	#endregion

	#region interface ILoadNSI
	public interface ILoadNSI
	{
		bool LoadNSI(int aId, DateTime aDate);
	}
	#endregion

	#region class Container1
	public class Container1:ILoadNSI
	{
		DataSet1
			DS;

		#region ILoadNSI Members
		public bool LoadNSI(int aId, DateTime aDate)
		{
			bool
				IsLoad=false;
			
			DataTable
				tmpDataTable;

			DataRow
				tmpDataRow;

			tmpDataTable=DS.Tables["DataSet1_Table1"];
			tmpDataRow=tmpDataTable.NewRow();
			tmpDataRow["Id"]=aId;
			tmpDataRow["ActualDate"]=aDate;
			tmpDataTable.Rows.Add(tmpDataRow);
			IsLoad = tmpDataRow.RowState==DataRowState.Added;

			return(IsLoad);
		}
		#endregion

		public Container1()
		{
			DS=new DataSet1();
		}
		//---------------------------------------------------------------------------

		public Container1(DataSet1 aDS)
		{
			DS=aDS;
		}
		//---------------------------------------------------------------------------

		public Container1(Container1 obj):this(obj.DS)
		{}
		//---------------------------------------------------------------------------
	}
	#endregion

	#region class Container2
	public class Container2:ILoadNSI
	{
		DataSet2
			DS;

		#region ILoadNSI Members
		public bool LoadNSI(int aId, DateTime aDate)
		{
			bool
				IsLoad=false;
			
			DataTable
				tmpDataTable;

			DataRow
				tmpDataRow;

			tmpDataTable=DS.Tables["DataSet2_Table1"];
			tmpDataRow=tmpDataTable.NewRow();
			tmpDataRow["Id"]=aId;
			tmpDataRow["ActualDate"]=aDate;
			tmpDataTable.Rows.Add(tmpDataRow);
			if(IsLoad = tmpDataRow.RowState==DataRowState.Added)
			{
				tmpDataTable=DS.Tables["DataSet2_Table2"];
				tmpDataRow=tmpDataTable.NewRow();
				tmpDataRow["Id"]=aId;
				tmpDataRow["ActualDate"]=aDate;
				tmpDataTable.Rows.Add(tmpDataRow);
			}

			IsLoad &= tmpDataRow.RowState==DataRowState.Added;

			return(IsLoad);
		}
		#endregion

		public Container2()
		{
			DS=new DataSet2();
		}
		//---------------------------------------------------------------------------

		public Container2(DataSet2 aDS)
		{
			DS=aDS;
		}
		//---------------------------------------------------------------------------

		public Container2(Container2 obj):this(obj.DS)
		{}
		//---------------------------------------------------------------------------
	}
	#endregion

	#region abstarct class ContainerAbstract
	public abstract class ContainerAbstract
	{
		protected DataSet
			DS;

		public abstract bool LoadNSI(int aId, DateTime aDate);
	}
	//---------------------------------------------------------------------------
	#endregion

	#region class ContainerAbstract1
	public class ContainerAbstract1:ContainerAbstract
	{
		public ContainerAbstract1()
		{
			DS=new DataSet1();
		}
		//---------------------------------------------------------------------------

		public ContainerAbstract1(DataSet1 aDS)
		{
			DS=aDS;
		}
		//---------------------------------------------------------------------------

		public ContainerAbstract1(ContainerAbstract1 obj):this((DataSet1)obj.DS)
		{}
		//---------------------------------------------------------------------------

		public override bool LoadNSI(int aId, DateTime aDate)
		{
			bool
				IsLoad=false;
			
			DataTable
				tmpDataTable;

			DataRow
				tmpDataRow;

			tmpDataTable=DS.Tables["DataSet1_Table1"];
			tmpDataRow=tmpDataTable.NewRow();
			tmpDataRow["Id"]=aId;
			tmpDataRow["ActualDate"]=aDate;
			tmpDataTable.Rows.Add(tmpDataRow);
			IsLoad = tmpDataRow.RowState==DataRowState.Added;

			return(IsLoad);
		}
		//---------------------------------------------------------------------------
	}
	#endregion

	#region class ContainerAbstract2
	public class ContainerAbstract2:ContainerAbstract
	{
		public ContainerAbstract2()
		{
			DS=new DataSet2();
		}
		//---------------------------------------------------------------------------

		public ContainerAbstract2(DataSet2 aDS)
		{
			DS=aDS;
		}
		//---------------------------------------------------------------------------

		public ContainerAbstract2(ContainerAbstract2 obj):this((DataSet2)obj.DS)
		{}
		//---------------------------------------------------------------------------

		public override bool LoadNSI(int aId, DateTime aDate)
		{
			bool
				IsLoad=false;
			
			DataTable
				tmpDataTable;

			DataRow
				tmpDataRow;

			tmpDataTable=DS.Tables["DataSet2_Table1"];
			tmpDataRow=tmpDataTable.NewRow();
			tmpDataRow["Id"]=aId;
			tmpDataRow["ActualDate"]=aDate;
			tmpDataTable.Rows.Add(tmpDataRow);
			if(IsLoad = tmpDataRow.RowState==DataRowState.Added)
			{
				tmpDataTable=DS.Tables["DataSet2_Table2"];
				tmpDataRow=tmpDataTable.NewRow();
				tmpDataRow["Id"]=aId;
				tmpDataRow["ActualDate"]=aDate;
				tmpDataTable.Rows.Add(tmpDataRow);
			}

			IsLoad &= tmpDataRow.RowState==DataRowState.Added;

			return(IsLoad);
		}
		//---------------------------------------------------------------------------
	}
	#endregion

	#region abstract class ContainerAbstractWODS
	public abstract class ContainerAbstractWODS
	{
		public abstract bool LoadNSI(int aId, DateTime aDate);
	}
	#endregion

	#region class ContainerAbstractWODS1
	public class ContainerAbstractWODS1:ContainerAbstractWODS
	{
		DataSet1
			DS;

		public ContainerAbstractWODS1()
		{
			DS=new DataSet1();
		}
		//---------------------------------------------------------------------------

		public ContainerAbstractWODS1(DataSet1 aDS)
		{
			DS=aDS;
		}
		//---------------------------------------------------------------------------

		public ContainerAbstractWODS1(ContainerAbstractWODS1 obj):this(obj.DS)
		{}
		//---------------------------------------------------------------------------

		public override bool LoadNSI(int aId, DateTime aDate)
		{
			bool
				IsLoad=false;
			
			DataTable
				tmpDataTable;

			DataRow
				tmpDataRow;

			tmpDataTable=DS.Tables["DataSet1_Table1"];
			tmpDataRow=tmpDataTable.NewRow();
			tmpDataRow["Id"]=aId;
			tmpDataRow["ActualDate"]=aDate;
			tmpDataTable.Rows.Add(tmpDataRow);
			IsLoad = tmpDataRow.RowState==DataRowState.Added;

			return(IsLoad);
		}
		//---------------------------------------------------------------------------
	}
	#endregion

	#region class ContainerAbstractWODS2
	public class ContainerAbstractWODS2:ContainerAbstractWODS
	{
		DataSet2
			DS;

		public ContainerAbstractWODS2()
		{
			DS=new DataSet2();
		}
		//---------------------------------------------------------------------------

		public ContainerAbstractWODS2(DataSet2 aDS)
		{
			DS=aDS;
		}
		//---------------------------------------------------------------------------

		public ContainerAbstractWODS2(ContainerAbstractWODS2 obj):this(obj.DS)
		{}
		//---------------------------------------------------------------------------

		public override bool LoadNSI(int aId, DateTime aDate)
		{
			bool
				IsLoad=false;
			
			DataTable
				tmpDataTable;

			DataRow
				tmpDataRow;

			tmpDataTable=DS.Tables["DataSet2_Table1"];
			tmpDataRow=tmpDataTable.NewRow();
			tmpDataRow["Id"]=aId;
			tmpDataRow["ActualDate"]=aDate;
			tmpDataTable.Rows.Add(tmpDataRow);
			if(IsLoad = tmpDataRow.RowState==DataRowState.Added)
			{
				tmpDataTable=DS.Tables["DataSet2_Table2"];
				tmpDataRow=tmpDataTable.NewRow();
				tmpDataRow["Id"]=aId;
				tmpDataRow["ActualDate"]=aDate;
				tmpDataTable.Rows.Add(tmpDataRow);
			}

			IsLoad &= tmpDataRow.RowState==DataRowState.Added;

			return(IsLoad);
		}
		//---------------------------------------------------------------------------
	}
	#endregion

	class AbstractVsInterface
	{
		[STAThread]
		static void Main(string[] args)
		{
			Container1
				c1=new Container1();

			Container2
				c2=new Container2();

			ContainerAbstract1
				ca1=new ContainerAbstract1();

			ContainerAbstract2
				ca2=new ContainerAbstract2();

			ContainerAbstractWODS1
				cawods1=new ContainerAbstractWODS1();

			ContainerAbstractWODS2
				cawods2=new ContainerAbstractWODS2();

			LoadNSI(c1,1,DateTime.Now);
			LoadNSI(c2,2,DateTime.Now);
			LoadNSI(ca1,1,DateTime.Now);
			LoadNSI(ca2,2,DateTime.Now);
			LoadNSI(cawods1,1,DateTime.Now);
			LoadNSI(cawods2,2,DateTime.Now);
		}
		//---------------------------------------------------------------------------

		static bool LoadNSI(ILoadNSI aContainer, int aId, DateTime aDate)
		{
			return(aContainer.LoadNSI(aId,aDate));
		}
		//---------------------------------------------------------------------------

		static bool LoadNSI(ContainerAbstract aContainer, int aId, DateTime aDate)
		{
			return(aContainer.LoadNSI(aId,aDate));
		}
		//---------------------------------------------------------------------------

		static bool LoadNSI(ContainerAbstractWODS aContainer, int aId, DateTime aDate)
		{
			return(aContainer.LoadNSI(aId,aDate));
		}
		//---------------------------------------------------------------------------
	}
	//---------------------------------------------------------------------------
}
