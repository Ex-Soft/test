﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace TestASPnWCF.TestASPnWCFService
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://TestASPnWCFService", ConfigurationName="TestASPnWCF.TestASPnWCFService.ITestService")]
    public interface ITestService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TestASPnWCFService/ITestService/DoWork", ReplyAction="http://TestASPnWCFService/ITestService/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TestASPnWCFService/ITestService/DoWork", ReplyAction="http://TestASPnWCFService/ITestService/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITestServiceChannel : TestASPnWCF.TestASPnWCFService.ITestService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TestServiceClient : System.ServiceModel.ClientBase<TestASPnWCF.TestASPnWCFService.ITestService>, TestASPnWCF.TestASPnWCFService.ITestService
    {
        
        public TestServiceClient()
        {
        }
        
        public TestServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public TestServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public TestServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public TestServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public void DoWork()
        {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync()
        {
            return base.Channel.DoWorkAsync();
        }
    }
}
