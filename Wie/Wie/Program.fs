open Wie
open Wie.Engine
open Wie.Data

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
    DataContext() :> IDataContext
    |> WieEngine  :> IEngine
    |> (Runner(Inputter(), Outputter()) :> IRunner).Run
    0