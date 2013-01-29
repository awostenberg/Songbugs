namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

type Palette(game : Game) =
  inherit Positional()
  
  let spriteBatch = new SpriteBatch(game.GraphicsDevice)
  let mutable images : Texture2D list = []
  let drawCenter (img : Texture2D) pos =
    spriteBatch.Draw (img, pos + new Vector2(img.Width / -2 |> float32, img.Height / -2 |> float32), Color.White)
  
  override this.LoadContent () =
    images <- [game.Content.Load "p_left.png"; game.Content.Load "p_chunk.png"; game.Content.Load "p_right.png"]
  
  override this.Update gameTime =
    ()
  
  override this.Draw gameTime =
    spriteBatch.Begin ()
    let pp = game.GraphicsDevice.PresentationParameters
    let centerFocus = new Vector2(pp.BackBufferWidth / 2 |> float32, pp.BackBufferHeight |> float32)
    let i0, i1, i2 = images.[0], images.[1], images.[2]
    let leftBounds, rightBounds = -3.5f, 3.5f
    let yoffset = new Vector2(0.0f, i1.Height / 2 |> float32) * -1.0f
    for xslot in leftBounds..rightBounds do
      drawCenter i1 (new Vector2((i1.Width |> float32) * xslot, 0.0f) + yoffset + centerFocus)
    spriteBatch.End ()