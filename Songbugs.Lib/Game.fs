namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Input
open Songbugs.Lib.Input

type Game() as this =
  inherit Microsoft.Xna.Framework.Game ()
  
  let alignment = new Alignment(1, 3, Vector2.Zero)
  
  member val Graphics = new GraphicsDeviceManager(this) with get, set
  
  override this.Initialize () =
    this.Content.RootDirectory <- "../Resources/Media"
    this.Graphics.IsFullScreen <- false
    this.IsMouseVisible <- true
    alignment.Size <- new Vector2(this.Graphics.PreferredBackBufferWidth |> float32, this.Graphics.PreferredBackBufferHeight |> float32)
    alignment.[0, 0] <- new TitleImage(this)
    alignment.[0, 2] <- new Button(this)
    alignment.Initialize ()
    
    base.Initialize ()
  
  override this.LoadContent () = alignment.LoadContent ()
  
  override this.Update gameTime =
    EventManager.update ()
    alignment.Update gameTime
  
  override this.Draw gameTime =
    this.GraphicsDevice.Clear Color.Black
    alignment.Draw gameTime