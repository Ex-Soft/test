using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace EvalServiceLibrary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EvalService : IEvalService
    {
        private List<Eval> evals = new List<Eval>();

        #region IEvalService Members

        public void SubmitEval(Eval eval)
        {
            eval.Id = Guid.NewGuid().ToString();
            evals.Add(eval);
        }

        public List<Eval> GetEvals()
        {
            return evals;
        }

        public void RemoveEval(string id)
        {
            evals.Remove(evals.Find(e => e.Id.Equals(id)));
        }

        #endregion
    }
}
