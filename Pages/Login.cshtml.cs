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

namespace Razor.Sample.Pages
{
    public class LoginModel : PageModel
    {

        private static string oktaDomain = "https://dev-489843.okta.com";

        private string[] GetStateAndFactor(string u, string p)
        {
            var authnUri = $"{oktaDomain}/api/v1/authn";
            var username = u;
            var password = p;

            dynamic bodyOfRequest = new
            {
                username,
                password,
                options = new
                {
                    multiOptionalFactorEnroll = true,
                    warnBeforePasswordExpired = false,
                },
            };

            var body = JsonConvert.SerializeObject(bodyOfRequest);

            var stringContent = new StringContent(body, Encoding.UTF8, "application/json");

            string stateToken = "";
            string factorId = "";

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
                    var authnResponseContent = authnResponse.Content.ReadAsStringAsync().Result;

                    dynamic authnObject = JsonConvert.DeserializeObject(authnResponseContent);
                    stateToken = authnObject.stateToken;

                    for (int i = 0; i < authnObject._embedded.factors.Count; i++)
                    {
                        dynamic factorsObj = authnObject._embedded.factors[i];
                        string factorTyp = factorsObj.factorType;
                        if (factorTyp == "sms")
                        {
                            factorId = factorsObj.id;
                            break;
                        }
                    }

                    var retArray = new string[]
                    {
                        stateToken,
                        factorId,
                    };

                    return retArray;
                }
            }
            return null;
        }


        private string[] InvokeFactor(string s, string f)
        {
            var stateToken = s;
            var factorId = f;
            var authnUri = $"{oktaDomain}/api/v1/authn/factors/{factorId}/verify";
            var stToken = "";
            var factId = "";

            dynamic bodyOfRequest = new
            {
                stateToken
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
                    var authnResponseContent = authnResponse.Content.ReadAsStringAsync().Result;

                    dynamic authnObject = JsonConvert.DeserializeObject(authnResponseContent);
                    stToken = authnObject.stateToken;
                    factId = authnObject._embedded.factor.id;

                    var retArray = new string[]
                    {
                        stToken,
                        factId,
                    };

                    return retArray;
                }
            }
            return null;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            var sUsrname = Request.Form["usrname"];
            var sPwd = Request.Form["pwd"];
            string[] arrayGet = GetStateAndFactor(sUsrname, sPwd);
            var retStateToken = arrayGet[0];
            var retFactorId = arrayGet[1];
            string[] arrayInvoke = InvokeFactor(retStateToken, retFactorId);
            Response.Redirect("OTP?s=" + arrayInvoke[0] +  "&f=" + arrayInvoke[1] + "&u=" + sUsrname);
        }
    }
}