#pragma checksum "C:\Users\vladi\Documents\GitHub\signalR-chat\Chat\Chat\Pages\Registration.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c36175c9cd9766df14d437fa31bb6c740f5cfdf6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Chat.Pages.Pages_Registration), @"mvc.1.0.razor-page", @"/Pages/Registration.cshtml")]
namespace Chat.Pages
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
#line 1 "C:\Users\vladi\Documents\GitHub\signalR-chat\Chat\Chat\Pages\_ViewImports.cshtml"
using Chat;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c36175c9cd9766df14d437fa31bb6c740f5cfdf6", @"/Pages/Registration.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1324a9f64e014a04effee3e9c3dcad269bac2b1a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Registration : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\vladi\Documents\GitHub\signalR-chat\Chat\Chat\Pages\Registration.cshtml"
  
    ViewData["Title"] = "Форма регистрации";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Регистрация нового пользователя</h1>

<div class=""form-row"">
    <div class=""form-group col-md-4"">
        <label for=""username"">Имя пользователя (логин)</label>
        <input type=""text"" class=""form-control"" id=""username"" placeholder=""Логин"">
    </div>
</div>

<div class=""form-row"">
    <div class=""form-group col-md-4"">
        <label for=""password"">Пароль</label>
        <input type=""text"" class=""form-control"" id=""password"" placeholder=""Пароль"">
    </div>
</div>

<div class=""form-row"">
    <div class=""form-group col-md-4"">
        <label for=""againPassword"">Повторите пароль</label>
        <input type=""text"" class=""form-control"" id=""againPassword"" placeholder=""Повторите пароль"">
    </div>
</div>

<div class=""form-row"">
    <div class=""form-group col-md-4"">
        <input type=""button"" value=""Регистрация"" id=""registrationBut"" class=""btn btn-primary"">
    </div>

    <div class=""form-group col-md-4"">
        <a href=""/"" class=""btn btn-primary"" role=""button"">Назад</a>
  ");
            WriteLiteral("  </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Chat.Pages.RegistrationModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Chat.Pages.RegistrationModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Chat.Pages.RegistrationModel>)PageContext?.ViewData;
        public Chat.Pages.RegistrationModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
