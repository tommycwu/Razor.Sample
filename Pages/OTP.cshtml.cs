using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Okta.Sdk;
using Okta.Sdk.Configuration;


namespace Razor.Sample.Pages
{
    public class OTPModel : PageModel
    {
        private static string oktaDomain = "https://dev-489843.okta.com";
        private static string oktaAuthorizationServer = "aus12xq52tYhEMf0Z4x7";
        private static string clientId = "0oa12ggderGOV0YAy4x7";
        private static string scope = System.Net.WebUtility.UrlEncode("openid profile");
        private static string responseType = System.Net.WebUtility.UrlEncode("id_token token");
        private static string redirectUrlEncoded = System.Net.WebUtility.UrlEncode(@"https://localhost:44336/authorization-code/callback");
        private static string apiKey = "00Sfdsuhpku46epPueiWVnXZ5ONBhrB1cDEGW0sKME";
        private string sessionToken = "";


        private bool ValidateFactor(string s, string f, string p)
        {
            var stateToken = s;
            var factorId = f;
            var authnUri = $"{oktaDomain}/api/v1/authn/factors/{factorId}/verify";
            var passCode = p;

            dynamic bodyOfRequest = new
            {
                stateToken,
                passCode,
            };

            var body = JsonConvert.SerializeObject(bodyOfRequest);

            var stringContent = new StringContent(body, Encoding.UTF8, "application/json");

            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                httpClient.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage authnResponse = httpClient.PostAsync(authnUri, stringContent).Result;

                if (authnResponse.IsSuccessStatusCode)
                {
                    var authnResponseContent = authnResponse.Content.ReadAsStringAsync();
                    dynamic authnObject = JsonConvert.DeserializeObject(authnResponseContent.Result);
                    sessionToken = authnObject.sessionToken;

                    //var authorizeUri = $"{oktaDomain}/oauth2/{oktaAuthorizationServer}/v1/authorize?client_id={clientId}&redirect_uri={redirectUrlEncoded}" +
                    //    $"&response_type={responseType}&sessionToken={sessionToken}&state=state&nonce=nonce&scope={scope}";

                    //HttpResponseMessage authorizeResponse = httpClient.GetAsync(authorizeUri).Result;
                    //var statusCode = (int)authorizeResponse.StatusCode;

                    //var client = new OktaClient(new OktaClientConfiguration
                    //{
                    //    OktaDomain = oktaDomain,
                    //    Token = apiKey
                    //});

                    //client.Sessions.CreateSessionAsync(

                    return true;
                }
            }
            return false;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            var passedStateToken = Request.Query["s"];
            var passedFactorId = Request.Query["f"];
            var uName = Request.Query["u"];
            var otpEntered = Request.Form["otp"];
            var resultBool = ValidateFactor(passedStateToken, passedFactorId, otpEntered);
            if (resultBool == true)
            {
                ViewData["results"] = sessionToken;
                Response.Redirect("https://dev-489843.okta.com/login/sessionCookieRedirect?redirectUrl=https://dev-489843.okta.com/app/salesforce/exk12hqybjchsRyAl4x7/sso/saml&token=" + sessionToken);
            }
        }

    }
}