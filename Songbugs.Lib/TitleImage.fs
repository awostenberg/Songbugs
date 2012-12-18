namespace Songbugs.Lib
open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

[<AllowNullLiteral>]
type TitleImage(game : Game) =
  inherit GameObject()
  
  let spriteBatch = new SpriteBatch(game.GraphicsDevice)
  let mutable image : Texture2D = null
  let scale = 1.0f
  
  override this.LoadContent () =
    image <- game.Content.Load "title.png"
  
  override this.Draw _ =
    spriteBatch.Begin ()
    if not (image = null) then spriteBatch.Draw (image, Vector2.Zero, new Nullable<Rectangle>(), Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f)
    spriteBatch.End ()