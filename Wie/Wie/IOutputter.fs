namespace Wie

type IOutputter =
    abstract member Write : string seq -> unit