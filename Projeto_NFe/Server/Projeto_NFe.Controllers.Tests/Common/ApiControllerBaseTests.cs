using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Moq;
using NUnit.Framework;
using Projeto_NFe.API.Models;
using Projeto_NFe.Controllers.Tests.Initializer;
using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Projeto_NFe.Controllers.Tests.Common
{
    [TestFixture]
    public class ApiControllerBaseTests : TestControllerBase
    {
        /* Perceba que esse fake serve apenas para expor os comportamentos de ApiControllerBase */
        private ApiControllerBaseFake _apiControllerBase;
        private Mock<ApiControllerBaseDummy> _dummy;


        [SetUp]
        public void Initialize()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _apiControllerBase = new ApiControllerBaseFake()
            {
                Request = request
            };
            _dummy = new Mock<ApiControllerBaseDummy>();
        }

        #region HandleCallback

        [Test]
        public void Base_Controller_HandleCallback_ShouldBeOk()
        {
            // Action
            var callback = _apiControllerBase.HandleCallback(_dummy.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<ApiControllerBaseDummy>>().Subject;
            httpResponse.Content.Should().Be(_dummy.Object);
        }

        #endregion

        #region HandleQuery

        [Test]
        public void Base_Controller_HandleQuery_ShouldBeOk()
        {
            //Arrange
            var odataOptions = GetOdataQueryOptions<ApiControllerBaseDummy>(_apiControllerBase);
            // Action
            var callback = _apiControllerBase.HandleQuery<ApiControllerBaseDummy, ApiControllerBaseDummyViewModel>(_dummy.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<ApiControllerBaseDummyViewModel>>().Subject;
            httpResponse.Content.Should().NotBeNull();
        }

        [Test]
        public async Task Base_Controller_HandleQuery_ShouldHandleCSVExportAsync()
        {
            //Arrange
            var odataOptions = GetOdataQueryOptions<ApiControllerBaseDummy>(_apiControllerBase);
            _apiControllerBase.Request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(MediaTypes.Csv));
            // Action
            var callback = _apiControllerBase.HandleQuery<ApiControllerBaseDummy, ApiControllerBaseDummyViewModel>(_dummy.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<ResponseMessageResult>().Subject.Response;
            var data = await httpResponse.Content.ReadAsStringAsync();
            data.Should().NotBeNull();
        }

        [Test]
        public async Task Base_Controller_HandleQuery_ShouldHandleCSVExportAsyncWithoutData()
        {
            //Arrange
            var odataOptions = GetOdataQueryOptions<ApiControllerBaseDummy>(_apiControllerBase);
            _apiControllerBase.Request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(MediaTypes.Csv));
            // Action
            var callback = _apiControllerBase.HandleQuery<ApiControllerBaseDummy, ApiControllerBaseDummyViewModel>(_dummy.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<ResponseMessageResult>().Subject.Response;
            var data = await httpResponse.Content.ReadAsStringAsync();
            httpResponse.Content.Headers.ContentDisposition.DispositionType.Should().Be("attachment");
            httpResponse.Content.Headers.ContentType.MediaType.Should().Be(MediaTypes.OctetStream);
        }

        #endregion

        #region HandlePageResult
        [Test]
        public void Base_Controller_HandlePageResult_ShouldBeOk()
        {
            //Arrange
            var query = new List<ApiControllerBaseDummy>() { _dummy.Object }.AsQueryable();
            var odataOptions = GetOdataQueryOptions<ApiControllerBaseDummy>(_apiControllerBase);
            // Action
            var callback = _apiControllerBase.HandleQueryable<ApiControllerBaseDummy, ApiControllerBaseDummyViewModel>(query, odataOptions);
            //Assert
            var contentResponse = callback.Should().BeOfType<OkNegotiatedContentResult<PageResult<ApiControllerBaseDummyViewModel>>>().Subject;
            contentResponse.Should().NotBeNull();
        }

        [Test]
        public async Task Base_Controller_HandleQueryable_ShouldHandleCSVExportAsync()
        {
            //Arrange
            var query = new List<ApiControllerBaseDummy>() { _dummy.Object }.AsQueryable();
            var odataOptions = GetOdataQueryOptions<ApiControllerBaseDummy>(_apiControllerBase);
            _apiControllerBase.Request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(MediaTypes.Csv));
            // Action
            var callback = _apiControllerBase.HandleQueryable<ApiControllerBaseDummy, ApiControllerBaseDummyViewModel>(query, odataOptions);
            //Assert
            var httpResponse = callback.Should().BeOfType<ResponseMessageResult>().Subject.Response;
            var data = await httpResponse.Content.ReadAsStringAsync();
            data.Should().NotBeNull();
        }

        #endregion

        #region HandleValidationFailure

        [Test]
        public void Base_Controller_HandleValidationFailure_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var validationFailure = new ValidationFailure("", ((int)ErrorCodes.Unhandled).ToString());
            IList<ValidationFailure> errors = new List<ValidationFailure>() { validationFailure };
            // Action
            var callback = _apiControllerBase.HandleValidationFailure(errors);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.FirstOrDefault().Should().Be(validationFailure);
        }

        #endregion
    }
}
