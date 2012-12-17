namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

[<AllowNullLiteral>]
type TitleImage(game : Game) =
  let spriteBatch = new SpriteBatch(game.GraphicsDevice)
  let mutable image : Texture2D = null
  
  interface IGameObject with
    member this.Initialize () = ()
    
    member this.LoadContent () =
      image <- game.Content.Load "title.png"
    
    member this.Update _ = ()
    
    member this.Draw gameTime =
      spriteBatch.Begin ()
      if not (image = null) then spriteBatch.Draw (image, new Vector2(1.0f, 1.0f), Color.White)
      spriteBatch.End ()