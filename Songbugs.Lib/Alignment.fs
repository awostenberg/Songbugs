namespace Songbugs.Lib
open Microsoft.Xna.Framework

// Used to order objects on the screen with "slots"
// Note to self: Don't use size (little s), but use Size (property)
type Alignment(slotWidth: int, slotHeight : int, size : Vector2, elements : Positional [,]) =
  inherit Positional()
  
  let elementsDo action = Array2D.iteri action elements
  
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
  
  override this.Initialize () = elementsDo (fun x y obj -> obj.Initialize ())
  
  override this.LoadContent () = elementsDo (fun x y obj -> obj.LoadContent ())
  
  override this.Update gameTime =
    elementsDo (fun x y obj ->
      obj.Update gameTime
      let x = this.Size.X / (slotWidth + 1 |> float32)
      let y = this.Size.Y / (slotHeight + 1 |> float32)
      obj.Position <- new Vector2(x, y))
  
  override this.Draw gameTime = elementsDo (fun x y obj -> obj.Draw gameTime)