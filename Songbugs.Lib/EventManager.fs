namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Input
open Songbugs.Lib.Input

module EventManager =
  
  let mutable private oldMouseState = Mouse.GetState ()
  
  let private mouseEngage = new Event<MouseButtons>()
  
  let MouseEngage = mouseEngage.Publish
  
  let updateMouseEvents () =
    let mouseState = Mouse.GetState ()
    if (mouseState.LeftButton = ButtonState.Pressed) && (oldMouseState.LeftButton = ButtonState.Released) then
      mouseEngage.Trigger MouseButtons.Left
    if (mouseState.MiddleButton = ButtonState.Pressed) && (oldMouseState.MiddleButton = ButtonState.Released) then
      mouseEngage.Trigger MouseButtons.Middle
    if (mouseState.RightButton = ButtonState.Pressed) && (oldMouseState.RightButton = ButtonState.Released) then
      mouseEngage.Trigger MouseButtons.Right
    oldMouseState <- mouseState
  
  // Keep those events flowing.
  let update () =
    updateMouseEvents ()