namespace Songbugs.Lib.Screens
open Microsoft.Xna.Framework
open Songbugs.Lib
open Songbugs.Lib.GUI

type Board(game, screen) =
  inherit GameScreen(game, screen)
  
  let palette = new Palette(game)
  
  override this.LoadContent () = palette.LoadContent ()
  
  override this.Update gameTime = palette.Update gameTime
  
  override this.Draw gameTime = palette.Draw gameTime