namespace Songbugs.Lib
open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

[<AllowNullLiteral>]
type TitleImage(game : Game) =
  inherit Positional()
  
  let spriteBatch = new SpriteBatch(game.GraphicsDevice)
  let mutable image : Texture2D = null
  let scale = 4.0f
  
  member this.Width = image.Width
  member this.Height = image.Height
  member this.Size = new Vector2(this.Width |> float32, this.Height |> float32) * scale
  
  override this.LoadContent () =
    image <- game.Content.Load "title.png"
  
  override this.Draw _ =
    spriteBatch.Begin (SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise)
    if not (image = null) then spriteBatch.Draw (image, this.Position - (this.Size / 2.0f), new Nullable<Rectangle>(), Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f)
    spriteBatch.End ()