open System


[<EntryPoint>]
let main argv = 

    Console.Clear()

    let mutable pageNum = 0

    while ( pageNum >= 0 ) do
        // get chapter into the dictionnary
        let chapterSelection = ChaptersData.chapterList |> Seq.nth(pageNum)
        
        // Head Print
        // ----------
        Console.Title <- "F# Demo" + " / " + chapterSelection.Key
        // Title Print
        // -----------
        printfn "%s\n%s\n" chapterSelection.Key ("-".PadRight(chapterSelection.Key.Length, '-' ))

        // Execute module
        chapterSelection.Value()

        // interact with user : navigate
        pageNum <- PiTools.functionNextSection pageNum ChaptersData.dictLength

    // end
    // ---
    0 // return an integer exit code
