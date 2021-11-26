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
let ``Create.Should create a creature`` () =
    let subject : DataContext = DataContext()
    subject.OpenWorld(Guid.NewGuid().ToString())
    let creatureId = subject.Creatures.Create(dummyLocationId)
    let creature = subject.Creatures.Find(creatureId)
    creature.LocationId.ShouldBe(dummyLocationId)
    subject.CloseWorld();

[<Fact>]
let ``Create.Should throw when trying to create a second creature at the same location`` () =
    let subject : DataContext = DataContext()
    subject.OpenWorld(Guid.NewGuid().ToString())
    let creatureId = subject.Creatures.Create(dummyLocationId)
    let creature = subject.Creatures.Find(creatureId)
    creature.LocationId.ShouldBe(dummyLocationId)
    Should.Throw<SqliteException>(fun () -> subject.Creatures.Create(dummyLocationId) |> ignore) |> ignore
    subject.CloseWorld();
