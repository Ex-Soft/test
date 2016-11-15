using System;
using System.Globalization;
using System.IO;
using System.Net;
using WebServiceClient.ReportServer;

namespace WebServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var rs = new ReportExecutionService();

            //rs.Url = "http://air:80/SunOpps_ReportServer_Inst4/ReportExecution2005.asmx";
            //rs.Url = "http://ore-sql-report.cloudapp.net:801/ReportServer/ReportExecution2005.asmx";
            rs.Url = "http://ore-report-test.cloudapp.net:801/ReportServer/ReportExecution2005.asmx";

            bool useDefaultCredentials = false;

            if (!useDefaultCredentials)
            {
                string sDomain = "ore-sql-report";
                string sUserName = "SSRSUser";
                string sPassword = "p4KdzgOu51";
                rs.Credentials = new NetworkCredential(sUserName, sPassword, sDomain);
            }
            else
                rs.Credentials = System.Net.CredentialCache.DefaultCredentials;

            const string sFormat = "PDF";
            string sExtension;
            string sEncoding;
            string sMimeType;
            Warning[] oWarnings;
            string[] sStreamIDs;
            ExecutionHeader oExecutionHeader = new ExecutionHeader();

            //int proposalID = 171871;
            //int proposalID = 171873;
            //int proposalID = 186277;
            int proposalID = 159796;

            //string sReportPath = "/SolarAgreements";
            //string sReportPath = "/SunOpps/Prod/";
            //string sReportPath = "/SunOpps/SE-Default-Dev";
            //string sReportPath = "/SunOpps/SE-Default/OneRoofEnergyProposals";
            string sReportPath = "/SunOpps/SE-Default/SolarAgreements";

            string sReportFilename = "PPA";

            ParameterValue[] oParameters = new ParameterValue[1];
            oParameters[0] = new ParameterValue { Name = "ProposalID", Value = proposalID.ToString(CultureInfo.InvariantCulture) };

            rs.ExecutionHeaderValue = oExecutionHeader;

            byte[] result = null;

            try
            {
                rs.LoadReport(string.Format("{0}/{1}", sReportPath, sReportFilename), null);
                rs.SetExecutionParameters(oParameters, "en-us");

                result = rs.Render(sFormat, null, out sExtension, out sMimeType, out sEncoding, out oWarnings, out sStreamIDs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (result != null)
            {
                string
                    currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

                if (currentDirectory.IndexOf("bin") != -1)
                    currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

                string
                    outputFileName = Path.Combine(currentDirectory, string.Format("{0}_{1}.{2}", sReportFilename, proposalID, sFormat.ToLower()));

                if(File.Exists(outputFileName))
                    File.Delete(outputFileName);

                File.WriteAllBytes(outputFileName, result);
            }
        }
    }
}
