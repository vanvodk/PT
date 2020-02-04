//using Xunit;
//using Paymentsense.Coding.Challenge.Api.Controllers;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Microsoft.AspNetCore.Mvc;
//using System.Net.Http;
//using Microsoft.Extensions.Caching.Memory;

//namespace Paymentsense.Coding.Challenge.Api.Controllers.Tests
//{
//    public class CountriesControllerTests
//    {
//        private readonly IHttpClientFactory _clientFactory;
//        private readonly IMemoryCache _memoryCache;

//        public CountriesControllerTests(IHttpClientFactory clientFactory, IMemoryCache memoryCache)
//        {
//            _clientFactory = clientFactory;
//            _memoryCache = memoryCache;
//        }
//        [Fact()]
//        public void GetTest()
//        {
//            var controller = new CountriesController(clientFactory, memoryCache);

//            var result = controller.Get().Result as OkObjectResult;

//            result.StatusCode.Should().Be(StatusCodes.Status200OK);
//            result.Value.Should().Be("Paymentsense Coding Challenge!");
//        }
//    }
//}