module ObjectOrientedProgramming

open Microsoft.FSharp.Collections
open System
open System.Collections.Generic
open FSharpDemo1.Model.Company
open FSharpDemo1.DAO

// return "Hello World"
let returnHelloWorld =
    "Hello World !"

let SayHello(name: string) =
        if not(System.String.IsNullOrEmpty(name)) then
            String.Format("Hello {0} !", name)
        else
            returnHelloWorld

// Iteration sur Sequence ( {1, 2, 3, 4} )
let mySeq = [|1; 2; 3; 4|]
let mySeq2 = mySeq
                |> Seq.filter(fun num -> (num % 2) = 0 )
                |> Seq.iter(fun num -> printfn "%d" num)


// -- main --
let mainHello () =

    // Say hello team // with tuple
    printfn "%s" (SayHello "Team DotNet and SharePoint")

    /// Create person (with C# philosophie)
    let people = new List<Person>()
    people.Add(new Employee("Person1", "NickName1", (uint8)33))
    people.Add(new Employee("Person2", "NickName2", (uint8)24))
    people.Add(new TeamLeader("Person3", "NickName3", (uint8)29))
    // let people = DataBase.People

    people.[1].SayHowdy()
    printfn "Person2's ID : %s" (people.[1].ID.ToString())

    /// Print Object
    printfn "Print Object :\n %O" people
    // Print Array
    printfn "Print Array :\n%A" people
    
    /// Print NickName
    printfn "Print Nickname list :"
    for tty in people do 
        Console.WriteLine(tty.NickName)

    /// Play with class
    printfn """Play with class :"""
    let superBoss1 = DataBase.MultipleSuperMario |> Seq.nth 0
    let superBoss2 = new SuperBoss(superBoss1)

    /// Get the second employ (on the sequence)
    let employeeSelected = (Employee (people |> Seq.nth(1)))

    /// Use the ISaySomethingToEmploye interface (need to cast object explicitly)
    (superBoss2 :> ISaySomethingToEmploye).Print employeeSelected " You're a good guy !! "

    /// Use the IDynamicSaySomethingToEmploye
    /// Result is nothing, because this interface is empty
    (superBoss2 :> IDynamicSaySomethingToEmploye).Print

    /// Implement interface IDynamicSaySomethingToEmploye
    /// on an instancianted object
    let superMarioBoss3 = {new SuperBoss(DataBase.MultipleSuperMario |> Seq.nth 2)  
                                    interface IDynamicSaySomethingToEmploye with
                                        member this.Print = printfn "Hello Employes !"
                                    end
                          }
                          
    /// Print the dynamic instanciation of the interface
    (superMarioBoss3 :> IDynamicSaySomethingToEmploye).Print 

    /// Create a new boss
    let superMarioBoss4 = new SuperBoss(DataBase.MultipleSuperMario |> Seq.nth 3)
    /// The dynamic instancation of the interface is empty again
    (superMarioBoss4 :> IDynamicSaySomethingToEmploye).Print
                  

    ()