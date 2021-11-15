module PlayerCharactersAllTests

open System
open Xunit
open Shouldly
open Wie.Data

[<Fact>]
let ``All.Should return an empty list on a newly created world``() =
    let subject : DataContext = DataContext()
    subject.OpenWorld(System.Guid.NewGuid().ToString())
    try
        subject
            .PlayerCharacters.All
            .ShouldNotBeNull()
            .ShouldBeEmpty()
    finally
        subject.CloseWorld()

[<Fact>]
let ``All.Should raise an exception when a world has not been opened``() =
    let subject : DataContext = DataContext()
    Should.Throw<System.NullReferenceException>(fun()->subject.PlayerCharacters.All|>ignore)
    |> ignore
