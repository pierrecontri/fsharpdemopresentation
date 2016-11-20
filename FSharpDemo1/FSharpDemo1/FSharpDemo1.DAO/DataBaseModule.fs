namespace FSharpDemo1.DAO

open System
open System.Configuration
open System.Data
open System.Data.Linq
open System.Collections
open System.Collections.Generic
open System.Xml
open FSharpDemo1.Model.Company
open FSharp.Configuration

type DataBase() = 
        // DataBase Module
        // ---------------

        static let students =
                [
                    new Person("Student1", "NickName1", (uint8)33);
                    new Person("Student2", "NickName2", (uint8)24);
                    new Person("Student3", "NickName3", (uint8)20)
                ]

        static let people =
                [
                    new Person("Person1", "NickName1", (uint8)33);
                    new Person("Person2", "NickName2", (uint8)24);
                    new Person("Person3", "NickName3", (uint8)51)
                ]

        static let multipleSuperMario =
                [
                    new Person("Boss1", "ZouperBosse1", (uint8)69);
                    new Person("Boss2", "ZouperBosse2", (uint8)46);
                    new Person("ZouperMario3", "Plombier", (uint8)1664);
                    new Person("ZouperMario4", "Brasseur", (uint8)1664)
                ]

        static let numericData =
                [|84683.0; 937.29; 37.0; 02893.0; 01320.6; 873.94349|]

        static let DbSet =
                let mutable dbFilePath = ""
                let ds = new DataSet()
                try
                    dbFilePath <- AppSettings<"FSharpDemo1.DAO.dll.config">.DbPathFile
                    if System.IO.File.Exists(dbFilePath) then
                        ds.ReadXml(dbFilePath, XmlReadMode.Auto) |> ignore
                with
                    | _ -> ()
                ds
        static let dataBase = DbSet

        static member NumericData = 
            if dataBase.Tables.Contains("NumericData") then
                let tbl = dataBase.Tables.["NumericData"].Rows
                            |> Seq.cast<DataRow>
                query {
                        for dbRow in tbl do
                        select ( dbRow.["num"].ToString() )
                    }
                    |> Seq.map(fun strNum -> float (Double.Parse(strNum, System.Globalization.CultureInfo.InvariantCulture)) )
                    |> Seq.toArray
            else
                numericData

        static member People = 
            if dataBase.Tables.Contains("People") then
                let tbl = dataBase.Tables.["People"].Rows
                            |> Seq.cast<DataRow>
                query {
                        for dbRow in tbl do
                        select ( new Person(dbRow.["first"] :?> string,
                                            dbRow.["nickName"] :?> string,
                                            uint8 (Convert.ToUInt16(dbRow.["age"].ToString())) )
                               )
                    }
                    |> Seq.toList
            else
                people

        static member Students = 
            if dataBase.Tables.Contains("Student") then
                let tbl = dataBase.Tables.["Student"].Rows
                            |> Seq.cast<DataRow>
                query {
                        for dbRow in tbl do
                        select ( new Person(dbRow.["first"] :?> string,
                                            dbRow.["nickName"] :?> string,
                                            uint8 (Convert.ToUInt16(dbRow.["age"].ToString())) )
                               )
                    }
                    |> Seq.toList
            else
                students

        static member MultipleSuperMario =
            if dataBase.Tables.Contains("MultipleSuperMario") then
                let tbl = dataBase.Tables.["MultipleSuperMario"].Rows
                            |> Seq.cast<DataRow>
                query {
                        for dbRow in tbl do
                        select ( new Person(dbRow.["first"] :?> string,
                                            dbRow.["nickName"] :?> string,
                                            uint8 (Convert.ToUInt16(dbRow.["age"].ToString())))
                               )
                    }
                    |> Seq.toList
            else
                multipleSuperMario