module ChaptersData
// Chapter data
// ------------

let mutable keyChapterList = seq []

/// <summary>Print the summary by using the keys from the chapters' dictionnary</summary>
/// no params, no return, just print on the standard output the chapter list
let Summary() =

    keyChapterList |> Seq.iteri
            (
                fun countChapter chapterTitleTmp -> 
                    match countChapter with
                        | 0 -> ()
                        | _ -> printfn "%d) %s" countChapter chapterTitleTmp
            )

/// Dictionnary for all chapters
/// Key   : chapter name
/// Value : function name of submain chapter
let chapterList = dict
                    [
                        ("Summary", Summary); // Summary
                        ("Introduction", Comments.Introduction); // Introduction
                        ("Object Oriented Programming", ObjectOrientedProgramming.mainHello); // Hello program
                        ("Calling external dll (.Net)", ExternalCalling.mainExternalCalling); // Calling external dll (.Net)
                        ("Functionnal Programming", FunctionnalDemo.mainFunctionnalProgramming); // Functionnal programming
                        ("Linq Functionnal Demo", LinqDemo.mainLinqDemo); // Linq Functionnal Demo
                        ("Conclusion", Comments.Conclusion) // Conclusion and Tahnk you
                    ]

keyChapterList <- seq chapterList.Keys
let dictLength = chapterList.Count