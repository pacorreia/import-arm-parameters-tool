using Common.Dto;
using Common.Exceptions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.HttpClient
{
    public class AppHttpClient
    {
        private readonly string Url;
        
        private readonly string Authorization;      

        public AppHttpClient(string Url, string Username, string Password)
        {
            this.Url = Url;

            this.Authorization="Basic " + System.Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Username}:{Password}"));
        }

        public AppHttpClient(string Url, string BearerToken)
        {
            this.Url = Url;

            this.Authorization=$"Bearer {BearerToken}";
        }

        public AppHttpClient(string Url)
        {
            this.Url = Url;
            this.Authorization=string.Empty;
        }

        public IRestResponse SendPost(object message, Dictionary<string, string> queryParams, Dictionary<string, string> headers)
        {
            var client = new RestClient(this.Url)
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.POST);

            if (this.Authorization is not null){
                request.AddHeader("Authorization",this.Authorization);
            }

            if (headers != null)
            {
                foreach (KeyValuePair<string, string> entry in headers)
                {
                    request.AddHeader(entry.Key, entry.Value);
                }
            }

            if (queryParams != null)
            {
                foreach (KeyValuePair<string, string> entry in queryParams)
                {
                    request.AddQueryParameter(entry.Key, entry.Value);
                }
            }
            request.AddJsonBody(JsonConvert.SerializeObject(message));
            IRestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                throw new AppRuntimeException(response.StatusCode,JsonConvert.DeserializeObject<Message>(response.Content).message);                
            }
            return response;
        }

        public IRestResponse SendPost(object obj, Dictionary<string, string> headers=null)
        {
            var client = new RestClient(this.Url)
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.POST);

            if (this.Authorization != string.Empty){
                request.AddHeader("Authorization",this.Authorization);
            }

            if (headers != null)
            {
                foreach (KeyValuePair<string, string> entry in headers)
                {
                    request.AddHeader(entry.Key, entry.Value);
                }
            }

            request.AddJsonBody(JsonConvert.SerializeObject(obj));
            IRestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                throw new AppRuntimeException(response.StatusCode, response.Content);                
            }
            return response;
        }

        public IRestResponse SendGet(Dictionary<string, string> queryParams=null, Dictionary<string, string> headers=null)
        {
            var client = new RestClient(this.Url)
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);

            if (this.Authorization != string.Empty){
                request.AddHeader("Authorization",this.Authorization);
            }

            if (headers != null)
            {
                foreach (KeyValuePair<string, string> entry in headers)
                {
                    request.AddHeader(entry.Key, entry.Value);
                }
            }

            if (queryParams != null)
            {
                foreach (KeyValuePair<string, string> entry in queryParams)
                {
                    request.AddQueryParameter(entry.Key, entry.Value);
                }
            }
            
            IRestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                throw new AppRuntimeException(response.StatusCode, response.Content);
            }
            return response;
        }
    }
}