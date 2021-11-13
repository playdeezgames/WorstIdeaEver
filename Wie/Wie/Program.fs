open Wie
open Wie.Engine
type Inputter() =
    interface IInputter with
        member this.Read() = System.Console.ReadLine()

type Outputter() =
    interface IOutputter with
        member this.Write(lines : string seq) =
            lines
            |> Seq.iter System.Console.WriteLine

[<EntryPoint>]
let main _ =
    let runner:IRunner = Runner(Inputter(), Outputter()) :> IRunner
    let engine:IEngine = WieEngine() :> IEngine
    runner.Run(engine)
    0