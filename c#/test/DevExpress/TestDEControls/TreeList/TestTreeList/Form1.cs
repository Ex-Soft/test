using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace TestTreeList
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();

            treeList.DataSource = GetData();
            treeList.Load += TreeListLoad;
            treeList.CustomDrawNodeCheckBox += TreeListCustomDrawNodeCheckBox;
        }

        static void TreeListCustomDrawNodeCheckBox(object sender, CustomDrawNodeCheckBoxEventArgs e)
        {
            var disabledIds = new[] { 3 };

            if (!(sender is TreeList treeList)
                || !treeList.OptionsView.ShowCheckBoxes
                || !(treeList.GetDataRecordByNode(e.Node) is Data data)
                || !disabledIds.Contains(data.Id))
                return;

            e.ObjectArgs.State = ObjectState.Disabled;
        }

        static void TreeListLoad(object sender, EventArgs e)
        {
            if (!(sender is TreeList treeList))
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

        public static List<Data> GetData()
        {
            return new List<Data>
            {
                new Data(1, null, "1", "/1", true),
                new Data(2, 1, "1.1", "/1/2"),
                new Data(3, 1, "1.2", "/1/3"),
                new Data(4, 1, "1.3", "/1/4"),
                new Data(5, null, "2", "/5"),
                new Data(6, 5, "2.1", "/5/6"),
                new Data(7, 5, "2.2", "/5/7", true),
                new Data(8, 5, "2.3", "/5/8", true),
                new Data(9, 2, "1.1.1", "/1/2/9"),
                new Data(10, 2, "1.1.2", "/1/2/10"),
                new Data(11, 2, "1.1.3",  "/1/2/11"),
                new Data(12, 9, "1.1.1.1", "/1/2/9/12"),
                new Data(13, 9, "1.1.1.2", "/1/2/9/13"),
                new Data(14, 9, "1.1.1.3", "/1/2/9/14"),
                new Data(15, 3, "1.2.1", "/1/3/15"),
                new Data(16, 3, "1.2.2", "/1/3/16"),
                new Data(17, 3, "1.2.3", "/1/3/17"),
                new Data(18, 15, "1.2.1.1", "/1/3/15/18"),
                new Data(19, 15, "1.2.1.2", "/1/3/15/19"),
                new Data(20, 15, "1.2.1.3", "/1/3/15/20"),
                new Data(21, 10, "1.1.2.1", "/1/2/10/21"),
                new Data(22, 10, "1.1.2.2", "/1/2/10/22"),
                new Data(23, 10, "1.1.2.3", "/1/2/10/23"),
                new Data(24, 11, "1.1.3.1", "/1/2/11/24"),
                new Data(25, 11, "1.1.3.2", "/1/2/11/25"),
                new Data(26, 11, "1.1.3.3", "/1/2/11/26"),
                new Data(101, null, "3", "/101", true),
                new Data(102, null, "4", "/102"),
                new Data(103, null, "5", "/103"),
                new Data(104, 101, "3.1", "/101/104", true),
                new Data(105, 101, "3.2", "/101/105", true),
                new Data(106, 101, "3.3", "/101/106", true),
                new Data(107, 104, "3.1.1", "/101/104/107", true),
                new Data(108, 107, "3.1.1.1", "/101/104/107/108", true),
                new Data(201, null, "Root", "/201"),
                new Data(202, 201, "Level# 1", "/201/202"),
                new Data(203, 202, "Level# 2", "/201/202/203"),
                new Data(204, 203, "Level# 3", "/201/202/203/204")
            };
        }
    }

    public class Data
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Val { get; set; }
        public string MaterializedPath { get; set; }
        public bool Selected { get; set; }

        public Data(int id, int? parentId = null, string val = "", string materializedPath = "", bool selected = false)
        {
            Id = id;
            ParentId = parentId;
            Val = val;
            MaterializedPath = materializedPath;
            Selected = selected;
        }
    }
}
