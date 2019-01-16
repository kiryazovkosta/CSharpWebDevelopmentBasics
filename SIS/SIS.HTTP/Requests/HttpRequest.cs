// 	<copyright file=HttpRequest.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/4/2019 11:56:52 AM</date>
// 	<summary>Class representing a HttpRequest entity</summary>
namespace SIS.HTTP.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Web;
    using Common;
    using Contracts;
    using Enums;
    using Exceptions;
    using Headers;
    using Headers.Contracts;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();

            this.ParseRequest(requestString);
        }

        private void ParseRequest(string requestString)
        {
            var splitRequestContent = requestString.Split(Environment.NewLine, StringSplitOptions.None);
            var requestLine = splitRequestContent[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidateRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
        }

        private void ParseRequestParameters(string requestParameters)
        {
            this.ParseQueryParameters(requestParameters);
            this.ParseFormDataParameters(requestParameters);
        }

        private void ParseFormDataParameters(string formData)
        {
            if (string.IsNullOrEmpty(formData))
            {
                return;
            }

            var formDataParams = formData.Split('&');
            foreach (var formDataParameter in formDataParams)
            {
                var parameterArguments = formDataParameter.Split('=', StringSplitOptions.None);

                if (this.FormData.ContainsKey(parameterArguments[0]))
                {
                    if (this.FormData[parameterArguments[0]] is string 
                        || !(this.FormData[parameterArguments[0]] is List<string>)
                        )
                    {
                        var collection = new List<string> { this.FormData[parameterArguments[0]].ToString() };
                        this.FormData[parameterArguments[0]] = collection;
                    }

                    ((List<string>)this.FormData[parameterArguments[0]]).Add(HttpUtility.UrlDecode(parameterArguments[1]));
                }
                else
                {
                    if (parameterArguments.Length == 2)
                    {
                        this.FormData.Add(parameterArguments[0], HttpUtility.UrlDecode(parameterArguments[1]));
                    }
                }
            }
        }

        private void ParseQueryParameters(string requestParameters)
        {
            if (!this.Url.Contains('?'))
            {
                return;
            }

            var queryString = this.Url.Split(new[] { '?', '#' }, StringSplitOptions.None)[1];
            if (string.IsNullOrWhiteSpace(queryString))
            {
                return;
            }

            var queryParameters = queryString.Split('&');
            if (!this.IsValidRequestQueryString(queryString, queryParameters))
            {
                throw new BadRequestException();
            }

            foreach (var queryParameter in queryParameters)
            {
                var parameterArguments = queryParameter.Split('=', StringSplitOptions.None);
                this.QueryData.Add(parameterArguments[0], parameterArguments[1]);
            }
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            return !(string.IsNullOrEmpty(queryString) || queryParameters.Length < 1);
        }

        private void ParseHeaders(string[] requestHeaders)
        {
            if (!requestHeaders.Any())
            {
                throw new BadRequestException();
            }

            foreach (var requestHeader in requestHeaders)
            {
                if (string.IsNullOrEmpty(requestHeader))
                {
                    break;
                }

                var splitRequestHeader = requestHeader.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                var requestHeaderKey = splitRequestHeader[0];
                var requestHeaderValue = splitRequestHeader[1];

                this.Headers.Add(new HttpHeader(requestHeaderKey, requestHeaderValue));
            }
        }

        private void ParseRequestPath()
        {
            var path = this.Url?.Split('?').FirstOrDefault();
            if (string.IsNullOrEmpty(path))
            {
                throw new BadRequestException();
            }

            this.Path = path;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            this.Url = requestLine[1];
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            var parseResult = Enum.TryParse<HttpRequestMethod>(requestLine[0], out HttpRequestMethod parsedRequestMethod);
            if (!parseResult)
            {
                throw new BadRequestException();
            }

            this.RequestMethod = parsedRequestMethod;
        }

        private bool IsValidateRequestLine(string[] requestLine)
        {
            if (requestLine.Length == 3 
                && requestLine[2] == GlobalConstants.HttpOneProtocolFragment
                )
            {
                return true;
            }

            return false;
        }

        public string Path { get; private set; }
        public string Url { get; private set; }
        public Dictionary<string, object> FormData { get; }
        public Dictionary<string, object> QueryData { get; }
        public IHttpHeaderCollection Headers { get; }
        public HttpRequestMethod RequestMethod { get; private set; }
    }
}