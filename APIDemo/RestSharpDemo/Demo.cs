﻿using RestSharp;
using RestSharpDemo.Models.Request;
using System.Threading.Tasks;

namespace RestSharpDemo
{
    public class Demo
    {
        private Helper helper;
        public Demo()
        {
            helper = new Helper();
        }
        public async Task<RestResponse> GetUsers(string baseUrl)
        {
            var client = helper.SetUrl(baseUrl, "api/users?page=2");
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
        public async Task<RestResponse> CreateNewUser(string baseUrl, dynamic payload)
        {
            var client = helper.SetUrl(baseUrl, "api/users");
            var request = helper.CreatePostRequest<CreateUserRequest>(payload);
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
    }
}