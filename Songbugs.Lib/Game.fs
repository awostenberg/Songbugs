namespace Songbugs.Lib
open Microsoft.Xna.Framework

type Game() as this =
  inherit Microsoft.Xna.Framework.Game ()
  
  let alignment = new Alignment(1, 3, Vector2.Zero)
  
  member val Graphics = new GraphicsDeviceManager(this) with get, set
  
  override this.Initialize () =
    this.Content.RootDirectory <- "../Resources/Media"
    this.Graphics.IsFullScreen <- false
    this.IsMouseVisible <- true
    alignment.Size <- new Vector2(this.Graphics.PreferredBackBufferWidth |> float32, this.Graphics.PreferredBackBufferHeight |> float32)
    alignment.Add (new TitleImage(this)) 0 0
    alignment.Initialize ()
    
    base.Initialize ()
  
  override this.LoadContent () = alignment.LoadContent ()
  
  override this.Update gameTime = alignment.Update gameTime
  
  override this.Draw gameTime =
    this.GraphicsDevice.Clear Color.Black
    alignment.Draw gameTime