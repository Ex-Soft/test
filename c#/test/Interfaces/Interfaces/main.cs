using System;
using System.Data;

namespace Interfaces
{
	public interface ICopyableContract
	{
		void CopyContract(long contractInitId);
	}
	//---------------------------------------------------------------------------

	public class Docum:ICopyableContract
	{
		public DataSet
			DS;

		public Docum():this((DataSet)null)
		{}
		//---------------------------------------------------------------------------

		public Docum(DataSet ds)
		{
			DS = ds!=null ? ds : new DataSet();
		}
		//---------------------------------------------------------------------------

		public Docum(Docum aObj):this(aObj.DS)
		{}
		//---------------------------------------------------------------------------

		public void CopyContract(long contractInitId)
		{
			string
				TableName="TestTable";

			if(!DS.Tables.Contains(TableName))
				return;

			DataRow
				RowSrc;

			if((RowSrc=DS.Tables[TableName].Rows.Find(contractInitId))!=null)
			{
				DataRow
					RowDest;

				RowDest=DS.Tables[TableName].NewRow();
				foreach(DataColumn col in DS.Tables[TableName].Columns)
				{
					if(col.AutoIncrement)
						continue;
					RowDest[col.ColumnName]=RowSrc[col.ColumnName];
				}
				DS.Tables[TableName].Rows.Add(RowDest);
			}
		}
		//---------------------------------------------------------------------------

		public virtual void TablePrint(string TableName)
		{
			if(!DS.Tables.Contains(TableName))
				return;

			TablePrint(DS.Tables[TableName]);
		}
		//---------------------------------------------------------------------------

		public void TablePrint(DataTable aTable)
		{
			string
				tmpString;

			foreach(DataRow row in aTable.Rows)
			{
				tmpString=string.Empty;
				foreach(DataColumn col in aTable.Columns)
				{
					if(tmpString!=string.Empty)
						tmpString+="\t";
					tmpString+=row[col.ColumnName].ToString();
				}
				if(tmpString!=string.Empty)
					Console.WriteLine(tmpString);
			}
		}
		//---------------------------------------------------------------------------
	}
	//---------------------------------------------------------------------------

	public class Property:Docum,ICopyableContract
	{
		public DataSet
			PropertyDS;

		public Property():this((DataSet)null,(DataSet)null)
		{}
		//---------------------------------------------------------------------------

		public Property(DataSet aDocumDS):this((DataSet)null,aDocumDS)
		{}
		//---------------------------------------------------------------------------

		public Property(Property aObj):this(aObj.PropertyDS,aObj.DS)
		{}
		//---------------------------------------------------------------------------

		public Property(DataSet aPropertyDS, DataSet aDocumDS):base(aDocumDS)
		{
			PropertyDS = aPropertyDS!=null ? aPropertyDS : new DataSet();
		}
		//---------------------------------------------------------------------------

		public override void TablePrint(string TableName)
		{
			if(!PropertyDS.Tables.Contains(TableName))
				return;

			TablePrint(PropertyDS.Tables[TableName]);
		}
		//---------------------------------------------------------------------------

		new public void CopyContract(long contractInitId)
		{
			base.CopyContract(contractInitId);

			string
				TableName="PropertyTestTable";

			if(!PropertyDS.Tables.Contains(TableName))
				return;

			DataRow
				RowSrc;

			if((RowSrc=PropertyDS.Tables[TableName].Rows.Find(contractInitId))!=null)
			{
				DataRow
					RowDest;

				RowDest=PropertyDS.Tables[TableName].NewRow();
				foreach(DataColumn col in PropertyDS.Tables[TableName].Columns)
				{
					if(col.AutoIncrement)
						continue;
					RowDest[col.ColumnName]=RowSrc[col.ColumnName];
				}
				PropertyDS.Tables[TableName].Rows.Add(RowDest);
			}
		}
	}
	//---------------------------------------------------------------------------

	class InterfacesClass
	{
		[STAThread]
		static void Main()
		{
			Docum
				d=new Docum();

			string
				TableName="TestTable";

			d.DS.Tables.Add(TableName);

			DataColumn
				col;

			col=d.DS.Tables[TableName].Columns.Add("Id",typeof(long));
			col.AllowDBNull=false;
			col.Unique=true;
			col.AutoIncrement=true;
			col.AutoIncrementSeed=-1;
			col.AutoIncrementStep=-1;
			d.DS.Tables[TableName].Columns.Add("Name",typeof(string));
			d.DS.Tables[TableName].PrimaryKey=new DataColumn[]{d.DS.Tables[TableName].Columns["Id"]};

			DataRow
				row;

			row=d.DS.Tables[TableName].NewRow();
			row["Name"]="Ленин";
			d.DS.Tables[TableName].Rows.Add(row);

			row=d.DS.Tables[TableName].NewRow();
			row["Name"]="Сталин";
			d.DS.Tables[TableName].Rows.Add(row);

			row=d.DS.Tables[TableName].NewRow();
			row["Name"]="Хрущев";
			d.DS.Tables[TableName].Rows.Add(row);

			int
				CountFillChar=20;

			Console.WriteLine(TableName+" (b4)");
			Console.WriteLine(new string('-',CountFillChar));
			d.TablePrint(TableName);
			Console.WriteLine(new string('-',CountFillChar));
			Console.WriteLine();

			ICopyableContract
				ptr;

			if((ptr=d as ICopyableContract)!=null)
				ptr.CopyContract(-1);

			Console.WriteLine(TableName+" (after)");
			Console.WriteLine(new string('-',CountFillChar));
			d.TablePrint(TableName);
			Console.WriteLine(new string('-',CountFillChar));
			Console.WriteLine();

			Property
				p=new Property();

			TableName="PropertyTestTable";
			p.PropertyDS.Tables.Add(TableName);
			col=p.PropertyDS.Tables[TableName].Columns.Add("Id",typeof(long));
			col.AllowDBNull=false;
			col.Unique=true;
			col.AutoIncrement=true;
			col.AutoIncrementSeed=-1;
			col.AutoIncrementStep=-1;
			p.PropertyDS.Tables[TableName].Columns.Add("Name",typeof(string));
			p.PropertyDS.Tables[TableName].PrimaryKey=new DataColumn[]{p.PropertyDS.Tables[TableName].Columns["Id"]};

			row=p.PropertyDS.Tables[TableName].NewRow();
			row["Name"]="Иванов";
			p.PropertyDS.Tables[TableName].Rows.Add(row);

			row=p.PropertyDS.Tables[TableName].NewRow();
			row["Name"]="Петров";
			p.PropertyDS.Tables[TableName].Rows.Add(row);

			row=p.PropertyDS.Tables[TableName].NewRow();
			row["Name"]="Сидоров";
			p.PropertyDS.Tables[TableName].Rows.Add(row);

			Console.WriteLine(TableName+" (b4)");
			Console.WriteLine(new string('-',CountFillChar));
			p.TablePrint(TableName);
			Console.WriteLine(new string('-',CountFillChar));
			Console.WriteLine();

			if((ptr=p as ICopyableContract)!=null)
				ptr.CopyContract(-1);

			Console.WriteLine(TableName+" (after)");
			Console.WriteLine(new string('-',CountFillChar));
			p.TablePrint(TableName);
			Console.WriteLine(new string('-',CountFillChar));
			Console.WriteLine();
		}
		//---------------------------------------------------------------------------
	}
	//---------------------------------------------------------------------------
}