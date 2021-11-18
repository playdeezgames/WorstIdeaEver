module CreaturesFindForPlayerCharacterTests
open System
open Xunit
open Shouldly
open Wie.Data

let dummyPlayerCharacterId: Int64 = 1L

[<Fact>]
let ``Find.Should throw an exception when no world is open`` () =
    let subject : DataContext = DataContext()
    Should.Throw<NullReferenceException>(fun()-> subject.Creatures.FindForPlayerCharacter(dummyPlayerCharacterId)|>ignore) |> ignore

    
[<Fact>]
let ``Find.Should return empty for a newly created world`` () =
    let subject : DataContext = DataContext()
    subject.OpenWorld(Guid.NewGuid().ToString())
    subject.Creatures.FindForPlayerCharacter(dummyPlayerCharacterId).ShouldBeNull()
    subject.CloseWorld()
    