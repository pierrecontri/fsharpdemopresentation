module LinqDemo

open System
open Microsoft.FSharp.Linq
open System.Data
open FSharpDemo1.Model.Company
open FSharpDemo1.DAO

// -- main --
let mainLinqDemo () = 
    printfn "Sample data : %A\n" DataBase.NumericData
    query {
            for number in DataBase.NumericData do
            sortBy number
            lastOrDefault
            }
    |> printfn "LastOrDefault query operator : %f\n\n-----------------------------------\n"

    printfn "Sample data : \n%A\n" DataBase.Students
    printfn "\nExactlyOne query operator."


    /// for exemple, take the Id of the first student in DB
    let foundNickName = (DataBase.Students
                         |> List.head).NickName

    let studentName =
        query {
            for student in DataBase.Students do
            where (student.NickName = foundNickName)
            select (student.FirstName, student.Age)
            exactlyOne
            }

    match studentName with
        | (nameSelected: string, ageSelected: uint8)  ->  printfn "Student with StudentNickName = %s is %s.\nHe is %d years old." foundNickName nameSelected ageSelected