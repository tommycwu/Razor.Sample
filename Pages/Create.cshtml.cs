using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.WebSockets;
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
    public class CreateModel : PageModel
    {
        private static string oktaDomain = "https://dev-489843.okta.com";
        private static string apiKey = "00Sfdsuhpku46epPueiWVnXZ5ONBhrB1cDEGW0sKME";

        private bool CreateSdkUser(string f, string l, string u, string p)
        {
            try
            {
                var client = new OktaClient(new OktaClientConfiguration
                {
                    OktaDomain = oktaDomain,
                    Token = apiKey
                });
                // Create a user with the specified password
                var vader = client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
                {
                    // User profile object
                    Profile = new UserProfile
                    {
                        FirstName = f,
                        LastName = l,
                        Email = u,
                        Login = u,
                    },
                    Password = p,
                    Activate = true,
                }).Result;
            }
            catch
            {
                return false;
            }
            return true;
        }

        private bool CreateUser(string f, string l, string u, string p)
        {
            var usersUri = $"{oktaDomain}/api/v1/users?activate=true";
            var firstname = f;
            var lastname = l;
            var login = u;
            var email = u;
            var value = p;

            dynamic bodyOfRequest = new
            {
                profile = new
                {
                    firstname,
                    lastname,
                    email,
                    login,
                },
                credentials = new
                {
                    password = new
                    { 
                        value
                    }
                }
            };

            var body = JsonConvert.SerializeObject(bodyOfRequest);
            var stringContent = new StringContent(body, Encoding.UTF8, "application/json");

            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("SSWS", apiKey);

                HttpResponseMessage authnResponse = httpClient.PostAsync(usersUri, stringContent).Result;

                if (authnResponse.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public void OnGet()
        {

        }

        public void OnPost()
        {
            var fname = Request.Form["fname"];
            var lname = Request.Form["lname"];
            var uname = Request.Form["uname"];
            var pwd = Request.Form["pwd"];
            var resultBool = CreateSdkUser(fname, lname, uname, pwd);
            if (resultBool)
            {
                ViewData["results"] = uname;
            }
        }

    }
}