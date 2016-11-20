module ExternalCalling

open MyDll2

// -- main --
let mainExternalCalling () =

    let testDll = new PiRCommon("guy")
    printfn "%s" (testDll.SayHello())
    printfn "Square function Pow(Pi,2) value : %f" (testDll.PiR_2())
    printfn "%s" (testDll.SayBye())