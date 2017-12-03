using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PuzzlersJordan.Helpers
{

    /// <summary>
    /// This class is copied from https://github.com/bkniffler/graphql-net-client for manipulation purposes
    /// </summary>
    public class GraphQLClient
    {
        readonly string url;
        readonly HttpClient client;

        public GraphQLClient(string url)
        {
            this.url = url;
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Shopify-Storefront-Access-Token", Settings.Instance.ShopifyAccessToken);
        }

        private class GraphQLQuery
        {
            [JsonProperty("query")]
            public string Query { get; set; }

            [JsonProperty("variables")]
            public object Variables { get; set; }
        }

        public class GraphQLQueryResult
        {
            private string raw;
            private JObject data;
            private Exception Exception;

            public GraphQLQueryResult(string text, Exception ex = null)
            {
                Exception = ex;
                raw = text;
                data = text != null ? JObject.Parse(text) : null;
            }

            public Exception GetException()
            {
                return Exception;
            }

            public string GetRaw()
            {
                return raw;
            }

            public T Get<T>(string path) {
                if (data == null) return default(T);
                try
                {
                    return JsonConvert.DeserializeObject<T>(this.data["data"].SelectToken(path).ToString());
                }
                catch
                {
                    return default(T);
                }
            }

            //public T Get<T>(string key)
            //{
            //    if (data == null) return default(T);
            //    try
            //    {
            //        return JsonConvert.DeserializeObject<T>(this.data["data"][key].ToString());
            //    }
            //    catch
            //    {
            //        return default(T);
            //    }
            //}

            public dynamic Get(string key)
            {
                if (data == null) return null;
                try
                {
                    return JsonConvert.DeserializeObject<dynamic>(this.data["data"][key].ToString());
                }
                catch
                {
                    return null;
                }
            }

            public dynamic GetData()
            {
                if (data == null) return null;
                try
                {
                    return JsonConvert.DeserializeObject<dynamic>(this.data["data"].ToString());
                }
                catch
                {
                    return null;
                }
            }
        }

        public async Task<GraphQLQueryResult> QueryAsync(string query, object variables)
        {
            var fullQuery = new GraphQLQuery()
            {
                Query = query,
                Variables = variables,
            };

            string jsonContent = JsonConvert.SerializeObject(fullQuery);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(this.url, content);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                return new GraphQLQueryResult(json);
            }
            catch (WebException ex)
            {
                var errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    System.Diagnostics.Debug.WriteLine(errorText);
                    return new GraphQLQueryResult(null, ex);
                }
            }
        }
    }
}
