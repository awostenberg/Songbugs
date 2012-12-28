namespace Songbugs.Lib
open Microsoft.Xna.Framework

[<AllowNullLiteral>]
type MainMenu(game, size : Vector2) =
  inherit GameScreen()
  
  let alignment = new Alignment(1, 3, Vector2.Zero)
  
  override this.Initialize () =
    alignment.[0, 0] <- new TitleImage(game)
    alignment.[0, 2] <- new Button(game)
    alignment.Size <- size
    alignment.Initialize ()
  
  override this.LoadContent () = alignment.LoadContent ()
  
  override this.Update gameTime = alignment.Update gameTime
  
  override this.Draw gameTime = alignment.Draw gameTime