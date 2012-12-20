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
  member this.Width = this.Image.Width
  member this.Height = this.Image.Height
  member this.Size = new Vector2(this.Image.Width |> float32, this.Image.Height |> float32)
  
  override this.LoadContent () =
    i_normal <- game.Content.Load "b_normal.png"
    i_pressed <- game.Content.Load "b_pressed.png"
  
  override this.Draw _ =
    spriteBatch.Begin ()
    spriteBatch.Draw (this.Image, this.Position - (this.Size / 2.0f), Color.White)
    spriteBatch.End ()