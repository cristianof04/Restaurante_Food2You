#pragma checksum "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\MostrarAvaliacoes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf65f3d58c6ebad22757f8439547852941bd14b7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cliente_MostrarAvaliacoes), @"mvc.1.0.view", @"/Views/Cliente/MostrarAvaliacoes.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf65f3d58c6ebad22757f8439547852941bd14b7", @"/Views/Cliente/MostrarAvaliacoes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a525c2b9f5b4e11df46e2eb0b985798acb8afdb3", @"/Views/_ViewImports.cshtml")]
    public class Views_Cliente_MostrarAvaliacoes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<lab.Models.AvaliarRestaurates>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "AvaliarRestaurantes", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Restaurante", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Menu", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\MostrarAvaliacoes.cshtml"
  
    var NomeRestaurante = ViewBag.NomeRestaurante as string;
    var FotoRestaurante = ViewBag.FotoRestaurante as string;
    var NomeClientes = ViewBag.NomeClientes as string[];

    string UsernameRestaurante = ViewBag.UsernameRestaurante;

    var jaAvaliou = ViewBag.jaAvaliouP as string;

    int i = 0;

    int estrelas = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Avaliar Restaurantes</h1>\r\n<br />\r\n<h2>Restaurante: ");
#nullable restore
#line 18 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\MostrarAvaliacoes.cshtml"
            Write(NomeRestaurante);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<br />\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cf65f3d58c6ebad22757f8439547852941bd14b75963", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 502, "~/Imagens_Restaurante/", 502, 22, true);
#nullable restore
#line 21 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\MostrarAvaliacoes.cshtml"
AddHtmlAttributeValue("", 524, FotoRestaurante, 524, 16, false);

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
            WriteLiteral("\r\n\r\n<br />\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\MostrarAvaliacoes.cshtml"
           Write(Html.DisplayNameFor(model => model.Avaliacao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\MostrarAvaliacoes.cshtml"
           Write(Html.DisplayNameFor(model => model.Comentario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 37 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\MostrarAvaliacoes.cshtml"
         foreach (var item in Model)
        {
            for (i = 0; i < NomeClientes.Length; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 43 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\MostrarAvaliacoes.cshtml"
                   Write(NomeClientes[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 46 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\MostrarAvaliacoes.cshtml"
                          
                            estrelas = Convert.ToInt32(item.Avaliacao);
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 50 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\MostrarAvaliacoes.cshtml"
                         if (estrelas == 1)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a>");
#nullable restore
#line 52 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\MostrarAvaliacoes.cshtml"
                          Write(estrelas);

#line default
#line hidden
#nullable disable
            WriteLiteral(" estrela</a>\r\n");
#nullable restore
#line 53 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\MostrarAvaliacoes.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a>");
#nullable restore
#line 56 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\MostrarAvaliacoes.cshtml"
                          Write(estrelas);

#line default
#line hidden
#nullable disable
            WriteLiteral(" estrelas</a>\r\n");
#nullable restore
#line 57 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\MostrarAvaliacoes.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 60 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\MostrarAvaliacoes.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Comentario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 63 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\MostrarAvaliacoes.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<br />\r\n\r\n");
#nullable restore
#line 70 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\MostrarAvaliacoes.cshtml"
 if (jaAvaliou == null)
{
    ViewData["UsernameRestaurante"] = UsernameRestaurante;
    AvaliarRestaurates model = new AvaliarRestaurates();


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cf65f3d58c6ebad22757f8439547852941bd14b712134", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 76 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\MostrarAvaliacoes.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 76 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\MostrarAvaliacoes.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.ViewData = ViewData;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("view-data", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.ViewData, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 78 "C:\Users\crist\OneDrive\Documentos\Source\tr2\Prato_do_Dia\lab\lab\Views\Cliente\MostrarAvaliacoes.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf65f3d58c6ebad22757f8439547852941bd14b714484", async() => {
                WriteLiteral("Retrodecer");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<lab.Models.AvaliarRestaurates>> Html { get; private set; }
    }
}
#pragma warning restore 1591
