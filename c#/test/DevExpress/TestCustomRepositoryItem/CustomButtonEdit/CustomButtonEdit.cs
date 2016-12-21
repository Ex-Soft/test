using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Accessibility;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;

namespace TestCustomRepositoryItem.CustomButtonEdit
{
    [UserRepositoryItem("RegisterCustomButtonEdit")]
    public class RepositoryItemCustomButtonEdit : RepositoryItemButtonEdit
    {
        public const string EditName = "CustomButtonEdit";

        static RepositoryItemCustomButtonEdit()
        {
            RegisterCustomButtonEdit();
        }

        public RepositoryItemCustomButtonEdit()
        {}

        public override string EditorTypeName
        {
            get { return EditName; }
        }

        public static void RegisterCustomButtonEdit()
        {
            Image img = null;
            try
            {
                img = ResourceImageHelper.CreateBitmapFromResources("TestCustomRepositoryItem.Resources.image_icon.png", Assembly.GetExecutingAssembly());
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditName,
              typeof(CustomButtonEdit), typeof(RepositoryItemCustomButtonEdit),
              typeof(DevExpress.XtraEditors.ViewInfo.ButtonEditViewInfo), new ButtonEditPainter(), true, img, typeof(ButtonEditAccessible)));
        }

        public override void CreateDefaultButton()
        {
            base.CreateDefaultButton();

            Buttons[0].Shortcut = new KeyShortcut(Keys.F4);

            var deleteButton = new EditorButton(ButtonPredefines.Delete)
            {
            };

            Buttons.Add(deleteButton);
        }

        public override void Assign(RepositoryItem item)
        {
            var source = item as RepositoryItemCustomButtonEdit;
            BeginUpdate();
            try
            {
                base.Assign(item);

                if (source == null)
                    return;
            }
            finally
            {
                EndUpdate();
            }
        }

        public override string GetDisplayText(object editValue)
        {
            var listOfString = editValue as List<string>;
            return listOfString != null ? $"({listOfString.Count})" : base.GetDisplayText(editValue);
        }
    }

    public class CustomButtonEdit : ButtonEdit
    {
        static CustomButtonEdit()
        {
            RepositoryItemCustomButtonEdit.RegisterCustomButtonEdit();
        }

        public CustomButtonEdit()
        {
        }

        public override string EditorTypeName
        {
            get { return RepositoryItemCustomButtonEdit.EditName; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomButtonEdit Properties
        {
            get { return base.Properties as RepositoryItemCustomButtonEdit; }
        }


        protected override void OnClickButton(EditorButtonObjectInfoArgs buttonInfo)
        {
            /*if (ReferenceEquals(Properties.SourceSession, null))
                return;

            switch (buttonInfo.Button.Kind)
            {
                case ButtonPredefines.Ellipsis:
                {
                    Strategy.ExecuteCommand(StuCommandNames.OpenFilePacket, this);
                    break;
                }
                case ButtonPredefines.Delete:
                {
                    Strategy.ExecuteCommand(StuCommandNames.DeleteFilePacket, this);
                    break;
                }
            }*/

            base.OnClickButton(buttonInfo);
        }
    }
}
