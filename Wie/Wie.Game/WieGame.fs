namespace Wie.Game

type WieGame() =
    let mutable _playerCharacterId : int64 option = None
    interface IGame with
        member this.PlayerCharacterId
            with get (): int64 option = 
                _playerCharacterId
            and set (v: int64 option): unit = 
                _playerCharacterId <- v

