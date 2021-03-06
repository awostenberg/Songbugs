namespace Songbugs.Lib.GUI.Screens
open Microsoft.Xna.Framework
open Songbugs.Lib
open Songbugs.Lib.GUI
open Songbugs.Lib.MiscOps

type MainMenu(game, screen, size : Vector2) =
  inherit GameScreen(game, screen)
  
  let alignment = new Alignment(1, 3, Vector2.Zero)
  
  override this.Initialize () =
    let playButton = new Button(game, "PLAY")
    let exitButton = new Button(game, "EXIT")
    playButton.Click.Add (fun () -> game.CurrentScreenID <- 1 (* 1 is the main game*))
    exitButton.Click.Add (fun () -> game.Exit ())
    alignment.[0, 0] <- new TitleImage(game)
    alignment.[0, 1] <- playButton
    alignment.[0, 2] <- exitButton
    alignment.Size <- size
    alignment.Initialize ()
    base.Initialize ()
  
  override this.LoadContent () = alignment.LoadContent ()
  
  override this.Update gameTime = alignment.Update gameTime
  
  override this.Draw gameTime = alignment.Draw gameTime