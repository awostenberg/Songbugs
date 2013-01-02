namespace Songbugs.Lib
open Microsoft.Xna.Framework

type StateBasedGame() =
  inherit Game()
  
  let mutable screens : GameScreen [] = [||]
  let screenChange = new Event<int>()
  
  member this.ScreenChange = screenChange.Publish
  
  abstract Screens : GameScreen [] with get, set
  override this.Screens
    with get () = screens
    and set v = screens <- v