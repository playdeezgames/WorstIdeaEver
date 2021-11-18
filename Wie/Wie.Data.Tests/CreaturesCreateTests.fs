module CreaturesCreateTests

open System
open Xunit
open Shouldly
open Wie.Data
open Microsoft.Data.Sqlite

let dummyLocationId: Int64 = 1L
let dummyPlayerCharacterId : Int64 = 2L
let dummySecondLocationId: Int64 = 3L

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
let ``Create(no PC).Should throw when trying to create a second creature at the same location`` () =
    let subject : DataContext = DataContext()
    subject.OpenWorld(Guid.NewGuid().ToString())
    let creatureId = subject.Creatures.Create(dummyLocationId)
    let creature = subject.Creatures.Find(creatureId)
    creature.LocationId.ShouldBe(dummyLocationId)
    creature.PlayerCharacterId.ShouldBeNull()
    Should.Throw<SqliteException>(fun () -> subject.Creatures.Create(dummyLocationId) |> ignore) |> ignore
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

[<Fact>]
let ``Create(with PC).Should throw when trying to create a second creature with the same player character`` () =
    let subject : DataContext = DataContext()
    subject.OpenWorld(Guid.NewGuid().ToString())
    let creatureId = subject.Creatures.Create(dummyLocationId, dummyPlayerCharacterId)
    let creature = subject.Creatures.Find(creatureId)
    creature.LocationId.ShouldBe(dummyLocationId)
    creature.PlayerCharacterId.ShouldBe(dummyPlayerCharacterId)
    Should.Throw<SqliteException>(fun () -> subject.Creatures.Create(dummySecondLocationId, dummyPlayerCharacterId) |> ignore) |> ignore
    subject.CloseWorld();
