namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Input
open Songbugs.Lib.Input

type Game() as this =
  inherit Microsoft.Xna.Framework.Game ()
  
  let mutable mainMenu : MainMenu = null
  
  member val Graphics : GraphicsDeviceManager = new GraphicsDeviceManager(this) with get, set
  
  override this.Initialize () =
    this.Content.RootDirectory <- "../Resources/Media"
    this.Graphics.IsFullScreen <- false
    this.IsMouseVisible <- true
    mainMenu <- new MainMenu(this, new Vector2(this.Graphics.PreferredBackBufferWidth |> float32, this.Graphics.PreferredBackBufferHeight |> float32))
    mainMenu.Initialize ()
    
    base.Initialize ()
  
  override this.LoadContent () = mainMenu.LoadContent ()
  
  override this.Update gameTime =
    EventManager.update ()
    mainMenu.Update gameTime
  
  override this.Draw gameTime =
    this.GraphicsDevice.Clear Color.Black
    mainMenu.Draw gameTime