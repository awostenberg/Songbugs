namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

type Palette(game : Game) =
  inherit Positional()
  
  let spriteBatch = new SpriteBatch(game.GraphicsDevice)
  let mutable images : Texture2D list = []
  let tiles = List.init 8 (fun _ -> new Tile(game, Color.Red))
  let drawCenter (img : Texture2D) (pos : Vector2) =
    spriteBatch.Draw (img, pos + new Vector2(img.Width / -2 |> float32, img.Height / -2 |> float32), Color.White)
  
  override this.LoadContent () =
    images <- [game.Content.Load "p_left.png"; game.Content.Load "p_chunk.png"; game.Content.Load "p_right.png"]
    tiles |> List.iter (fun t -> t.LoadContent ())
  
  override this.Update gameTime =
    tiles |> List.iter (fun t -> t.Update gameTime)
  
  override this.Draw gameTime =
    spriteBatch.Begin ()
    let pp = game.GraphicsDevice.PresentationParameters
    let centerFocus = new Vector2(pp.BackBufferWidth / 2 |> float32, pp.BackBufferHeight |> float32)
    let i0, i1, i2 = images.[0], images.[1], images.[2]
    let leftBounds, rightBounds = -3.5f, 3.5f
    let yoffset = new Vector2(0.0f, i1.Height / 2 |> float32) * -1.0f
    spriteBatch.Draw (i0, new Vector2((i1.Width |> float32) * (leftBounds - 0.5f), 0.0f) + centerFocus + (yoffset * 2.0f) - new Vector2(i0.Width |> float32, 0.0f), Color.White)
    for xslot in leftBounds..rightBounds do
      let pos = (new Vector2((i1.Width |> float32) * xslot, 0.0f) + yoffset + centerFocus)
      drawCenter i1 pos
      let t = tiles.[xslot + 3.5f |> int]
      t.Position <- pos
      //t.Draw gameTime
    spriteBatch.Draw (i2, new Vector2((i1.Width |> float32) * (rightBounds + 0.5f), 0.0f) + centerFocus + (yoffset * 2.0f), Color.White)
    spriteBatch.End ()
    List.iter (fun (t : Tile) -> t.Draw gameTime) tiles