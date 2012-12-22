namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Input
open Songbugs.Lib.Input

module EventManager =
  
  let mutable private oldMouseState = Mouse.GetState ()
  
  let private mouseClick = new Event<MouseButtons>()
  
  let MouseClick = mouseClick.Publish
  
  let updateMouseEvents () =
    let mouseState = Mouse.GetState ()
    if (mouseState.LeftButton = ButtonState.Pressed) && (oldMouseState.LeftButton = ButtonState.Released) then
      MouseClick.Trigger MouseButtons.Left
    if (mouseState.MiddleButton = ButtonState.Pressed) && (oldMouseState.MiddleButton = ButtonState.Released) then
      MouseClick.Trigger MouseButtons.Middle
    if (mouseState.RightButton = ButtonState.Pressed) && (oldMouseState.RightButton = ButtonState.Released) then
      MouseClick.Trigger MouseButtons.Right
  
  // Call this to keep events flowing
  let update () =
    updateMouseEvents ()