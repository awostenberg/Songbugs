namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

type Tile (game : Game, color) =
  inherit Positional()
  
  let spriteBatch = new SpriteBatch(game.GraphicsDevice)
  let mutable texture : Texture2D = null
  
  override this.Width = texture.Width
  override this.Height = texture.Height
  
  override this.LoadContent () =
    texture <- game.Content.Load "tile.png"
  
  override this.Draw gameTime =
    spriteBatch.Begin ()
    let mState = Mouse.GetState ()
    spriteBatch.Draw (texture, this.Position - (this.Size / 2.0f), color)
    spriteBatch.End ()