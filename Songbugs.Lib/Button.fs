namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

type Button(game : Game, text : string) =
  inherit Drawable(game)
  
  let mutable i_normal : Texture2D = null
  let mutable i_pressed : Texture2D = null
  let mutable font : SpriteFont = null
  let mutable stringPosition = Vector2.Zero
  let clickEvent = new Event<_> ()
  
  member val Pressed = false with get, set
  member this.Image = if this.Pressed then i_pressed else i_normal
  override this.Width = this.Image.Width
  override this.Height = this.Image.Height
  member this.Click = clickEvent.Publish
  
  override this.Center
    with get () = base.Center
    and set v =
      stringPosition <- v - (font.MeasureString(text) / 2.0f)
      base.Center <- v
  
  override this.Initialize () =
    let containsMouse () =
      let mState = Microsoft.Xna.Framework.Input.Mouse.GetState ()
      this.Bounds.Contains (new Vector2(mState.X |> float32, mState.Y |> float32))
    // Filter for the left mouse button
    let filterLeft b = b = Songbugs.Lib.Input.MouseButtons.Left
    EventManager.MousePress
      |> Event.filter filterLeft
      |> Event.filter (fun _ -> containsMouse ())
      |> Event.add (fun _ -> this.Pressed <- true)
    EventManager.MouseRelease
      |> Event.filter filterLeft
      // !! Don't proceed if the button wasn't already being pressed -- actions tied to this button will execute !!
      |> Event.filter (fun _ -> this.Pressed)
      |> Event.add (fun _ -> this.Pressed <- false; clickEvent.Trigger ())
  
  override this.LoadContent () =
    // Load two images: the image to draw when the button is not pressed (i_normal = b_normal.png) and the image for when the button _is_ pressed (i_pressed = b_pressed)
    i_normal <- game.Content.Load "b_normal.png"
    i_pressed <- game.Content.Load "b_pressed.png"
    font <- game.Content.Load "Consolas"
  
  override this.Draw _ =
    this.SpriteBatchDo (fun spriteBatch ->
      spriteBatch.Draw (this.Image, this.Position, Color.White)
      spriteBatch.DrawString (font, text, stringPosition, Color.Black))