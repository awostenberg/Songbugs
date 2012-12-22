namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Input
open Songbugs.Lib.Input

module EventManager =
  
  let mutable private oldMouseState = Mouse.GetState ()
  
  let private mousePress = new Event<MouseButtons>()
  let private mouseDown = new Event<MouseButtons>()
  let private mouseRelease = new Event<MouseButtons>()
  
  let MousePress = mousePress.Publish
  let MouseDown = mouseDown.Publish
  let MouseRelease = mouseRelease.Publish
  
  // If the given button has been clicked, fire a MousePress event
  let mousePressAction curr old evArg =
    if (curr = ButtonState.Pressed) && (old = ButtonState.Released) then
      mousePress.Trigger evArg
  
  // If the given button is down, fire a MouseDown event
  let mouseDownAction b evArg =
    if b = ButtonState.Pressed then
      mouseDown.Trigger evArg
  
  // If the given button has been released (clicked), fire a MouseRelease event
  let mouseReleaseAction curr old evArg =
    if (curr = ButtonState.Released) && (old = ButtonState.Released) then
      mouseRelease.Trigger evArg
  
  let updateButton currb oldb mb =
    mousePressAction currb oldb mb
    mouseDownAction currb  mb
    mouseReleaseAction currb oldb mb
  
  let updateMouseEvents () =
    let mouseState = Mouse.GetState ()
    
    updateButton mouseState.LeftButton oldMouseState.LeftButton MouseButtons.Left
    updateButton mouseState.MiddleButton oldMouseState.MiddleButton MouseButtons.Middle
    updateButton mouseState.RightButton oldMouseState.RightButton MouseButtons.Right
    
    oldMouseState <- mouseState
  
  // Keep those events flowing.
  let update () =
    updateMouseEvents ()