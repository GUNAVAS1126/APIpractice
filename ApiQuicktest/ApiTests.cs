using NUnit.Framework;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiQuickTests
{
    public class ApiTests
    {
        private HttpClient client;

        [OneTimeSetUp]
        public void Setup()
        {
            client = new HttpClient();
            client.BaseAddress = new System.Uri("https://jsonplaceholder.typicode.com/"); // ✅ ensure this is exact
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            client.Dispose();
        }

        [Test]
        public async Task GetPost_ShouldReturn200()
        {
            var response = await client.GetAsync("posts/1");

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            var body = await response.Content.ReadAsStringAsync();
            TestContext.WriteLine("GET Response:");
            TestContext.WriteLine(body);
        }

        [Test]
        public async Task CreatePost_ShouldReturn201()
        {
            var json = "{ \"title\": \"foo\", \"body\": \"bar\", \"userId\": 1 }";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("posts", content);

            Assert.That((int)response.StatusCode, Is.EqualTo(201));

            var body = await response.Content.ReadAsStringAsync();
            TestContext.WriteLine("POST Response:");
            TestContext.WriteLine(body);
        }

        [Test]
        public async Task DeletePost_ShouldReturn200()
        {
            var response = await client.DeleteAsync("posts/1");

            Assert.That((int)response.StatusCode, Is.EqualTo(200));
            TestContext.WriteLine($"DELETE Status: {(int)response.StatusCode}");
        }
    }
}
