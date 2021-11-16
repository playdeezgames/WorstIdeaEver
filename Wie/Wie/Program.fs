open Wie
open Wie.Engine
open Wie.Data
open Wie.Game

type Inputter() =
    interface IInputter with
        member this.Read() = 
            System.Console.WriteLine()
            System.Console.Write(">")
            System.Console.ReadLine()

type Outputter() =
    interface IOutputter with
        member this.Write(lines : string seq) =
            lines
            |> Seq.iter System.Console.WriteLine

[<EntryPoint>]
let main _ =
    (
        DataContext() :> IDataContext, 
        WieGame() :> IGame
    )
    |> WieEngine  :> IEngine
    |> (Runner(Inputter(), Outputter()) :> IRunner).Run
    0