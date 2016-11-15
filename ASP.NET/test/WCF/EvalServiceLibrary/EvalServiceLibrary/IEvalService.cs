using System.Collections.Generic;
using System.ServiceModel;

namespace EvalServiceLibrary
{
    [ServiceContract]
    public interface IEvalService
    {
        [OperationContract]
        void SubmitEval(Eval eval);

        [OperationContract]
        List<Eval> GetEvals();

        [OperationContract]
        void RemoveEval(string id);
    }
}
