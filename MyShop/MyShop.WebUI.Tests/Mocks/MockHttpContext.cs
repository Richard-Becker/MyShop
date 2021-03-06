using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyShop.WebUI.Tests.Mocks
{
    public class MockHttpContext : HttpContextBase
    {
        private MockResoponse response;
        private MockRequest request;
        private HttpCookieCollection cookies;
        private IPrincipal FakeUser;

        public MockHttpContext()
        {
            cookies = new HttpCookieCollection();
            this.request = new MockRequest(cookies);
            this.response = new MockResoponse(cookies);
        }

        public override IPrincipal User
        {
            get
            {
                return this.FakeUser;
            }
            set
            {
                this.FakeUser = value;
            }
        }

        public override HttpRequestBase Request
        {
            get
            {
                return request;
            }
        }

        public override HttpResponseBase Response
        {
            get
            {
                return response;
            }
        }
    }

    public class MockResoponse : HttpResponseBase
    {
        private readonly HttpCookieCollection cookies;

        public MockResoponse(HttpCookieCollection cookies)
        {
            this.cookies = cookies;
        }

        public override HttpCookieCollection Cookies
        {
            get
            {
                return cookies;
            }
        }
    }

    public class MockRequest : HttpRequestBase
    {
        private readonly HttpCookieCollection cookies;

        public MockRequest (HttpCookieCollection cookies)
        {
            this.cookies = cookies;
        }

        public override HttpCookieCollection Cookies
        {
            get
            {
                return cookies;
            }
        }
    }
}
