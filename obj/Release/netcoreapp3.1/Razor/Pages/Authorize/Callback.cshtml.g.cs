#pragma checksum "C:\Users\tommy.wu\source\repos\razor.sample\Pages\Authorize\Callback.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7c4d9f8b549ac21fecfd7fd9576d956b89fb81ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Razor.Sample.Pages.Authorize.Pages_Authorize_Callback), @"mvc.1.0.razor-page", @"/Pages/Authorize/Callback.cshtml")]
namespace Razor.Sample.Pages.Authorize
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\tommy.wu\source\repos\razor.sample\Pages\_ViewImports.cshtml"
using Razor.Sample;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c4d9f8b549ac21fecfd7fd9576d956b89fb81ae", @"/Pages/Authorize/Callback.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82e96a3eca4cb8ee4468b4462365bccb602a3fb5", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Authorize_Callback : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\tommy.wu\source\repos\razor.sample\Pages\Authorize\Callback.cshtml"
  
    ViewData["Title"] = "Callback";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Callback</h1>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Razor.Sample.Pages.Authorize.CallbackModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Razor.Sample.Pages.Authorize.CallbackModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Razor.Sample.Pages.Authorize.CallbackModel>)PageContext?.ViewData;
        public Razor.Sample.Pages.Authorize.CallbackModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
