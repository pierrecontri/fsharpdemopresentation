namespace FSharpDemo1.Model.Company

open System

    // type Person
    type Person =
      class
        val private m_FirstName : string
        val mutable private m_NickName : string
        val private m_Age : uint8 
        val private m_ID : Guid

        [<DefaultValue>] static val mutable private countPerson : uint32

        new(first : string, nickName : string, age : uint8) = 
            {
                m_FirstName = first
                m_NickName = nickName
                m_Age = age
                m_ID = Guid.NewGuid()
            } then Person.countPerson <- Person.countPerson + (uint32) 1

        member this.ID = this.m_ID

        member this.FirstName = this.m_FirstName
        
        member this.NickName
            with get() = this.m_NickName
            and set (value) = this.m_NickName <- value

        member this.Age = this.m_Age

        member p.SayHowdy() =
            Console.WriteLine("{0} says, 'Howdy, all'!", p.FirstName)
        override p.ToString() =
            String.Format("[Person: first={0}, nickname={1}, age={2}]",
                p.FirstName, p.NickName, p.Age)

        static member CreatePerson (firstName : Object, nickName : Object, age : Object) : Person =
            new Person(firstName :?> string, nickName :?> string, uint8 (Convert.ToUInt16(age)))
      end

    // class Employee
    type Employee =
      class
        inherit Person

        new() =
            {
                inherit Person("Anonymous", "Anonymous", (uint8) 0)
            }

        new(first : string, nickName : string, age : uint8) = 
            {
                inherit Person(first, nickName, age)
            }

        new(person : Person) = 
            {
                inherit Person(person.FirstName, person.NickName, person.Age)
            }
      end
 
    // class team leader
    type TeamLeader =
      class
        inherit Employee

        new() =
            {
                inherit Employee("Anonymous", "Anonymous", (uint8) 0)
            }

        new(first : string, nickName : string, age : uint8) = 
            {
                inherit Employee(first, nickName, age)
            }

        new(person : Person) = 
            {
                inherit Employee(person.FirstName, person.NickName, person.Age)
            }
      end

    // comportment
    type IHumanResourcesChief =
        interface
            abstract member Name : string
            abstract member Action : Person -> string -> (Person -> string -> bool) -> bool
        end

    type ISaySomethingToEmploye =
       abstract member Print : Employee -> string -> unit

    type IDynamicSaySomethingToEmploye =
       abstract member Print : unit
       
    // class SuperBoss
    type SuperBoss(person: Person) =
      class
        inherit Person (person.FirstName, person.NickName, person.Age )

        member this.ChiefFunction = "ZoupperChief"
        interface ISaySomethingToEmploye with
          member this.Print employee action = printfn "Hey %s, %s" (employee.FirstName) action
        interface IHumanResourcesChief with
          member this.Name = 
            "MarioBoss"
          member this.Action (person: Person) (comment: string) (op: (Person -> string -> bool)) =
            op person comment
        interface IDynamicSaySomethingToEmploye with 
            member this.Print = ()
      end

    type MotorType =
        class
            val mutable private m_MotorName : string
            new() = { m_MotorName = "Merco" }
            member x.MotorName
                with get() = x.m_MotorName
                and set (value) = x.m_MotorName <- value
        end

    type QualityType =
        class
            val mutable private m_QualityName : string
            new() = { m_QualityName = "Bosch" }
            member x.QualityName
                with get() = x.m_QualityName
                and set(value) = x.m_QualityName <- value
        end

    type CarDescType = 
        class
            val mutable private m_Name : string
            new() = { m_Name = "ClassC" }
            member x.Name
                with get() = x.m_Name
                and set(value) = x.m_Name <- value
        end

    type CarType =
    | Motor of MotorType
    | Quality of QualityType
    | CarDesc of CarDescType


//        override p.ToString() =
//
//            String.Format("[Car: name={0}, quality={1}, motor={2}]",
//                (p |> CarDescType).Name, (p |> QualityType).QualityName , (p |> MotorType).MotorName)