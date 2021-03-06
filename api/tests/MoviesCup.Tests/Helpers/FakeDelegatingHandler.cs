﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesCup.Tests.Helpers
{
    public class FakeDelegatingHandler : DelegatingHandler
    {
        private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _handlerFunc;

        public FakeDelegatingHandler(HttpStatusCode statusCode, string content)
        {
            var response = new HttpResponseMessage(statusCode);

            if (!string.IsNullOrEmpty(content))
                response.Content = new StringContent(content);

            _handlerFunc = (request, cancellationToken) => Task.FromResult(response);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return _handlerFunc(request, cancellationToken);
        }
    }
}
