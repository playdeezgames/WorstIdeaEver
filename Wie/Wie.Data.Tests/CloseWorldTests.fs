module CloseWorldTests

open System
open Xunit
open Shouldly
open Wie.Data

[<Fact>]
let ``CloseWorld.Should not throw an exception when closing a world``()=
    let subject : DataContext = DataContext()
    Should.NotThrow(fun()->subject.CloseWorld())
    subject.PlayerCharacterId.ShouldBeNull() |> ignore
    subject.PlayerCharacters.ShouldBeNull() |> ignore

