namespace FSharpDemoPresentation_FsMVC5.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Web
open System.Web.Mvc
open System.Web.Mvc.Ajax

type HomeController() =
    inherit Controller()
    member this.Index () = this.View() :> ActionResult

    member this.IndexCategory (title: string) (category: string) = 
        this.ViewData.Add("Title", title)
        this.ViewData.Add("ContentPartialView", "IndexSubCategories/" + category)
        this.View("DemoContent") :> ActionResult

    member this.GetCategory () =
        let title = this.Request.Params.GetValues("title").FirstOrDefault()
        let partialView = "IndexSubCategories/" + this.Request.Params.GetValues("category").FirstOrDefault()
        this.PartialView(partialView) :> ActionResult

    member this.Presentation () = this.View() :> ActionResult
    member this.Contact () = this.View() :> ActionResult
    member this.About () = 
        this.ViewData.Add("Message", "This application is just a presentation of F# programming.")
        this.View() :> ActionResult
