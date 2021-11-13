namespace Wie
open Wie.Engine
open System

type public Runner() = 
    interface IRunner with
        member this.Run(engine:IEngine) : unit =
            engine.IsRunning()
            |> ignore
        


