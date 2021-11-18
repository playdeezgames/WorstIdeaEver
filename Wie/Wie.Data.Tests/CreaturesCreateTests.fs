module CreaturesCreateTests

open System
open Xunit
open Shouldly
open Wie.Data

let dummyLocationId: Int64 = 1L
let dummyPlayerCharacterId : Int64 = 2L

[<Fact>]
let ``Create(no PC).Should throw an exception when no world is open`` () =
    let subject : DataContext = DataContext()
    Should.Throw<NullReferenceException>(fun()-> subject.Creatures.Create(dummyLocationId)|>ignore) |> ignore

[<Fact>]
let ``Create(no PC).Should create a creature`` () =
    let subject : DataContext = DataContext()
    subject.OpenWorld(Guid.NewGuid().ToString())
    let creatureId = subject.Creatures.Create(dummyLocationId)
    let creature = subject.Creatures.Find(creatureId)
    creature.LocationId.ShouldBe(dummyLocationId)
    creature.PlayerCharacterId.ShouldBeNull()
    subject.CloseWorld();

[<Fact>]
let ``Create(with PC).Should throw an exception when no world is open`` () =
    let subject : DataContext = DataContext()
    Should.Throw<NullReferenceException>(fun()-> subject.Creatures.Create(dummyLocationId, dummyPlayerCharacterId)|>ignore) |> ignore

[<Fact>]
let ``Create(with PC).Should create a creature`` () =
    let subject : DataContext = DataContext()
    subject.OpenWorld(Guid.NewGuid().ToString())
    let creatureId = subject.Creatures.Create(dummyLocationId, dummyPlayerCharacterId)
    let creature = subject.Creatures.Find(creatureId)
    creature.LocationId.ShouldBe(dummyLocationId)
    creature.PlayerCharacterId.ShouldBe(dummyPlayerCharacterId)
    subject.CloseWorld();
