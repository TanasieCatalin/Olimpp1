#pragma checksum "C:\Users\GABI\source\repos\Olimpp\Olimpp\Views\Shared\_Carousel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f63c0d2677e1a64844ae9770405355c46ddea76"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Carousel), @"mvc.1.0.view", @"/Views/Shared/_Carousel.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_Carousel.cshtml", typeof(AspNetCore.Views_Shared__Carousel))]
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
#line 1 "C:\Users\GABI\source\repos\Olimpp\Olimpp\Views\_ViewImports.cshtml"
using Olimpp;

#line default
#line hidden
#line 2 "C:\Users\GABI\source\repos\Olimpp\Olimpp\Views\_ViewImports.cshtml"
using Olimpp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f63c0d2677e1a64844ae9770405355c46ddea76", @"/Views/Shared/_Carousel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5be8033d66ee0b11fb2bf4890218cf0176332f9", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Carousel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 1722, true);
            WriteLiteral(@"
    <div class=""container"">
        <div id=""myCarousel"" class=""carousel slide"" data-ride=""carousel"">
            <!-- Indicators -->
            <ol class=""carousel-indicators"">
                <li data-target=""#myCarousel"" data-slide-to=""0"" class=""active""></li>
                <li data-target=""#myCarousel"" data-slide-to=""1""></li>
                <li data-target=""#myCarousel"" data-slide-to=""2""></li>
            </ol>

            <!-- Wrapper for slides -->
            <div class=""carousel-inner"">
                <div class=""item active"">
                    <img src=""https://www.w3schools.com/bootstrap/ny.jpg"" alt=""Los Angeles"" style=""width:100%;"">
                </div>

                <div class=""item"">
                    <img src=""https://www.w3schools.com/bootstrap/chicago.jpg"" alt=""Chicago"" style=""width:100%;"">
                </div>

                <div class=""item"">
                    <img src=""https://www.w3schools.com/bootstrap/newyork.jpg"" alt=""New york"" style=""width:100%");
            WriteLiteral(@";"">
                </div>
            </div>

            <!-- Left and right controls -->
            <a class=""left carousel-control"" href=""#myCarousel"" data-slide=""prev"">
                <span class=""glyphicon glyphicon-chevron-left""></span>
                <span class=""sr-only"">Previous</span>
            </a>
            <a class=""right carousel-control"" href=""#myCarousel"" data-slide=""next"">
                <span class=""glyphicon glyphicon-chevron-right""></span>
                <span class=""sr-only"">Next</span>
            </a>
        </div>
    </div>


</div>
<div id=""myCarousel"" class=""carousel slide"" data-ride=""carousel"">
        <div class=""carousel-inner"">
");
            EndContext();
#line 42 "C:\Users\GABI\source\repos\Olimpp\Olimpp\Views\Shared\_Carousel.cshtml"
              
                var first = true;
            

#line default
#line hidden
            BeginContext(1788, 12, true);
            WriteLiteral("            ");
            EndContext();
#line 45 "C:\Users\GABI\source\repos\Olimpp\Olimpp\Views\Shared\_Carousel.cshtml"
             foreach (var item in ViewBag.Images)
            {

#line default
#line hidden
            BeginContext(1854, 20, true);
            WriteLiteral("                <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1874, "\"", 1936, 2);
            WriteAttributeValue("", 1882, "carousel-item", 1882, 13, true);
#line 47 "C:\Users\GABI\source\repos\Olimpp\Olimpp\Views\Shared\_Carousel.cshtml"
WriteAttributeValue(" ", 1895, first?Html.Raw("active"):Html.Raw(""), 1896, 40, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1937, 49, true);
            WriteLiteral(">\r\n                    <img class=\"d-block w-100\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1986, "\"", 2004, 1);
#line 48 "C:\Users\GABI\source\repos\Olimpp\Olimpp\Views\Shared\_Carousel.cshtml"
WriteAttributeValue("", 1992, item.images, 1992, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 2005, "\"", 2021, 1);
#line 48 "C:\Users\GABI\source\repos\Olimpp\Olimpp\Views\Shared\_Carousel.cshtml"
WriteAttributeValue("", 2011, item.Name, 2011, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2022, 27, true);
            WriteLiteral(">\r\n                </div>\r\n");
            EndContext();
#line 50 "C:\Users\GABI\source\repos\Olimpp\Olimpp\Views\Shared\_Carousel.cshtml"
                first = false;
              }

#line default
#line hidden
            BeginContext(2098, 556, true);
            WriteLiteral(@"        </div>
        <a class=""carousel-control-prev"" href=""#carouselExampleControls"" role=""button""
           data-slide=""prev"">
            <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
            <span class=""sr-only"">Previous</span>
        </a>
        <a class=""carousel-control-next"" href=""#carouselExampleControls"" role=""button""
           data-slide=""next"">
            <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
            <span class=""sr-only"">Next</span>
        </a>
    </div>

");
            EndContext();
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
