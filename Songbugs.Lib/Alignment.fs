namespace Songbugs.Lib
open Microsoft.Xna.Framework

// Used to order objects on the screen with "slots"
type Alignment(slotWidth: int, slotHeight : int, size : Vector2, elements : Positional [,]) =
  inherit Positional()
  
  let elementsDo action = Array2D.iter action elements
  
  new(slotWidth, slotHeight, size) = Alignment(slotWidth, slotHeight, size, Array2D.zeroCreate slotWidth slotHeight)
  new(slotWidth, slotHeight) = Alignment(slotWidth, slotHeight, Vector2.Zero)
  new() = Alignment(1, 1)
  
  // Not in terms of pixels, but slots
  member val SlotWidth = slotWidth with get, set
  // Not in terms of pixels, but slots
  member val SlotHeight = slotHeight with get, set
  // Pixel width and height to draw with
  member val Size = size with get, set
  member val Elements = elements with get, set
  
  member this.Add elem x y = Array2D.set elements x y elem
  
  override this.Initialize () = elementsDo (fun obj -> obj.Initialize ())
  
  override this.LoadContent () = elementsDo (fun obj -> obj.LoadContent ())
  
  override this.Update gameTime =
    elementsDo (fun obj ->
      obj.Update gameTime
      obj.Position <- new Vector2(100.0f, 150.0f))
  
  override this.Draw gameTime = elementsDo (fun obj -> obj.Draw gameTime)