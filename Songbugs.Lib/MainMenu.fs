namespace Songbugs.Lib
open Microsoft.Xna.Framework
open MiscOps

[<AllowNullLiteral>]
type MainMenu(game, size : Vector2) =
  inherit GameScreen()
  
  let alignment = new Alignment(1, 3, Vector2.Zero)
  
  override this.Initialize () =
    let b = new Button(game)
    // Since one of these classes has to be defined first, we have to use reflection
    b.Click.Add (fun () -> setProperty game "CurrentScreen" [|1|] (* 1 is the main game *))
    alignment.[0, 0] <- new TitleImage(game)
    alignment.[0, 2] <- b
    alignment.Size <- size
    alignment.Initialize ()
  
  override this.LoadContent () = alignment.LoadContent ()
  
  override this.Update gameTime = alignment.Update gameTime
  
  override this.Draw gameTime = alignment.Draw gameTime