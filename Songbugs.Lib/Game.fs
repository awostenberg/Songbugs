namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Input
open Microsoft.Xna.Framework.Graphics
open Songbugs.Lib.Input

type Game() as this =
  inherit StateBasedGame ()
  
  let mutable oldKeybState = Keyboard.GetState ()
  let mutable oldMouseState = Mouse.GetState ()
  
  member this.Size = new Vector2(this.Graphics.PreferredBackBufferWidth |> float32, this.Graphics.PreferredBackBufferHeight |> float32)
  member val Graphics : GraphicsDeviceManager = new GraphicsDeviceManager(this) with get, set
  
  override this.Initialize () =
    this.Content.RootDirectory <- "../Resources/Media"
    this.Graphics.IsFullScreen <- false
    this.IsMouseVisible <- true
    this.Screens <- [|new MainMenu(this, 0, this.Size); new Board(this, 1)|]
    Array.iter (fun (screen : GameScreen) -> screen.Initialize ()) this.Screens
    this.Window.AllowUserResizing <- true
    EventManager.MouseDrag.Add (fun (mb, oldPos, pos) -> printfn "Mouse %A dragged from: \n%A \n\tto: %A\t" mb oldPos pos)
    EventManager.MouseMove.Add (fun (oldPos, pos) -> printfn "Mouse moved from: \n%A \n\tto: %A\t" oldPos pos)
    base.Initialize ()
  
  override this.LoadContent () = Array.iter (fun (screen : GameScreen) -> screen.LoadContent ()) this.Screens
  
  override this.Update gameTime =
    let keybState, mouseState = Keyboard.GetState (), Mouse.GetState ()
    EventManager.update oldKeybState oldMouseState keybState mouseState
    oldKeybState <- keybState
    oldMouseState <- mouseState
    this.CurrentScreen.Update gameTime
  
  override this.Draw gameTime =
    this.GraphicsDevice.Clear Color.White
    this.CurrentScreen.Draw gameTime