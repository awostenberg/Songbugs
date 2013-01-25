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
    for xslot in 0..7 do
      spriteBatch.Draw(images.[1], new Vector2(xslot * 2 * images.[1].Width |> float32, 0.0f), Color.White)
    spriteBatch.End ()