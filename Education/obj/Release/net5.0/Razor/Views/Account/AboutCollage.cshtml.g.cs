#pragma checksum "C:\Education\Roza-Education\Education\Views\Account\AboutCollage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37f30dc9c4aa152932151943ea18476a9ca47411"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_AboutCollage), @"mvc.1.0.view", @"/Views/Account/AboutCollage.cshtml")]
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
#line 1 "C:\Education\Roza-Education\Education\Views\_ViewImports.cshtml"
using Education;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Education\Roza-Education\Education\Views\_ViewImports.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Education\Roza-Education\Education\Views\Account\AboutCollage.cshtml"
using Education.Models.Account;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37f30dc9c4aa152932151943ea18476a9ca47411", @"/Views/Account/AboutCollage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e723c65a8a6a54ea9ea7b69d40595e9ea2e7700f", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_AboutCollage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AboutCollageVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("autocomplete", new global::Microsoft.AspNetCore.Html.HtmlString("off"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return aboutCollageFunctions.updateContent(event, this);"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Education\Roza-Education\Education\Views\Account\AboutCollage.cshtml"
  
    Layout = "_LayoutAdmin";
    ViewData["Title"] = "Գրադարան";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "37f30dc9c4aa152932151943ea18476a9ca474114415", async() => {
                WriteLiteral("\r\n    <div class=\"tab-container\">\r\n        <div class=\"button-box-start\">\r\n            ");
#nullable restore
#line 12 "C:\Education\Roza-Education\Education\Views\Account\AboutCollage.cshtml"
        Write(Html.DevExtreme()
                .Button()
                .Text("Կից Ֆայլեր")
                .Icon("folder")
                .UseSubmitBehavior(false)
                .OnClick("function(e) { aboutCollageFunctions.openAboutFiles(e) }"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"button-box-end\">\r\n            ");
#nullable restore
#line 20 "C:\Education\Roza-Education\Education\Views\Account\AboutCollage.cshtml"
        Write(Html.DevExtreme()
                .Button()
                .Text("Խմբագրել")
                .Icon("save")
                .UseSubmitBehavior(true));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"input-box\">\r\n            ");
#nullable restore
#line 27 "C:\Education\Roza-Education\Education\Views\Account\AboutCollage.cshtml"
        Write(Html.DevExtreme().HtmlEditor()
                .Content(Model.GetAboutCollage.UContent)
                .ID("description-content")
                .Name("description-content")
                .Height(700)
                .Toolbar(toolbar => toolbar.Items(
                items =>
                {
                    items.Add().Name(HtmlEditorToolbarItem.Undo);
                    items.Add().Name(HtmlEditorToolbarItem.Redo);
                    items.Add().Name(HtmlEditorToolbarItem.Separator);
                    items.Add()
                        .Name("size")
                        .AcceptedValues(new[] { "8pt", "10pt", "12pt", "14pt", "18pt", "24pt", "36pt" });
                    items.Add()
                        .Name("font")
                        .AcceptedValues(new[] { "Arial", "Courier New", "Georgia", "Impact", "Lucida Console", "Tahoma", "Times New Roman", "Verdana" });
                    items.Add().Name(HtmlEditorToolbarItem.Separator);
                    items.Add().Name(HtmlEditorToolbarItem.Bold);
                    items.Add().Name(HtmlEditorToolbarItem.Italic);
                    items.Add().Name(HtmlEditorToolbarItem.Strike);
                    items.Add().Name(HtmlEditorToolbarItem.Underline);
                    items.Add().Name(HtmlEditorToolbarItem.Separator);
                    items.Add().Name(HtmlEditorToolbarItem.AlignLeft);
                    items.Add().Name(HtmlEditorToolbarItem.AlignCenter);
                    items.Add().Name(HtmlEditorToolbarItem.AlignRight);
                    items.Add().Name(HtmlEditorToolbarItem.AlignJustify);
                    items.Add().Name(HtmlEditorToolbarItem.Separator);
                    items.Add().Name(HtmlEditorToolbarItem.OrderedList);
                    items.Add().Name(HtmlEditorToolbarItem.BulletList);
                    items.Add().Name(HtmlEditorToolbarItem.Separator);
                    items.Add()
                        .Name("header")
                        .AcceptedValues(new JS("[false, 1, 2, 3, 4, 5]"));
                    items.Add().Name(HtmlEditorToolbarItem.Separator);
                    items.Add().Name(HtmlEditorToolbarItem.Color);
                    items.Add().Name(HtmlEditorToolbarItem.Background);
                    items.Add().Name(HtmlEditorToolbarItem.Separator);
                    items.Add().Name(HtmlEditorToolbarItem.Link);
                    items.Add().Name(HtmlEditorToolbarItem.Image);
                    items.Add().Name(HtmlEditorToolbarItem.Separator);
                    items.Add().Name(HtmlEditorToolbarItem.Clear);
                    items.Add().Name(HtmlEditorToolbarItem.CodeBlock);
                    items.Add().Name(HtmlEditorToolbarItem.Blockquote);
                    items.Add().Name(HtmlEditorToolbarItem.Separator);
                    items.Add().Name(HtmlEditorToolbarItem.InsertTable);
                    items.Add().Name(HtmlEditorToolbarItem.DeleteTable);
                    items.Add().Name(HtmlEditorToolbarItem.InsertRowAbove);
                    items.Add().Name(HtmlEditorToolbarItem.InsertRowBelow);
                    items.Add().Name(HtmlEditorToolbarItem.DeleteRow);
                    items.Add().Name(HtmlEditorToolbarItem.InsertColumnLeft);
                    items.Add().Name(HtmlEditorToolbarItem.InsertColumnRight);
                    items.Add().Name(HtmlEditorToolbarItem.DeleteColumn);
                })).MediaResizing(m => m.Enabled(true)));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
#nullable restore
#line 9 "C:\Education\Roza-Education\Education\Views\Account\AboutCollage.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Antiforgery = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-antiforgery", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Antiforgery, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 9 "C:\Education\Roza-Education\Education\Views\Account\AboutCollage.cshtml"
                                                                Write(Model.GetAboutCollage.AboutCollageId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-aboutcollageid", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 84 "C:\Education\Roza-Education\Education\Views\Account\AboutCollage.cshtml"
Write(Html.DevExtreme().Popup()
        .ID("pp_AboutFiles")
        .ElementAttr("class", "popup")
        .ShowTitle(true)
        .Title("Կից ֆայլեր")
        .Visible(false)
        .DragEnabled(false)
        .ShowCloseButton(true)
        .Height(600)
        .Width(500)
        .ContentTemplate(new TemplateName("tplAboutFiles"))
    );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 96 "C:\Education\Roza-Education\Education\Views\Account\AboutCollage.cshtml"
 using (Html.DevExtreme().NamedTemplate("tplAboutFiles"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 98 "C:\Education\Roza-Education\Education\Views\Account\AboutCollage.cshtml"
Write(Html.DevExtreme().ScrollView().Content("<div data-partial='AboutFile'></div>"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 98 "C:\Education\Roza-Education\Education\Views\Account\AboutCollage.cshtml"
                                                                                     
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AboutCollageVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
