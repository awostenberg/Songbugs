namespace Songbugs.Lib
open Microsoft.Xna.Framework

type Game() as this =
  inherit Microsoft.Xna.Framework.Game ()
  
  member val Graphics = new GraphicsDeviceManager(this) with get, set
  
  override this.Initialize () =
    this.Content.RootDirectory <- "../Resources"
    this.Graphics.IsFullScreen <- false
    this.IsMouseVisible <- true
    
    base.Initialize ()
  
  override this.Draw _ =
    this.GraphicsDevice.Clear Color.Black