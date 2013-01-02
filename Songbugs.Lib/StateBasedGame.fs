namespace Songbugs.Lib
open Microsoft.Xna.Framework

type StateBasedGame() =
  inherit Game()
  
  let mutable screens : GameScreen [] = [||]
  let mutable currentScreen = 0
  let screenChange = new Event<int>()
  
  member this.ScreenChange = screenChange.Publish
  
  abstract CurrentScreen : int with get, set
  override this.CurrentScreen
    with get () = currentScreen
    and set v =
      currentScreen <- v
      screenChange.Trigger v