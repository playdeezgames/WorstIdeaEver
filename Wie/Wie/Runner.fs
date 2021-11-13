namespace Wie
open Wie.Engine
open System

type public Runner(inputter: IInputter, outputter:IOutputter) = 
    interface IRunner with
        member this.Run(engine:IEngine) : unit =
            while engine.IsRunning() do
                engine.ReceiveOutput()
                |> outputter.Write
                engine.SendInput(inputter.Read())
