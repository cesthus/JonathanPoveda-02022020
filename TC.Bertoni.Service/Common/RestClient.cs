using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TC.Bertoni.Interface;

namespace TC.Bertoni.Service.Common
{
    public class RestClient : IRestClient
    {
        private readonly HttpClient _htppClient;

        public RestClient()
        {
            _htppClient = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string url)
        {
            try
            {
                HttpResponseMessage response = await _htppClient.GetAsync(url);
                string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (!CheckIFError(response.StatusCode, content))
                {
                    return JsonConvert.DeserializeObject<T>(content);
                }
            }
            catch (System.Net.WebException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in GET Request :" + ex.Message);
            }
            return default(T);
        }

        public async Task<List<T>> GetListAsync<T>(string url)
        {
            try
            {
                HttpResponseMessage response = await _htppClient.GetAsync(url);
                string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (!CheckIFError(response.StatusCode, content))
                {
                    return JsonConvert.DeserializeObject<List<T>>(content);
                }
            }
            catch (System.Net.WebException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in GET Request :" + ex.Message);
            }
            return default(List<T>);
        }

        /// <summary>
        /// Check if the request return error
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        private bool CheckIFError(HttpStatusCode statusCode, string body)
        {
            if (statusCode < HttpStatusCode.OK || statusCode >= HttpStatusCode.BadRequest)
            {
                Debug.WriteLine(string.Format("Request return with status code={0}, response={1}", statusCode, body));
                return true;
            }
            return false;
        }
    }
}
