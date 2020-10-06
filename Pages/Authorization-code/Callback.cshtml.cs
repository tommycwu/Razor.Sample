using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor.Sample.Pages.Authorization_code
{
    public class CallbackModel : PageModel
    {
        public string FormatJson(string jsonStr)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            var jsonElement = System.Text.Json.JsonSerializer.Deserialize<JsonElement>(jsonStr);

            return System.Text.Json.JsonSerializer.Serialize(jsonElement, options);
        }
        public void OnGet()
        {

        }

        public void OnPost()
        {
            try
            {
                var hashStr = Request.Form["Hash"].ToString();
                var idTokenState = hashStr.Substring(hashStr.IndexOf("=") + 1);
                var idTokenStr = idTokenState.Substring(0, idTokenState.IndexOf("&"));
                ViewData["id_token"] = idTokenStr;
                var jwtHandler = new JwtSecurityTokenHandler();
                var idTokenJwt = jwtHandler.ReadToken(idTokenStr) as JwtSecurityToken;
                var idTokenJson = idTokenJwt.ToString();
                ViewData["idTokenJson"] = FormatJson(idTokenJson.Substring(idTokenJson.IndexOf(".") + 1));
            }
            catch (Exception ex)
            {
                _ = ex;
            }
        }
    }
}