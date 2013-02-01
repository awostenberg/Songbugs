namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

type Tile (game : Game, color) =
  inherit Positional()
  
  let spriteBatch = new SpriteBatch(game.GraphicsDevice)
  let mutable texture : Texture2D = null
  
  override this.LoadContent () =
    texture <- game.Content.Load "tile.png"
  
  override this.Draw gameTime =
    spriteBatch.Begin ()
    spriteBatch.Draw (texture, this.Position, color)
    spriteBatch.End ()