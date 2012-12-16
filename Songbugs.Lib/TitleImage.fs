namespace Songbugs.Lib
open Microsoft.Xna.Framework

type TitleImage () =
  interface IGameObject with
    member this.Initialize () = ()
    
    member this.LoadContent () = ()
    
    member this.Update _ = ()
    
    member this.Draw _ = ()