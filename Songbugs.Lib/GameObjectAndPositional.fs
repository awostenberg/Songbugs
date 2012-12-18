namespace Songbugs.Lib
open Microsoft.Xna.Framework

[<AllowNullLiteral>]
type GameObject() =
  abstract Initialize : unit -> unit default this.Initialize () = ()
  
  abstract LoadContent : unit -> unit default this.LoadContent () = ()
  
  abstract Update : GameTime -> unit default this.Update _ = ()
  
  abstract Draw : GameTime -> unit default this.Draw _ = ()

[<AllowNullLiteral>]
type Positional() =
  inherit GameObject()
  
  let mutable position = Vector2.Zero
  
  abstract Position : Vector2 with get, set
  override this.Position
    with get() = position
    and set(v) = position <- v