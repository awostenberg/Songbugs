namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Input
open Songbugs.Lib.Input

module EventManager =
  
  let mutable private oldMouseState = Mouse.GetState ()
  
  let private mousePress = new Event<MouseButtons>()
  let private mouseRelease = new Event<MouseButtons>()
  
  let MouseEngage = mousePress.Publish
  let MouseRelease = mouseRelease.Publish
  
  let updateMouseEvents () =
    let mouseState = Mouse.GetState ()
    
    if (mouseState.LeftButton = ButtonState.Pressed) && (oldMouseState.LeftButton = ButtonState.Released) then
      mousePress.Trigger MouseButtons.Left
    else if (mouseState.LeftButton = ButtonState.Released) && (oldMouseState.LeftButton = ButtonState.Pressed) then
      mouseRelease.Trigger MouseButtons.Left
    
    if (mouseState.MiddleButton = ButtonState.Pressed) && (oldMouseState.MiddleButton = ButtonState.Released) then
      mousePress.Trigger MouseButtons.Middle
    else if (mouseState.MiddleButton = ButtonState.Released) && (oldMouseState.MiddleButton = ButtonState.Pressed) then
      mouseRelease.Trigger MouseButtons.Right
    
    if (mouseState.RightButton = ButtonState.Pressed) && (oldMouseState.RightButton = ButtonState.Released) then
      mousePress.Trigger MouseButtons.Right
    else if (mouseState.RightButton = ButtonState.Released) && (oldMouseState.RightButton = ButtonState.Pressed) then
      mouseRelease.Trigger MouseButtons.Right
    
    oldMouseState <- mouseState
  
  // Keep those events flowing.
  let update () =
    updateMouseEvents ()