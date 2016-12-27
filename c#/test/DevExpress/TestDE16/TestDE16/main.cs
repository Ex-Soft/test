using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;

namespace TestDE16
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class VarBinaryFinder : IClientCriteriaVisitor<int>, IQueryCriteriaVisitor<int>
    {
        public int Visit(BetweenOperator theOperator)
        {
            throw new System.NotImplementedException();
        }

        public int Visit(BinaryOperator theOperator)
        {
            throw new System.NotImplementedException();
        }

        public int Visit(UnaryOperator theOperator)
        {
            throw new System.NotImplementedException();
        }

        public int Visit(InOperator theOperator)
        {
            throw new System.NotImplementedException();
        }

        public int Visit(GroupOperator theOperator)
        {
            throw new System.NotImplementedException();
        }

        public int Visit(OperandValue theOperand)
        {
            throw new System.NotImplementedException();
        }

        public int Visit(FunctionOperator theOperator)
        {
            throw new System.NotImplementedException();
        }

        public int Visit(AggregateOperand theOperand)
        {
            throw new System.NotImplementedException();
        }

        public int Visit(OperandProperty theOperand)
        {
            throw new System.NotImplementedException();
        }

        public int Visit(JoinOperand theOperand)
        {
            throw new System.NotImplementedException();
        }

        public int Visit(QueryOperand theOperand)
        {
            throw new System.NotImplementedException();
        }

        public int Visit(QuerySubQueryContainer theOperand)
        {
            throw new System.NotImplementedException();
        }
    }
}
