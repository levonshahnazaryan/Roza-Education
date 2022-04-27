#pragma checksum "C:\Education\Roza-Education\Education\Views\Account\_EducationFile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "357bb76e8a91b350a6d31531926d05afd2b63725"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account__EducationFile), @"mvc.1.0.view", @"/Views/Account/_EducationFile.cshtml")]
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
#line 1 "C:\Education\Roza-Education\Education\Views\Account\_EducationFile.cshtml"
using Education.Models.Account;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"357bb76e8a91b350a6d31531926d05afd2b63725", @"/Views/Account/_EducationFile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e723c65a8a6a54ea9ea7b69d40595e9ea2e7700f", @"/Views/_ViewImports.cshtml")]
    public class Views_Account__EducationFile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EducationVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"clearfix\">\r\n    ");
#nullable restore
#line 5 "C:\Education\Roza-Education\Education\Views\Account\_EducationFile.cshtml"
Write(Html.DevExtreme().FileUploader()
        .SelectButtonText("Ներբեռնել")
        .ID("EduUpFiles")
        .Name("EduUpFiles")
        .Multiple(false)
        //.Accept("image/*")
        .LabelText("")
        .ShowFileList(false)
        .UploadMode(FileUploadMode.Instantly)
        .OnUploaded("function(e){ accountEducationFunctions.uploadFile(e) }")
        .UploadUrl(Url.Action("UploadEducationFile", "Account", new { educationsId = Model.EducationsId })));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<section>\r\n    ");
#nullable restore
#line 19 "C:\Education\Roza-Education\Education\Views\Account\_EducationFile.cshtml"
Write(Html.DevExtreme().DataGrid()
        .ID("EducationFile")
        .Editing(editing =>
        {
            editing.RefreshMode(GridEditRefreshMode.Reshape);
            editing.AllowAdding(false);
            editing.AllowDeleting(true);
            editing.AllowUpdating(false);
            editing.UseIcons(true);
        })
        .Columns(c =>
        {
            c.Add().DataField("FileName").DataType(GridColumnDataType.String).Caption("Անվանում");
        })
        .DataSource(d =>
            d.WebApi().Controller("Account")
            .LoadAction("GetEducationsFile")
            .LoadParams(new { educationsId = Model.EducationsId })
            .DeleteAction("DeleteEducationsFile")
            .Key("EducationsFileId")
        )
        .LoadPanel(m => m.Text("Բեռնվում է․․․"))
        .FilterRow(filterRow => filterRow.Visible(true).ApplyFilter(GridApplyFilterMode.Auto))
        .HeaderFilter(headerFilter => headerFilter.Visible(true))
        .AllowColumnResizing(true)
        .ColumnHidingEnabled(true)
        .ShowBorders(true)
        .Paging(paging => { paging.PageSize(10); })
        .Pager(pager =>
        {
            pager.ShowInfo(true);
            pager.ShowNavigationButtons(true);
            pager.ShowPageSizeSelector(true);
            pager.InfoText("Էջ {0} ({1})");
        }
    )
    .OnCellPrepared("generalFunctions.cellPrepared"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EducationVM> Html { get; private set; }
    }
}
#pragma warning restore 1591