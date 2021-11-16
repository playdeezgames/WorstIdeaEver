namespace Wie
open Wie.Engine

type public Runner(inputter: IInputter, outputter:IOutputter) = 
    interface IRunner with
        member this.Run(engine:IEngine) : unit =
            while engine.IsRunning() do
                engine.ShowState()
                |> outputter.Write
                inputter.Read()
                |> engine.HandleInput
                |> outputter.Write
