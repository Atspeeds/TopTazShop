#pragma checksum "C:\Users\A\source\repos\TopTazShop\ServiceHost\Views\Shared\Components\BasketComponent\BasketComponent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6611065233c1f227b32af9e7fa94b3024c7e6a93"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_BasketComponent_BasketComponent), @"mvc.1.0.view", @"/Views/Shared/Components/BasketComponent/BasketComponent.cshtml")]
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
#line 1 "C:\Users\A\source\repos\TopTazShop\ServiceHost\Views\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\A\source\repos\TopTazShop\ServiceHost\Views\_ViewImports.cshtml"
using ServiceHost.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\A\source\repos\TopTazShop\ServiceHost\Views\Shared\Components\BasketComponent\BasketComponent.cshtml"
using TopTaz.Application.BasketApplication.Dto;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6611065233c1f227b32af9e7fa94b3024c7e6a93", @"/Views/Shared/Components/BasketComponent/BasketComponent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"425974fd2d494185ca24335d9b188dc12f0975a3", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_BasketComponent_BasketComponent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BasketDto>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveItemFromBasket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Basket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/basket"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-cart"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\A\source\repos\TopTazShop\ServiceHost\Views\Shared\Components\BasketComponent\BasketComponent.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"user-item cart-list\">\r\n    <a href=\"#\">\r\n        <i class=\"fal fa-shopping-basket\"></i>\r\n\r\n");
#nullable restore
#line 11 "C:\Users\A\source\repos\TopTazShop\ServiceHost\Views\Shared\Components\BasketComponent\BasketComponent.cshtml"
         if (Model != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span class=\"bag-items-number\">");
#nullable restore
#line 13 "C:\Users\A\source\repos\TopTazShop\ServiceHost\Views\Shared\Components\BasketComponent\BasketComponent.cshtml"
                                      Write(Model.Items.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 14 "C:\Users\A\source\repos\TopTazShop\ServiceHost\Views\Shared\Components\BasketComponent\BasketComponent.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span class=\"bag-items-number\">0</span>\r\n");
#nullable restore
#line 18 "C:\Users\A\source\repos\TopTazShop\ServiceHost\Views\Shared\Components\BasketComponent\BasketComponent.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </a>\r\n    <ul>\r\n        <li class=\"cart-items\">\r\n            <ul class=\"do-nice-scroll\">\r\n");
#nullable restore
#line 24 "C:\Users\A\source\repos\TopTazShop\ServiceHost\Views\Shared\Components\BasketComponent\BasketComponent.cshtml"
                 if (Model != null)
                    foreach (var item in Model.Items)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"cart-item\">\r\n                            <span class=\"d-flex align-items-center mb-2\">\r\n                                <a href=\"#\">\r\n                                    <img");
            BeginWriteAttribute("src", " src=\"", 830, "\"", 850, 1);
#nullable restore
#line 30 "C:\Users\A\source\repos\TopTazShop\ServiceHost\Views\Shared\Components\BasketComponent\BasketComponent.cshtml"
WriteAttributeValue("", 836, item.ImageUrl, 836, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 851, "\"", 857, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                </a>\r\n                                <span>\r\n                                    <a href=\"#\">\r\n                                        <span class=\"title-item\">\r\n                                            ");
#nullable restore
#line 35 "C:\Users\A\source\repos\TopTazShop\ServiceHost\Views\Shared\Components\BasketComponent\BasketComponent.cshtml"
                                       Write(item.CatalogName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </span>
                                    </a>
                                    <span class=""color d-flex align-items-center"">
                                        تعداد:
                                        <span>");
#nullable restore
#line 40 "C:\Users\A\source\repos\TopTazShop\ServiceHost\Views\Shared\Components\BasketComponent\BasketComponent.cshtml"
                                         Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    </span>\r\n                                </span>\r\n                            </span>\r\n                            <span class=\"price\"> ");
#nullable restore
#line 44 "C:\Users\A\source\repos\TopTazShop\ServiceHost\Views\Shared\Components\BasketComponent\BasketComponent.cshtml"
                                            Write(item.UnitPrice.ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6611065233c1f227b32af9e7fa94b3024c7e6a939732", async() => {
                WriteLiteral("\r\n                                <input type=\"hidden\" name=\"ItemId\"");
                BeginWriteAttribute("value", " value=\"", 1802, "\"", 1818, 1);
#nullable restore
#line 46 "C:\Users\A\source\repos\TopTazShop\ServiceHost\Views\Shared\Components\BasketComponent\BasketComponent.cshtml"
WriteAttributeValue("", 1810, item.Id, 1810, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                <button class=\"remove-item\">\r\n                                    <i class=\"far fa-trash-alt\"></i>\r\n                                </button>\r\n\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </li>\r\n");
#nullable restore
#line 53 "C:\Users\A\source\repos\TopTazShop\ServiceHost\Views\Shared\Components\BasketComponent\BasketComponent.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n        </li>\r\n        <li class=\"cart-footer\">\r\n            <span class=\"d-block text-center mb-3\">\r\n");
#nullable restore
#line 58 "C:\Users\A\source\repos\TopTazShop\ServiceHost\Views\Shared\Components\BasketComponent\BasketComponent.cshtml"
                 if (Model != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>\r\n                        مبلغ کل:\r\n                        <span class=\"total\">");
#nullable restore
#line 62 "C:\Users\A\source\repos\TopTazShop\ServiceHost\Views\Shared\Components\BasketComponent\BasketComponent.cshtml"
                                       Write(Model.Total().ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </p>\r\n");
#nullable restore
#line 64 "C:\Users\A\source\repos\TopTazShop\ServiceHost\Views\Shared\Components\BasketComponent\BasketComponent.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </span>\r\n            <span class=\"d-block text-center px-2\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6611065233c1f227b32af9e7fa94b3024c7e6a9313740", async() => {
                WriteLiteral("\r\n                    مشاهده سبد خرید\r\n                    <i class=\"mi mi-ShoppingCart\"></i>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </span>\r\n        </li>\r\n    </ul>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BasketDto> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
