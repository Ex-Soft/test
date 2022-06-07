using RulesEngine.Extensions;
using RulesEngine.Models;

namespace TestRulesEngine
{
    public class Order
    {
        public int Id { get; set; }
        public List<ReleaseGroup>? ReleaseGroups { get; set; }
    }

    public class ReleaseGroup
    {
        public DateTime? ShippedDate { get; set; }
        public List<Item>? Items { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
    }

    public class TestOrder
    {
        public void Run()
        {
            var orders = new List<Order>
            {
                new Order { Id = 1, ReleaseGroups = new List<ReleaseGroup> { new ReleaseGroup { ShippedDate = DateTime.Now.AddDays(-2), Items = new List<Item> { new Item() } } } },
                new Order { Id = 2, ReleaseGroups = new List<ReleaseGroup> { new ReleaseGroup { ShippedDate = DateTime.Now.AddDays(-1), Items = new List<Item> { new Item() } } } },
                new Order { Id = 3, ReleaseGroups = new List<ReleaseGroup> { new ReleaseGroup { ShippedDate = DateTime.Now, Items = new List<Item> { new Item() } } } },
            };

            Console.WriteLine($"Running {nameof(TestOrder)}....");
            List<Workflow> workflowsId = new List<Workflow>();
            Workflow workflowId = new Workflow();
            workflowId.WorkflowName = "Test Workflow Id";

            List<Rule> rulesId = new List<Rule>();

            Rule ruleId = new Rule();
            ruleId.RuleName = "Test Rule Id";
            ruleId.SuccessEvent = "Id < 3";
            ruleId.ErrorMessage = "Id >= 3";
            ruleId.Expression = "input1.Id < 3";
            ruleId.RuleExpressionType = RuleExpressionType.LambdaExpression;
            rulesId.Add(ruleId);

            workflowId.Rules = rulesId;

            workflowsId.Add(workflowId);

            var breId = new RulesEngine.RulesEngine(workflowsId.ToArray(), null);

            List<Workflow> workflowsShippedDate = new List<Workflow>();
            Workflow workflowShippedDate = new Workflow();
            workflowShippedDate.WorkflowName = "Test Workflow ShippedDate";

            List<Rule> rulesShippedDate = new List<Rule>();

            Rule ruleShippedDate = new Rule();
            ruleShippedDate.RuleName = "Test Rule ShippedDate";
            ruleShippedDate.SuccessEvent = "Now - ShippedDate < 1";
            ruleShippedDate.ErrorMessage = "Now - ShippedDate >= 1";
            ruleShippedDate.Expression = "(DateTime.Now - input1.ShippedDate).Value.Days < 1";
            ruleShippedDate.RuleExpressionType = RuleExpressionType.LambdaExpression;
            rulesShippedDate.Add(ruleShippedDate);

            workflowShippedDate.Rules = rulesShippedDate;

            workflowsShippedDate.Add(workflowShippedDate);

            var breShippedDate = new RulesEngine.RulesEngine(workflowsShippedDate.ToArray(), null);

            for (var i = 0; i < orders.Count; ++i)
            {
                var resultIdList = breId.ExecuteAllRulesAsync(workflowId.WorkflowName, orders[i]).Result;

                resultIdList.OnSuccess((eventName) =>
                {
                    Console.WriteLine($"{workflowId.WorkflowName} evaluation resulted in success - {eventName}");
                }).OnFail(() =>
                {
                    Console.WriteLine($"{workflowId.WorkflowName} evaluation resulted in failure");
                });

                if (orders[i].ReleaseGroups == null)
                {
                    continue;
                }

                for (var j = 0; j < orders[i].ReleaseGroups.Count; ++j)
                {
                    var tmp = (DateTime.Now - orders[i].ReleaseGroups[j].ShippedDate).Value.Days < 1;
                    var resultShippedDateList = breShippedDate.ExecuteAllRulesAsync(workflowShippedDate.WorkflowName, orders[i].ReleaseGroups[j]).Result;

                    resultShippedDateList.OnSuccess((eventName) =>
                    {
                        Console.WriteLine($"{workflowShippedDate.WorkflowName} evaluation resulted in success - {eventName}");
                    }).OnFail(() =>
                    {
                        Console.WriteLine($"{workflowShippedDate.WorkflowName} evaluation resulted in failure");
                    });
                }
            }
        }
    }
}
