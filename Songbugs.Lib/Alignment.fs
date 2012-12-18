namespace Songbugs.Lib
open Microsoft.Xna.Framework

// Used to order objects on the screen with "slots".
type Alignment(slots : int * int, elements : GameObject [,]) =
  inherit GameObject()
  
  new(slots) = Alignment(slots, Array2D.zeroCreate 0 0)
  
  member val Slots = slots with get, set
  member val Elements = elements with get, set
  
  override this.Draw gameTime =
    Array2D.iter (fun (obj : GameObject) -> obj.Draw gameTime) elements