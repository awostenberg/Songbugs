namespace Songbugs.Lib
open Microsoft.Xna.Framework

type Game() as this =
  inherit Microsoft.Xna.Framework.Game ()
  
  let mutable title : TitleImage = null
  
  member val Graphics = new GraphicsDeviceManager(this) with get, set
  
  override this.Initialize () =
    this.Content.RootDirectory <- "../Resources"
    this.Graphics.IsFullScreen <- false
    this.IsMouseVisible <- true
    title <- new TitleImage(this)
    
    base.Initialize ()
  
  override this.Draw gameTime =
    this.GraphicsDevice.Clear Color.Black
    (title :> IGameObject).Draw gameTime