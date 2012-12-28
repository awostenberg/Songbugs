namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Input
open Songbugs.Lib.Input

type Game() as this =
  inherit Microsoft.Xna.Framework.Game ()
  
  let mutable screens : GameScreen list = []
  
  member this.Size = new Vector2(this.Graphics.PreferredBackBufferWidth |> float32, this.Graphics.PreferredBackBufferHeight |> float32)
  member val CurrentScreen = 0 with get, set
  
  member val Graphics : GraphicsDeviceManager = new GraphicsDeviceManager(this) with get, set
  
  override this.Initialize () =
    this.Content.RootDirectory <- "../Resources/Media"
    this.Graphics.IsFullScreen <- false
    this.IsMouseVisible <- true
    screens <- [new MainMenu(this, this.Size)]
    List.iter (fun (screen : GameScreen) -> screen.Initialize ()) screens
    
    base.Initialize ()
  
  override this.LoadContent () = List.iter (fun (screen : GameScreen) -> screen.LoadContent ()) screens
  
  override this.Update gameTime =
    EventManager.update ()
    screens.[this.CurrentScreen].Update gameTime
  
  override this.Draw gameTime =
    this.GraphicsDevice.Clear Color.Black
    screens.[this.CurrentScreen].Draw gameTime