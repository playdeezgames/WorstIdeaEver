module OpenWorldTests

open System
open Xunit
open Shouldly
open Wie.Data

[<Fact>]
let ``OpenWorld.Should not throw an exception when opening the world`` () =
    let subject : DataContext = DataContext()
    Should.NotThrow(fun()->subject.OpenWorld(System.Guid.NewGuid().ToString()))
    subject.PlayerCharacters.ShouldNotBeNull() |> ignore


