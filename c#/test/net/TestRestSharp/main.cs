﻿using System;
using System.Collections.Generic;
using RestSharp;

namespace TestRestSharp
{
    [Serializable]
    public class HubDistributorResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public short NodeId { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var client = new RestClient("http://k-prygunkovn.systtech.ru:8001/");
                var request = new RestRequest("/chicago/distributors");
                var response = client.Execute<List<HubDistributorResponse>>(request);
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }
}
