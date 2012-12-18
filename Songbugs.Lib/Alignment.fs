namespace Songbugs.Lib

type Alignment(slots : int, elements : int list list) =
  inherit GameObject()
  
  new(slots) = Alignment(slots, [])
  
  member val Slots = slots with get, set
  member val Elements = elements with get, set