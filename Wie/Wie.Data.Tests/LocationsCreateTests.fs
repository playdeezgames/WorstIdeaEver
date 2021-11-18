module LocationsCreateTests
open System
open Xunit
open Shouldly
open Wie.Data

let dummyX: int = 1
let dummyY: int = 2
let dummyZ: int = 3

[<Fact>]
let ``Create.Should throw an exception when no world is open`` () =
    let subject : DataContext = DataContext()
    Should.Throw<NullReferenceException>(fun()-> subject.Locations.Create(dummyX, dummyY, dummyZ)|>ignore) |> ignore

    
[<Fact>]
let ``Create.Should create a location`` () =
    let subject : DataContext = DataContext()
    subject.OpenWorld(Guid.NewGuid().ToString())
    let locationId = subject.Locations.Create(dummyX, dummyY, dummyZ)
    let location = subject.Locations.Find(locationId)
    location.X.ShouldBe(dummyX)
    location.Y.ShouldBe(dummyY)
    location.Z.ShouldBe(dummyZ)
    subject.CloseWorld()