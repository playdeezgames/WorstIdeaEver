module DataContextTests

open System
open Xunit
open Shouldly
open Wie.Data

[<Fact>]
let ``Should not throw an exception when opening the world`` () =
    let subject : DataContext = DataContext()
    Should.NotThrow(fun()->subject.OpenWorld("blah"))

[<Fact>]
let ``Should not throw an exception when closing a world``()=
    let subject : DataContext = DataContext()
    Should.NotThrow(fun()->subject.CloseWorld())
    
