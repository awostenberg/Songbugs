namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Songbugs.Lib.Note

type Palette(game : Game) =
  inherit Positional()
  
  let spriteBatch = new SpriteBatch(game.GraphicsDevice)
  let mutable images : Texture2D list = []
  let tiles =
    let someTile note = Some(new Tile(game, note))
    [Notes.Rest |> someTile; None; Notes.C4 |> someTile; Notes.D4 |> someTile; Notes.E4 |> someTile; Notes.F4 |> someTile; Notes.G4 |> someTile; Notes.A4 |> someTile; Notes.B4 |> someTile]
  let drawCenter (img : Texture2D) (pos : Vector2) =
    spriteBatch.Draw (img, pos + new Vector2(img.Width / -2 |> float32, img.Height / -2 |> float32), Color.White)
  // Only execute the action with the tile if it is not a None value
  let someTileDo action t =
    if not (t = None) then action (Option.get t)
  
  override this.LoadContent () =
    images <- [game.Content.Load "p_left.png"; game.Content.Load "p_chunk.png"; game.Content.Load "p_right.png"]
    tiles |> List.iter (fun t -> (someTileDo (fun (t : Tile) -> t.LoadContent ()) t))
  
  override this.Update gameTime =
    tiles |> List.iter (fun t -> (someTileDo (fun (t : Tile) -> t.Update gameTime) t))
  
  override this.Draw gameTime =
    spriteBatch.Begin ()
    let pp = game.GraphicsDevice.PresentationParameters
    let centerFocus = new Vector2(pp.BackBufferWidth / 2 |> float32, pp.BackBufferHeight |> float32)
    let i0, i1, i2 = images.[0], images.[1], images.[2]
    let leftBounds, rightBounds = -4.0f, 4.0f
    let yoffset = new Vector2(0.0f, i1.Height / 2 |> float32) * -1.0f
    spriteBatch.Draw (i0, new Vector2((i1.Width |> float32) * (leftBounds - 0.5f), 0.0f) + centerFocus + (yoffset * 2.0f) - new Vector2(i0.Width |> float32, 0.0f), Color.White)
    for xslot in leftBounds..rightBounds do
      let pos = (new Vector2((i1.Width |> float32) * xslot, 0.0f) + yoffset + centerFocus)
      drawCenter i1 pos
      tiles.[xslot + 4.0f |> int] |> someTileDo (fun (t : Tile) -> t.Position <- pos)
    spriteBatch.Draw (i2, new Vector2((i1.Width |> float32) * (rightBounds + 0.5f), 0.0f) + centerFocus + (yoffset * 2.0f), Color.White)
    spriteBatch.End ()
    List.iter (fun t -> someTileDo (fun (t : Tile) -> t.Draw gameTime) t) tiles