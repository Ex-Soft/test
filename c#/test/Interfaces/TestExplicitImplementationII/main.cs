namespace TestExplicitImplementationII
{
    interface ITableCell
    {
        string XlsxFormatString { get; }
    }

    class Brick : ITableCell
    {
        string ITableCell.XlsxFormatString
        {
            get { return null; }
        }
    }

    class VisualBrick : Brick
    {
        string
            _xlsxFormatString;

        public virtual string XlsxFormatString
        {
            get { return _xlsxFormatString; }
            set { _xlsxFormatString = value; }
        }
    }

    abstract class TextBrickBase : VisualBrick
    {
    }

    class TextBrick : TextBrickBase
    {
        public override string XlsxFormatString
        {
            get { return base.XlsxFormatString + " (from TextBrick)" ; }
            set { base.XlsxFormatString = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var tmpTextBrick = new TextBrick();
            tmpTextBrick.XlsxFormatString = "aaa";
            var tmpITableCell = tmpTextBrick as ITableCell;
            var tmpXlsxFormatString = tmpITableCell.XlsxFormatString;
        }
    }
}
