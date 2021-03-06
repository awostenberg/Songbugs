namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

[<AllowNullLiteral>]
type GameObject() =
  abstract Initialize : unit -> unit default this.Initialize () = ()
  
  abstract LoadContent : unit -> unit default this.LoadContent () = ()
  
  abstract Update : GameTime -> unit default this.Update _ = ()
  
  abstract Draw : GameTime -> unit default this.Draw _ = ()
  
  abstract Destroy : unit -> unit default this.Destroy () = this.Finalize ()

[<AllowNullLiteral>]
type Positional() =
  inherit GameObject()
  
  let mutable position = Vector2.Zero
  let mutable center = Vector2.Zero
  
  abstract member Width : int default this.Width = 0
  abstract member Height : int default this.Height = 0
  abstract member Size : Vector2 with get, set
  override this.Size
    with get () = new Vector2(this.Width |> float32, this.Height |> float32)
    and set v = ()
  abstract Position : Vector2 with get, set
  override this.Position
    with get () = position
    and set v = position <- v
  abstract Center : Vector2 with get, set
  override this.Center
    with get () = this.Position + (this.Size / 2.0f)
    and set v = this.Position <- v - (this.Size / 2.0f)
  abstract Bounds : Rectangle default this.Bounds = new Rectangle(this.Position.X |> int, this.Position.Y |> int, this.Width, this.Height)