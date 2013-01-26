namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

type Palette(game : Game) =
  inherit Positional()
  
  let spriteBatch = new SpriteBatch(game.GraphicsDevice)
  let mutable images : Texture2D list = []
  
  override this.LoadContent () =
    images <- [game.Content.Load "p_left.png"; game.Content.Load "p_chunk.png"; game.Content.Load "p_right.png"]
  
  override this.Update gameTime =
    ()
  
  override this.Draw gameTime =
    spriteBatch.Begin ()
    let pp = game.GraphicsDevice.PresentationParameters
    let centerFocus = new Vector2(pp.BackBufferWidth / 2 |> float32, pp.BackBufferHeight |> float32)
    let i1 = images.[1]
    let leftBounds, rightBounds = -4.5f, 2.5f
    for xslot in leftBounds..rightBounds do
      let offset = new Vector2(i1.Width / 2 |> float32, i1.Height * -1 |> float32) + centerFocus
      spriteBatch.Draw(i1, new Vector2((i1.Width |> float32) * xslot, 0.0f) + offset, Color.White)
    spriteBatch.End ()