namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

type Tile (game : Game, note : string) =
  inherit Positional()
  
  static let colors =
    dict["c4", Color.Red;
        "d4", Color.Orange;
        "e4", new Color(255, 191, 0);
        "f4", Color.Yellow;
        "g4", new Color(191, 255, 0);
        "a4", Color.Green;
        "b4", Color.Cyan;
        "rest", Color.Black]
  
  let spriteBatch = new SpriteBatch(game.GraphicsDevice)
  let mutable texture : Texture2D = null
  
  override this.Width = texture.Width
  override this.Height = texture.Height
  
  override this.LoadContent () =
    texture <- game.Content.Load "tile.png"
  
  override this.Draw gameTime =
    spriteBatch.Begin ()
    let mState = Mouse.GetState ()
    spriteBatch.Draw (texture, this.Position - (this.Size / 2.0f), colors.[note])
    spriteBatch.End ()