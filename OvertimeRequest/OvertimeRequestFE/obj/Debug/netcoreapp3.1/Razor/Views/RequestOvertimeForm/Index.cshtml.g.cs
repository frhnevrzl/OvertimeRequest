#pragma checksum "D:\Project\OvertimeRequest\OvertimeRequest\OvertimeRequestFE\Views\RequestOvertimeForm\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "782f637d75d903784ee8b0741ea735686ec577ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RequestOvertimeForm_Index), @"mvc.1.0.view", @"/Views/RequestOvertimeForm/Index.cshtml")]
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
#line 1 "D:\Project\OvertimeRequest\OvertimeRequest\OvertimeRequestFE\Views\_ViewImports.cshtml"
using OvertimeRequestFE;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\OvertimeRequest\OvertimeRequest\OvertimeRequestFE\Views\_ViewImports.cshtml"
using OvertimeRequestFE.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"782f637d75d903784ee8b0741ea735686ec577ee", @"/Views/RequestOvertimeForm/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cff5b31e72707618e4e7b803b2460c2694ccb082", @"/Views/_ViewImports.cshtml")]
    public class Views_RequestOvertimeForm_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formovertime"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("tableRequestOvertime"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/RequestOvertime.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Project\OvertimeRequest\OvertimeRequest\OvertimeRequestFE\Views\RequestOvertimeForm\Index.cshtml"
  
    Layout = "~/Views/Shared/AdminLTE/_Layout2.cshtml";
    ViewData["NIP"] = @ViewBag.sessionNip;
    ViewData["Email"] = @ViewBag.sessionEmail;
    ViewData["FirstName"] = @ViewBag.sessionFName;
    ViewData["LastName"] = @ViewBag.sessionLName;

#line default
#line hidden
#nullable disable
            WriteLiteral("<input id=\"nips\" style=\"display:none\"");
            BeginWriteAttribute("value", " value=\"", 296, "\"", 320, 1);
#nullable restore
#line 8 "D:\Project\OvertimeRequest\OvertimeRequest\OvertimeRequestFE\Views\RequestOvertimeForm\Index.cshtml"
WriteAttributeValue("", 304, ViewData["NIP"], 304, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n<input id=\"emails\" style=\"display:none\"");
            BeginWriteAttribute("value", " value=\"", 363, "\"", 389, 1);
#nullable restore
#line 9 "D:\Project\OvertimeRequest\OvertimeRequest\OvertimeRequestFE\Views\RequestOvertimeForm\Index.cshtml"
WriteAttributeValue("", 371, ViewData["Email"], 371, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n<div class=\"card card-default\">\r\n    <div class=\"card-header\">\r\n        <h3 class=\"card-title text-center\" style=\"color:black\"><b>Overtime Request Form</b></h3>\r\n    </div>\r\n    <div class=\"card-header\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "782f637d75d903784ee8b0741ea735686ec577ee6498", async() => {
                WriteLiteral("\r\n            <table width=\"80%\">\r\n                <thead>\r\n                    <tr style=\"display:none\">\r\n                        <th><label for=\"id\">NIP</label></th>\r\n                        <th><input");
                BeginWriteAttribute("value", " value=\"", 843, "\"", 851, 0);
                EndWriteAttribute();
                WriteLiteral(" id=\"nip\" class=\"form-control\" name=\"nip\"></th>\r\n                        <th>\r\n                    </tr>\r\n                    <tr>\r\n                        <th><label for=\"name\">Overtime Title</label></th>\r\n                        <th><input");
                BeginWriteAttribute("value", " value=\"", 1093, "\"", 1101, 0);
                EndWriteAttribute();
                WriteLiteral(@" id=""overtimeTitle"" class=""form-control"" name=""overtimeTitle""></th>
                    </tr>
                    <tr>
                        <th><label for=""subdate"">Submission Date</label></th>
                        <th><input type=""date"" id=""date"" class=""form-control"" name=""date""></th>
                    </tr>
                </thead>
            </table>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <br />\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "782f637d75d903784ee8b0741ea735686ec577ee9099", async() => {
                WriteLiteral(@"
            <div class=""row"">
                <div class=""col-3"">
                    <div class=""form-group"">
                        <label for=""starttime"">Start Time</label><br>
                        <input type=""time"" id=""stime"" class=""form-control"" name=""stime"">
                    </div>
                </div>
                <div class=""col-3"">
                    <div class=""form-group"">
                        <label for=""endtime"">End Time</label><br>
                        <input type=""time"" id=""etime"" class=""form-control"" name=""etime"">
                    </div>
                </div>
                <div class=""col-4"">
                    <div class=""form-group"">
                        <label for=""task"">Overtime Details</label><br>
                        <input style=""height:100px"" type=""text"" id=""task"" class=""form-control"" name=""task"">
                    </div>
                </div>
                <div class=""col-1"" style=""margin-top:30px;"">
                    <butt");
                WriteLiteral(@"on type=""button"" class=""btn btn-primary"" onclick=""AddListOvertime()"">Add</button>
                </div>
                <div hidden>
                    <label for=""addsalary"">Additional Salary:</label><br>
                    <input type=""text"" id=""addsalary"" name=""addsalary"">
                </div>
                <div hidden>
                    <label for=""overtimeformid"">OvertimeForm Id: </label><br>
                    <input type=""text"" id=""overtimeformid"" name=""overtimeformid"">
                </div>
            </div>
            <div id=""overtimeLimit"" style=""color: red; font-size: 15px; display: none;"">Quota of overtime per day should not exceed 3 hours!!</div>
            <div class=""row"" style=""width:25%"">
");
                WriteLiteral("            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "782f637d75d903784ee8b0741ea735686ec577ee12283", async() => {
                WriteLiteral(@"
            <div class=""container-fluid mt-3"">
                <table id=""mytables"" class=""table table-striped table-bordered"" style=""width:90%"">
                    <thead>
                        <tr>
                            <th>No</th>
                            <th>Start Time</th>
                            <th>End Time</th>
                            <th>Details</th>
");
                WriteLiteral(@"                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody id=""bodyTableRequest""></tbody>
                    <tfoot>
                        <tr>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th></th>
");
                WriteLiteral(@"                        </tr>
                    </tfoot>
                </table>
            </div>
            <div style=""text-align:center; margin-right:30px;"">
                <button type=""button"" class=""btn btn-primary"" onclick=""AddOvertimeForm()"">Submit</button>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    <script src=\"https://momentjs.com/downloads/moment.js\"></script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "782f637d75d903784ee8b0741ea735686ec577ee15003", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 110 "D:\Project\OvertimeRequest\OvertimeRequest\OvertimeRequestFE\Views\RequestOvertimeForm\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
