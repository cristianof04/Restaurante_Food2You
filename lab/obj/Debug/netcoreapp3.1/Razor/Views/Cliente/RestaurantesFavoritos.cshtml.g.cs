#pragma checksum "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\RestaurantesFavoritos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2513fb3c7af368df170cfea952538cd276e150ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cliente_RestaurantesFavoritos), @"mvc.1.0.view", @"/Views/Cliente/RestaurantesFavoritos.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\_ViewImports.cshtml"
using lab;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\_ViewImports.cshtml"
using lab.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2513fb3c7af368df170cfea952538cd276e150ed", @"/Views/Cliente/RestaurantesFavoritos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a525c2b9f5b4e11df46e2eb0b985798acb8afdb3", @"/Views/_ViewImports.cshtml")]
    public class Views_Cliente_RestaurantesFavoritos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<lab.Models.Restaurante>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\RestaurantesFavoritos.cshtml"
  
    int i = 0;
    var UsernameRestaurantes = ViewBag.Message as string[];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h4>Restaurantes favoritos</h4>\r\n<br />\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\RestaurantesFavoritos.cshtml"
           Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\RestaurantesFavoritos.cshtml"
           Write(Html.DisplayNameFor(model => model.Morada));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\RestaurantesFavoritos.cshtml"
           Write(Html.DisplayNameFor(model => model.Telefone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\RestaurantesFavoritos.cshtml"
           Write(Html.DisplayNameFor(model => model.Gps));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\RestaurantesFavoritos.cshtml"
           Write(Html.DisplayNameFor(model => model.Horario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\RestaurantesFavoritos.cshtml"
           Write(Html.DisplayNameFor(model => model.DiaDescanso));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 32 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\RestaurantesFavoritos.cshtml"
           Write(Html.DisplayNameFor(model => model.TipoServico));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 35 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\RestaurantesFavoritos.cshtml"
           Write(Html.DisplayNameFor(model => model.Foto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 42 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\RestaurantesFavoritos.cshtml"
         foreach (var item in Model)
        {
            if (UsernameRestaurantes != null)
            {
                for (i = 0; i < UsernameRestaurantes.Length; i++)
                {
                    if (item.Username == UsernameRestaurantes[i])
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 52 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\RestaurantesFavoritos.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 55 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\RestaurantesFavoritos.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Morada));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 58 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\RestaurantesFavoritos.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Telefone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 61 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\RestaurantesFavoritos.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Gps));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 64 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\RestaurantesFavoritos.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Horario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 67 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\RestaurantesFavoritos.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DiaDescanso));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 70 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\RestaurantesFavoritos.cshtml"
                       Write(Html.DisplayFor(modelItem => item.TipoServico));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2513fb3c7af368df170cfea952538cd276e150ed10538", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2400, "~/Imagens_Restaurante/", 2400, 22, true);
#nullable restore
#line 73 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\RestaurantesFavoritos.cshtml"
AddHtmlAttributeValue("", 2422, Html.DisplayFor(modelItem => item.Foto), 2422, 40, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </td>\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 77 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\RestaurantesFavoritos.cshtml"
                    }
                }
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<lab.Models.Restaurante>> Html { get; private set; }
    }
}
#pragma warning restore 1591