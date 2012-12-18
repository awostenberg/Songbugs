namespace Songbugs.Lib
open Microsoft.Xna.Framework

type Game() as this =
  inherit Microsoft.Xna.Framework.Game ()
  
  let alignment = new Alignment(1, 1)
  
  member val Graphics = new GraphicsDeviceManager(this) with get, set
  
  override this.Initialize () =
    this.Content.RootDirectory <- "../Resources/Media"
    this.Graphics.IsFullScreen <- false
    this.IsMouseVisible <- true
    alignment.Add (new TitleImage(this)) 0 0
    
    base.Initialize ()
  
  override this.LoadContent () = alignment.LoadContent ()
  
  override this.Draw gameTime =
    this.GraphicsDevice.Clear Color.Black
    alignment.Draw gameTime