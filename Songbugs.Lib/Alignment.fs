namespace Songbugs.Lib
open Microsoft.Xna.Framework

// Used to order objects on the screen with "slots".
type Alignment(slots : int * int, elements : int list list) =
  inherit GameObject()
  
  new(slots) = Alignment(slots, [])
  
  member val Slots = slots with get, set
  member val Elements = elements with get, set