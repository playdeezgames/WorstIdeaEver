module LocationsFindTests
open System
open Xunit
open Shouldly
open Wie.Data

let dummyLocationId: Int64 = 1L

[<Fact>]
let ``Find.Should throw an exception when no world is open`` () =
    let subject : DataContext = DataContext()
    Should.Throw<NullReferenceException>(fun()-> subject.Locations.Find(dummyLocationId)|>ignore) |> ignore

[<Fact>]
let ``Find.Should return null when the world is freshly created`` () =
    let subject : DataContext = DataContext()
    subject.OpenWorld(Guid.NewGuid().ToString())
    subject.Locations.Find(dummyLocationId).ShouldBeNull()
    subject.CloseWorld()


