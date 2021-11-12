namespace Wie
open Wie.Engine

type public IRunner =
    abstract member Run: IEngine -> unit

