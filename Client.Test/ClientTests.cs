using BizTalk.Monitor.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace Client.Test
{
    [TestClass]
    public class ClientTests
    {
        const string BaseUrl = @"http://localhost/BizTalkManagementService";
         CancellationToken cancellationToken;
        HttpClient httpClient;
        public ClientTests()
        {
            new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
            httpClient = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true }) { BaseAddress = new System.Uri(BaseUrl) };
            
        }

        [TestInitialize]
        public void TestInit()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            cancellationToken = tokenSource.Token;
        }

        [TestMethod]
        [TestCategory("Applications")]
        public async System.Threading.Tasks.Task GetApplicationTestAsync()
        {

            ApplicationsClient client = new ApplicationsClient(httpClient);
           var apps =  await client.GetAsync(cancellationToken);

            Assert.IsTrue(apps.StatusCode == 200);
            Assert.IsTrue(apps.Result.Count > 0);
        }
    }
}
