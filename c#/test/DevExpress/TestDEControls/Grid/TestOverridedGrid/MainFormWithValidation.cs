using DevExpress.Xpo;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using TestDB;

namespace TestOverridedGrid
{
    public partial class MainForm
    {
        private void InitializeComponentWithValidation()
        {
            gridControlWithValidation.DataSource = CreateDataSourceWithValidation();

            customGridViewWithValidation.PopulateColumns();

            GridColumn columnWithImage;
            if ((columnWithImage = customGridViewWithValidation.Columns.ColumnByFieldName(nameof(TestTable4Types.Image))) != null)
            {
                var riPictureEdit = new RepositoryItemPictureEdit();
                riPictureEdit.SizeMode = PictureSizeMode.Zoom;

                columnWithImage.ColumnEdit = riPictureEdit;
                columnWithImage.OptionsColumn.AllowEdit = false;
            }
        }

        private static object CreateDataSourceWithValidation()
        {
            return new XPCollection<TestTable4Types>(new Session());
        }
    }
}
