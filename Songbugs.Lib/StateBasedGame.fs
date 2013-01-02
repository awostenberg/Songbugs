namespace Songbugs.Lib
open Microsoft.Xna.Framework

type StateBasedGame() =
  inherit Game()
  
  let mutable screens : GameScreen [] = [||]
  
  abstract Screens : GameScreen [] with get, set
  override this.Screens
    with get () = screens
    and set v = screens <- v