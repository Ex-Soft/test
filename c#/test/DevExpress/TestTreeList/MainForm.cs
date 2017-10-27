using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.ViewInfo;
using DevExpress.XtraTreeList.Nodes.Operations;
using DevExpress.XtraTreeList.Nodes;
using TestDB;

namespace TestTreeList
{
    public partial class MainForm : XtraForm
    {
        public MainForm()
        {
            InitializeComponent();

            //treeList.OptionsBehavior.Editable = false;

            treeList.OptionsBehavior.EnableFiltering = true;
            //treeList.OptionsFilter.ShowAllValuesInFilterPopup = false;
            //treeList.OptionsFilter.FilterMode = FilterMode.Smart;

            colMaterializedPath.OptionsFilter.ShowBlanksFilterItems = DefaultBoolean.True;

            treeList.OptionsFind.AllowFindPanel = true;
            treeList.OptionsFind.FindMode = FindMode.Always;

            treeList.Load += TreeListLoad;
        }

        private void TreeListLoad(object sender, EventArgs e)
        {
            TreeList treeList;

            if ((treeList = sender as TreeList) == null)
                return;

            new List<int> { 1, 2, 9, 15, 10, /*11,*/ 3, 5, /*101,*/ /*104,*/ /*107*/ }.ForEach(id => {
                TreeListNode node;

                if ((node = treeList.FindNodeByKeyID(id)) != null)
                    node.Expanded = true;
            });

            TreeListNode node4focus;
            if ((node4focus = treeList.FindNodeByKeyID(20)) != null)
                treeList.FocusedNode = node4focus;
        }

        private void TreeListFocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("TreeListFocusedNodeChanged");

            TableWithHierarchy
                oldRecord = treeList.GetDataRecordByNode(e.OldNode) as TableWithHierarchy,
                record = treeList.GetDataRecordByNode(e.Node) as TableWithHierarchy;

            System.Diagnostics.Debug.WriteLine($"oldId = {oldRecord?.Id.ToString() ?? "NULL"} -> Id = {record?.Id.ToString() ?? "NULL"}");
        }

        private void TreeListCustomNodeCellEdit(object sender, DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("TreeListCustomNodeCellEdit");
        }

        private void BtnGetSelectedClick(object sender, System.EventArgs e)
        {
            foreach (TreeListNode node in treeList.Selection)
            {
                TableWithHierarchy record = treeList.GetDataRecordByNode(node) as TableWithHierarchy;
                Debug.WriteLine($"Id = {record?.Id.ToString() ?? "NULL"}");

                if (treeList.Selection.Contains(node))
                    Debug.WriteLine($"treeList.Selection.Contains({node})");

                if (treeList.Selection.Contains(node, new TreeListNodeEqualityComparer()))
                    Debug.WriteLine($"treeList.Selection.Contains({node})");
            }
        }
        
        #region CheckBox in column header https://www.devexpress.com/Support/Center/Example/Details/E1327

        RepositoryItemCheckEdit checkEdit;

        private void MainFormLoad(object sender, System.EventArgs e)
        {
            checkEdit = (RepositoryItemCheckEdit)treeList.RepositoryItems.Add("CheckEdit");
        }

        protected void DrawCheckBox(Graphics g, RepositoryItemCheckEdit edit, Rectangle r, bool Checked)
        {
            DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
            DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
            DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;
            info = edit.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;
            painter = edit.CreatePainter() as DevExpress.XtraEditors.Drawing.CheckEditPainter;
            info.EditValue = Checked;
            info.Bounds = r;
            info.CalcViewInfo(g);
            args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
            painter.Draw(args);
            args.Cache.Dispose();
        }

        private void TreeListCustomDrawColumnHeader(object sender, DevExpress.XtraTreeList.CustomDrawColumnHeaderEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("TreeListCustomDrawColumnHeader");

            if (e.Column != null && e.Column.FieldName == "Selected" /*e.Column.VisibleIndex == 0*/)
            {
                Rectangle checkRect = new Rectangle(e.Bounds.Left + 3, e.Bounds.Top + 3, 12, 12);
                ColumnInfo info = (ColumnInfo)e.ObjectArgs;
                if (info.CaptionRect.Left < checkRect.Right + 5 /* 30 */)
                    info.CaptionRect = new Rectangle(new Point(info.CaptionRect.Left + checkRect.Width + 5 /* + 15 */, info.CaptionRect.Top), info.CaptionRect.Size);
                e.Painter.DrawObject(info);

                DrawCheckBox(e.Graphics, checkEdit, checkRect, IsAllSelected(sender as TreeList));
                e.Handled = true;
            }
        }

        private bool IsAllSelected(TreeList tree)
        {
            /* return tree.Selection.Count > 0 && tree.Selection.Count == tree.AllNodesCount; */

            var result = /*return*/ tree.Nodes/*.Where(node => node.Visible)*/.Aggregate(true, (selected, next) =>
            {
                TableWithHierarchy record = tree.GetDataRecordByNode(next) as TableWithHierarchy;
                System.Diagnostics.Debug.WriteLine(string.Format("Id = {0} node.Focused = {1}", record != null ? record.Id.ToString() : "null", next.Focused));
                return selected && record != null && record.Selected;
            });

            return result;
        }

        private void TreeListMouseUp(object sender, MouseEventArgs e)
        {
            TreeList tree = sender as TreeList;
            Point pt = new Point(e.X, e.Y);
            TreeListHitInfo hit = tree.CalcHitInfo(pt);
            if (hit.Column != null)
            {
                ColumnInfo info = tree.ViewInfo.ColumnsInfo[hit.Column];
                Rectangle checkRect = new Rectangle(info.Bounds.Left + 3, info.Bounds.Top + 3, 12, 12);
                if (checkRect.Contains(pt))
                {
                    EmbeddedCheckBoxChecked(tree);
                    throw new DevExpress.Utils.HideException();
                }
            }
        }

        private void EmbeddedCheckBoxChecked(TreeList tree)
        {
            //if (IsAllSelected(tree))
                SelectAll(tree, !IsAllSelected(tree)); /*tree.Selection.Clear();*/
            //else
            //    SelectAll(tree);
        }

        /*class SelectNodeOperation : TreeListOperation
        {
            public override void Execute(TreeListNode node)
            {
                // node.Selected = true;
            }
        }*/

        class SelectNodeOperation : TreeListOperation
        {
            private readonly bool _value;

            public SelectNodeOperation(bool value)
            {
                _value = value;
            }

            public override void Execute(TreeListNode node)
            {
                TableWithHierarchy record;
                if ((record = node.TreeList.GetDataRecordByNode(node) as TableWithHierarchy) != null && record.Selected != _value)
                    record.Selected = _value;
            }
        }

        private void SelectAll(TreeList tree, bool value)
        {
            tree.BeginUpdate();
            tree.NodesIterator.DoOperation(new SelectNodeOperation(value));
            tree.EndUpdate();
        }

        private void TreeListSelectionChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("TreeListSelectionChanged");

            treeList.InvalidateColumnPanel();
        }

        #endregion
    }

    public class TreeListNodeEqualityComparer : IEqualityComparer<TreeListNode>
    {
        public bool Equals(TreeListNode x, TreeListNode y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.Id == y.Id;
        }

        public int GetHashCode(TreeListNode obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
