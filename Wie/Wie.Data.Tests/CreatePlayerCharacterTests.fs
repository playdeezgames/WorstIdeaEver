module CreatePlayerCharacterTests
open System
open Xunit
open Shouldly
open Wie.Data

[<Fact>]
let ``CreatePlayerCharacter.Should throw an exception when no world is open`` () =
    let subject : DataContext = DataContext()
    Should.Throw<NotImplementedException>(fun()-> subject.CreatePlayerCharacter(Guid.NewGuid().ToString())|>ignore) |> ignore

    
[<Fact>]
let ``CreatePlayerCharacter.Should throw an exception with an empty name`` () =
    let subject : DataContext = DataContext()
    subject.OpenWorld(Guid.NewGuid().ToString())
    Should.Throw<ArgumentException>(fun()-> subject.CreatePlayerCharacter("    ") |> ignore) |> ignore
    subject.CloseWorld()
    