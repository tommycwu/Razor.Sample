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
using Okta.Auth.Sdk;
using Okta.Sdk.Configuration;

namespace Razor.Sample.Pages
{
    public class LoginModel : PageModel
    {

        private static string oktaDomain = "https://dev-489843.okta.com";

        private string[] GetState(string u, string p)
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
                    warnBeforePasswordExpired = true,
                },
            };

            var body = JsonConvert.SerializeObject(bodyOfRequest);

            var stringContent = new StringContent(body, Encoding.UTF8, "application/json");


            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage authnResponse = httpClient.PostAsync(authnUri, stringContent).Result;

                if (authnResponse.IsSuccessStatusCode)
                {
                    var authnResponseContent = authnResponse.Content.ReadAsStringAsync().Result;
                    string stToken = "";
                    string factId = "";
                    string usrId = "";
                    string sessToken = "";
                    var retArray = new string[3];

                    dynamic authnObject = JsonConvert.DeserializeObject(authnResponseContent);
                    stToken = authnObject.stateToken;
                    usrId = authnObject._embedded.user.id;
                    sessToken = authnObject.sessionToken;
                    if (stToken != null)
                    {

                        for (int i = 0; i < authnObject._embedded.factors.Count; i++)
                        {
                            dynamic factorsObj = authnObject._embedded.factors[i];
                            string factorTyp = factorsObj.factorType;
                            if (factorTyp == "sms")
                            {
                                factId = factorsObj.id;
                                break;
                            }
                        }
                        {
                            retArray[0] = stToken;
                            retArray[1] = usrId;
                            retArray[2] = factId;
                        };
                        return retArray;
                    }
                    else
                    {
                        {
                            retArray[0] = sessToken;
                            retArray[1] = usrId;
                            retArray[2] = null;
                        };
                    }
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
            //get username and password on form submit
            var sUsrname = Request.Form["usrname"];
            var sPwd = Request.Form["pwd"];

            //get validate username and passowrd
            string[] arrayGet = GetState(sUsrname, sPwd);
            if (arrayGet != null)
            {
                var retSToken = arrayGet[0];
                var retUserId = arrayGet[1];
                //if mfa is required
                if (arrayGet[2] != null)
                {
                    var retFactorId = arrayGet[2];
                    //goto the factors verify endpoint and invoke a sms call
                    string[] arrayInvoke = InvokeFactor(retSToken, retFactorId);
                    //redirect to the next page for the otp input
                    Response.Redirect("OTP?t=2&s=" + arrayInvoke[0] + "&f=" + arrayInvoke[1] + "&u=" + sUsrname + "&i=" + retUserId);
                }
                else
                {
                    //else redirect with session token
                    Response.Redirect("OTP?t=1&n=" + retSToken + "&u=" + sUsrname + "&i=" + retUserId);
                }
            }
            else
            {
                //display error message
            }
        }
    }
}