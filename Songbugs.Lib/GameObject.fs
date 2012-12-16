namespace Songbugs.Lib
open Microsoft.Xna.Framework

type IGameObject =
  
  abstract member Initialize : unit -> unit
  
  abstract member LoadContent : unit -> unit
  
  abstract member Update : GameTime -> unit
  
  abstract member Draw : GameTime -> unit