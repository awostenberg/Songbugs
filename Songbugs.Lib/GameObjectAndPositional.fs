namespace Songbugs.Lib
open Microsoft.Xna.Framework

[<AllowNullLiteral>]
type GameObject() =
  abstract Initialize : unit -> unit default this.Initialize () = ()
  
  abstract LoadContent : unit -> unit default this.LoadContent () = ()
  
  abstract Update : GameTime -> unit default this.Update _ = ()
  
  abstract Draw : GameTime -> unit default this.Draw _ = ()
  
  // Operator overloads
  // Vector2 * Vector2
  
  static member (+) (v1 : Vector2, v2 : Vector2) = new Vector2(v1.X + v2.X, v1.Y + v2.Y)
  static member (-) (v1 : Vector2, v2 : Vector2) = new Vector2(v1.X - v2.X, v1.Y - v2.Y)
  static member (*) (**) (v1 : Vector2, v2 : Vector2) = new Vector2(v1.X * v2.X, v1.Y * v2.Y)
  static member (/) (v1 : Vector2, v2 : Vector2) = new Vector2(v1.X / v2.X, v1.Y / v2.Y)
  
  // Vector2 * float32
  
  static member (+) (vec : Vector2, num) = new Vector2(vec.X + num, vec.Y + num)
  static member (-) (vec : Vector2, num) = new Vector2(vec.X - num, vec.Y - num)
  static member (*) (**) (vec : Vector2, num) = new Vector2(vec.X - num, vec.Y - num)
  static member (/) (vec : Vector2, num) = new Vector2(vec.X / num, vec.Y / num)

[<AllowNullLiteral>]
type Positional() =
  inherit GameObject()
  
  let mutable position = Vector2.Zero
  
  abstract member Width : int default this.Width = 0
  abstract member Height : int default this.Height = 0
  abstract member Size : Vector2 default this.Size = new Vector2(this.Width |> float32, this.Height |> float32)
  abstract Position : Vector2 with get, set
  override this.Position
    with get() = position
    and set(v) = position <- v
  abstract Center : Vector2 with get, set
  override this.Center
    with get() = this.Position + (this.Size / 2.0f)
    and set(v) = this.Position <- this.Position - (this.Size / 2.0f)
  abstract Bounds : Rectangle default this.Bounds = new Rectangle(this.Position.X |> int, this.Position.Y |> int, this.Width, this.Height)