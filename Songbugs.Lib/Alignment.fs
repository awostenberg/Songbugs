namespace Songbugs.Lib
open Microsoft.Xna.Framework

// Used to order objects on the screen with "slots"
type Alignment(width: int, height : int, elements : GameObject [,]) =
  inherit GameObject()
  
  let elementsDo action = Array2D.iter action elements
  
  new(width, height) = Alignment(width, height, Array2D.zeroCreate 0 0)
  
  // Not in terms of pixels, but slots
  member val Width = width with get, set
  // Not in terms of pixels, but slots
  member val Height = height with get, set
  member val Elements = elements with get, set
  
  member this.Add elem x y = Array2D.set elements x y elem
  
  override this.Initialize () = elementsDo (fun obj -> obj.Initialize ())
  
  override this.LoadContent () = elementsDo (fun obj -> obj.LoadContent ())
  
  override this.Update gameTime = elementsDo (fun obj -> obj.Update gameTime)
  
  override this.Draw gameTime = elementsDo (fun obj -> obj.Draw gameTime)