namespace Songbugs.Lib
open Microsoft.Xna.Framework

[<AllowNullLiteral>]
type GameObject() =
  abstract member Initialize : unit -> unit default this.Initialize () = ()
  
  abstract member LoadContent : unit -> unit default this.LoadContent () = ()
  
  abstract member Update : GameTime -> unit default this.Update _ = ()
  
  abstract member Draw : GameTime -> unit default this.Draw _ = ()