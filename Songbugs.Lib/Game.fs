namespace Songbugs.Lib
open Microsoft.Xna.Framework

type Game() =
  inherit Microsoft.Xna.Framework.Game()
  
  let mutable graphics : GraphicsDeviceManager = null
  
  override this.Initialize() =
    this.Content.RootDirectory <- "../Resources"
    graphics <- new GraphicsDeviceManager(this)
    graphics.IsFullScreen <- false
    
    base.Initialize()