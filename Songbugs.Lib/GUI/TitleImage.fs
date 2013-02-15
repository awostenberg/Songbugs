namespace Songbugs.Lib.GUI
open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Songbugs.Lib

type TitleImage(game : Game) =
  inherit Positional()
  
  let spriteBatch = new SpriteBatch(game.GraphicsDevice)
  let mutable image : Texture2D = null
  let scale = 4.0f
  
  override this.Width = image.Width * (scale |> int)
  override this.Height = image.Height * (scale |> int)
  
  override this.LoadContent () =
    image <- game.Content.Load "title.png"
  
  override this.Draw _ =
    spriteBatch.Begin (SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise)
    if not (image = null) then spriteBatch.Draw (image, this.Position, new Nullable<Rectangle>(), Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f)
    spriteBatch.End ()