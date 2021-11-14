module GetPlayerCharactersTests

open System
open Xunit
open Shouldly
open Wie.Data

[<Fact>]
let ``GetPlayerCharacters.Should return an empty list on a newly created world``() =
    let subject : DataContext = DataContext()
    subject.OpenWorld(System.Guid.NewGuid().ToString())
    try
        subject
            .GetPlayerCharacters()
            .ShouldNotBeNull()
            .ShouldBeEmpty()
    finally
        subject.CloseWorld()

[<Fact>]
let ``GetPlayerCharacters.Should raise an exception when a world has not been opened``() =
    let subject : DataContext = DataContext()
    Should.Throw<System.NotImplementedException>(fun()->subject.GetPlayerCharacters()|>ignore)
    |> ignore