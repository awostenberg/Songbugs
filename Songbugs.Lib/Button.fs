namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

type Button(game : Game) =
  inherit Positional()
  
  let spriteBatch = new SpriteBatch(game.GraphicsDevice)
  let mutable i_normal : Texture2D = null
  let mutable i_pressed : Texture2D = null
  
  member val Pressed = false with get, set
  member this.Image = if this.Pressed then i_pressed else i_normal
  override this.Width = this.Image.Width
  override this.Height = this.Image.Height
  
  override this.Initialize () =
    let containsMouse () =
      let mState = Microsoft.Xna.Framework.Input.Mouse.GetState ()
      this.Bounds.Contains (new Vector2(mState.X |> float32, mState.Y |> float32))
    EventManager.MousePress.Add (fun b -> if containsMouse () then this.Pressed <- true)
    EventManager.MouseRelease.Add (fun b -> this.Pressed <- false)
  
  override this.LoadContent () =
    i_normal <- game.Content.Load "b_normal.png"
    i_pressed <- game.Content.Load "b_pressed.png"
  
  override this.Draw _ =
    spriteBatch.Begin ()
    spriteBatch.Draw (this.Image, this.Position, Color.White)
    spriteBatch.End ()