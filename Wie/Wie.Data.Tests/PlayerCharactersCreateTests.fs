module PlayerCharactersCreateTests
open System
open Xunit
open Shouldly
open Wie.Data

[<Fact>]
let ``Create.Should throw an exception when no world is open`` () =
    let subject : DataContext = DataContext()
    Should.Throw<NullReferenceException>(fun()-> subject.PlayerCharacters.Create(Guid.NewGuid().ToString())|>ignore) |> ignore
    
[<Fact>]
let ``Create.Should throw an exception with an empty name`` () =
    let subject : DataContext = DataContext()
    subject.OpenWorld(Guid.NewGuid().ToString())
    Should.Throw<ArgumentException>(fun()-> subject.PlayerCharacters.Create("    ") |> ignore) |> ignore
    subject.CloseWorld()

[<Fact>]
let ``Create.Should create a new player character`` () =
    let subject : DataContext = DataContext()
    subject.OpenWorld(Guid.NewGuid().ToString())
    let expected = subject.PlayerCharacters.All.Count + 1
    subject.PlayerCharacters.Create(Guid.NewGuid().ToString()).ShouldNotBeNull() |> ignore
    let actual = subject.PlayerCharacters.All.Count
    actual.ShouldBe(expected)
    subject.CloseWorld()


[<Fact>]
let ``Create.Should not create a player character when the player character name already exists in the database`` () =
    let subject : DataContext = DataContext()
    subject.OpenWorld(Guid.NewGuid().ToString())
    let name = Guid.NewGuid().ToString()
    subject.PlayerCharacters.Create(name).ShouldNotBeNull() |> ignore
    let expected = subject.PlayerCharacters.All.Count
    subject.PlayerCharacters.Create(name).ShouldBeNull() |> ignore
    let actual = subject.PlayerCharacters.All.Count
    actual.ShouldBe(expected)
    subject.CloseWorld()
    