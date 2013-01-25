namespace Songbugs.Lib
open Microsoft.Xna.Framework

type Board(game) =
  inherit GameScreen(game)
  
  let palette = new Palette(game)
  
  override this.LoadContent () = palette.LoadContent ()
  
  override this.Update gameTime = palette.Update gameTime
  
  override this.Draw gameTime = palette.Draw gameTime