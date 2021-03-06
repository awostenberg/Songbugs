namespace Songbugs.Lib.GUI
open Microsoft.FSharp.Control
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Songbugs.Lib

type Button(game : StateBasedGame, text : string) =
  inherit Positional()
  
  let spriteBatch = new SpriteBatch(game.GraphicsDevice)
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
    game.CurrentScreen.MousePress.Add (fun b ->
      if (filterLeft b) && (containsMouse ()) then
        this.Pressed <- true)
    game.CurrentScreen.MouseRelease.Add (fun b ->
      if this.Pressed then
        this.Pressed <- false
        clickEvent.Trigger ())
  
  override this.LoadContent () =
    // Load two images: the image to draw when the button is not pressed (i_normal = b_normal.png) and the image for when the button _is_ pressed (i_pressed = b_pressed)
    i_normal <- game.Content.Load "b_normal.png"
    i_pressed <- game.Content.Load "b_pressed.png"
    font <- game.Content.Load "Consolas"
  
  override this.Draw _ =
    spriteBatch.Begin ()
    spriteBatch.Draw (this.Image, this.Position, Color.White)
    spriteBatch.DrawString (font, text, stringPosition, Color.Black)
    spriteBatch.End ()