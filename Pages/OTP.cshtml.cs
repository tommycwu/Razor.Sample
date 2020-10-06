using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
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
        private static string redirectUrlEncoded = System.Net.WebUtility.UrlEncode(@"https://localhost:44336/authorization-code/callback");

        private static string scope = System.Net.WebUtility.UrlEncode("openid profile email");
        private static string responseType = System.Net.WebUtility.UrlEncode("id_token token");
        private static string apiKey = "00Sfdsuhpku46epPueiWVnXZ5ONBhrB1cDEGW0sKME";
        private string sessionToken = "";
        private string userId = "";

        public string FormatJson(string jsonStr)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            var jsonElement = System.Text.Json.JsonSerializer.Deserialize<JsonElement>(jsonStr);

            return System.Text.Json.JsonSerializer.Serialize(jsonElement, options);
        }

        private bool ValidateFactor(string s, string f, string p)
        {
            var stateToken = s;
            var factorId = f;
            var passCode = p;
            var authnUri = $"{oktaDomain}/api/v1/authn/factors/{factorId}/verify";

            dynamic bodyOfRequest = new
            {
                stateToken,
                passCode,
            };
            var body = JsonConvert.SerializeObject(bodyOfRequest);
            var stringContent = new StringContent(body, Encoding.UTF8, "application/json");

            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            var httpClient = new HttpClient(httpClientHandler);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage authnResponse = httpClient.PostAsync(authnUri, stringContent).Result;

            if (authnResponse.IsSuccessStatusCode)
            {
                var authnResponseContent = authnResponse.Content.ReadAsStringAsync();
                dynamic authnObject = JsonConvert.DeserializeObject(authnResponseContent.Result);
                sessionToken = authnObject.sessionToken;

                return true;
            }
            return false;
        }

        private string BuildCookieUrl(string session_Token)
        {
            return "https://dev-489843.okta.com/oauth2/v1/authorize?client_id=0oa12ggderGOV0YAy4x7&response_type=id_token&scope=openid%20email&redirect_uri=https%3A%2F%2Flocalhost%3A44336%2Fauthorization-code%2Fcallback&state=state&nonce=nonce&sessionToken=" + session_Token;
        }

        public void OnGet()
        {
            //if mfa is needed
            if (Request.Query["t"] != "1")
            {
                ViewData["OTP"] = "needed";
            }
            else
            {
                sessionToken = Request.Query["n"];
                userId = Request.Query["i"];
                //redirect to the authorize endpoint to get id token and session cookie
                Response.Redirect(BuildCookieUrl(sessionToken));
            }
        }

        public void OnPost()
        {
            var passedStateToken = Request.Query["s"];
            var passedFactorId = Request.Query["f"];
            var uName = Request.Query["u"];
            var otpEntered = Request.Form["otp"];
            //check the passcode entered by the user
            var validArray = ValidateFactor(passedStateToken, passedFactorId, otpEntered);
            ViewData["session_Token"] = sessionToken;
            //now you have the session token redirect to get id token and session cookie
            Response.Redirect(BuildCookieUrl(sessionToken));
        }

    }
}