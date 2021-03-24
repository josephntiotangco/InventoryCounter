using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using InventoryCounter.Classes;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryCounter.Services
{
    public class RestService : IDisposable
    {
        private HttpClient _httpClient;
        public HttpStatusCode httpLastStatusCode;
        Constructors.TokenRequest token_request = new Constructors.TokenRequest();
        Constructors.TokenResponse token_response = new Constructors.TokenResponse();

        private CancellationTokenSource _cts = new CancellationTokenSource();

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public RestService(string url)
        {
            _httpClient = new HttpClient(new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = new CookieContainer()
            })
            {
                //BaseAddress = new Uri(),
                BaseAddress = new Uri(url),
                DefaultRequestHeaders =
                {
                    Accept = { MediaTypeWithQualityHeaderValue.Parse("text/json")}
                }
            };
            _httpClient.Timeout = TimeSpan.FromSeconds(20);
        }

        private void CancelTask()
        {
            _cts.Cancel();
            _cts = new CancellationTokenSource();
        }

        public string Request(string method, string entity, string endpoint, HttpContent data, out string error, string param = "", string token = "", bool isQuery = false, string id = "")
        {
            try
            {
                HttpResponseMessage response = null;

                string url_char = !isQuery ? "/" : "?";
                string recorded_response = "";

                if (token != "")
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                switch (method)
                {
                    case "GET":
                        response = _httpClient.GetAsync(_httpClient.BaseAddress + endpoint + entity + url_char + param + id, _cts.Token).Result;
                        break;
                    case "PUT":
                        response = _httpClient.PutAsync(_httpClient.BaseAddress + endpoint + entity + "/" + id + param, data, _cts.Token).Result;
                        break;
                    case "POST":
                        response = _httpClient.PostAsync(_httpClient.BaseAddress + endpoint + entity, data, _cts.Token).Result;
                        break;
                }

                if (!response.IsSuccessStatusCode)
                {
                    CancelTask();
                    error = "";
                    return "";
                }
                else
                {
                    recorded_response = response.Content.ReadAsStringAsync().Result;
                    CancelTask();
                    error = "";
                    return recorded_response == "" ? "" : recorded_response;
                    // return response.Content.ReadAsStringAsync().Result;
                }

            }
            catch (WebException web_e)
            {
                CancelTask();
                error = web_e.Message;
                return web_e.Message;
            }
            catch (TaskCanceledException task_e)
            {
                error = task_e.Message;
                return task_e.Message;
            }
            catch (TimeoutException time_e)
            {
                error = time_e.Message;
                return time_e.Message;
            }
            catch (Exception e)
            {
                error = e.Message;
                return e.Message;
            }

        }

    }
}
