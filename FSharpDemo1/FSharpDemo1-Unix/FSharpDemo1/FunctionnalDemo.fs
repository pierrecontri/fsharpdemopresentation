module FunctionnalDemo

open System
open FSharpDemo1.Model.Company
open FSharpDemo1.DAO

// ----- Total age -----
let mutable totalAge1 = (uint16)0
for p in DataBase.People do
    totalAge1 <- totalAge1 + (uint16)p.Age;
// -------------
let addAges (currentTotal : uint16) (p : Person) = currentTotal + (uint16)p.Age
let iterateAndSum (people : Person list) =
    let mutable totalAge = (uint16)0
    for p in people do
        totalAge <- addAges totalAge p
    totalAge
// -------------
let addAges2 (currentTotal : uint16) (p : Person) = currentTotal + (uint16)p.Age
let iterateAndOperate (people : Person list) (op: uint16 -> Person -> uint16) =
    let mutable totalAge = (uint16) 0
    for p in people do
        totalAge <- op totalAge p
    totalAge
 
let totalAge2 = iterateAndOperate DataBase.People addAges2
// ---------------------
let iterateAndOperate2 (seed : 'b) (coll : 'a list) (op : ('b -> 'a -> 'b)) =
    let mutable total = seed
    for it in coll do
        total <- op total it
    total
 
let totalAge3 = iterateAndOperate2 ((uint16)0) DataBase.People addAges2

// ----- XML transform -----
let personToXML (currentXML : string) (p : Person) =
    currentXML + "\n  <person>" + p.FirstName + "</person>"
let peopleXML = (iterateAndOperate2 "<people>" DataBase.People personToXML) + "\n</people>"

// ---------------
// fun : function in line

let peopleXML2 =
    (iterateAndOperate2 "<people>" DataBase.People
        (fun (curr : string) (p : Person) ->
            curr + "\n  <person>" + p.FirstName + "</person>")) + "\n</people>"

// --------------

let peopleXML3 = (List.fold (fun (curr) (p : Person) ->
                        curr + "\n  <person>" + p.FirstName + "</person>")
                    "<people>" DataBase.People) + "\n</people>"

// -- main --
let mainFunctionnalProgramming () =
    printfn "Sample data : \n%A\n" DataBase.People
    printfn "Total age for people list : %d\n" totalAge3
    printfn "Transform list to xml string :\n%s\n" peopleXML3
    ()