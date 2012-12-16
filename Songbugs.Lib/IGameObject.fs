namespace Songbugs.Lib
open Microsoft.Xna.Framework

[<AllowNullLiteral>]
type IGameObject =
  abstract member Initialize : unit -> unit
  
  abstract member LoadContent : unit -> unit
  
  abstract member Update : GameTime -> unit
  
  abstract member Draw : GameTime -> unit