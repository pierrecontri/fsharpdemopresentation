// Learn more about F# at http://fsharp.net. See the 'F# Tutorial' project
// for more guidance on F# programming.

#load "Company.fs";;
open FSharpDemo1.Model.Company;;

// Define your library scripting code here

let mutable marioBoss = new Person("Mario", "Boss", (uint8)59);;
let marioBoss2 = {new SuperBoss(marioBoss)
                    interface IDynamicSaySomethingToEmploye with
                        member this.Print = 
                            base.NickName <- "Le Mario"
                            printfn "Hey, I'm %s, my nickname is %s." base.FirstName base.NickName
                    end
             };;

(marioBoss2 :> IDynamicSaySomethingToEmploye).Print;;


let motorCar = new MotorType();;
motorCar.MotorName <- "Renault";;

let qualityCar = new QualityType();;
qualityCar.QualityName <- "Bosch";;

let carName = new CarDescType();;
carName.Name = "ClassA";;
