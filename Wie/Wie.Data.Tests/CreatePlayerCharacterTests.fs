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

[<Fact>]
let ``CreatePlayerCharacter.Should create a new player character`` () =
    let subject : DataContext = DataContext()
    subject.OpenWorld(Guid.NewGuid().ToString())
    let expected = subject.GetPlayerCharacters().Count + 1
    subject.CreatePlayerCharacter(Guid.NewGuid().ToString()).ShouldNotBeNull() |> ignore
    let actual = subject.GetPlayerCharacters().Count
    actual.ShouldBe(expected)
    subject.CloseWorld()


[<Fact>]
let ``CreatePlayerCharacter.Should not create a player character when the player character name already exists in the database`` () =
    let subject : DataContext = DataContext()
    subject.OpenWorld(Guid.NewGuid().ToString())
    let name = Guid.NewGuid().ToString()
    subject.CreatePlayerCharacter(name).ShouldNotBeNull() |> ignore
    let expected = subject.GetPlayerCharacters().Count
    subject.CreatePlayerCharacter(name).ShouldBeNull() |> ignore
    let actual = subject.GetPlayerCharacters().Count
    actual.ShouldBe(expected)
    subject.CloseWorld()
    