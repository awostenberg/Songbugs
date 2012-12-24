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
  let buttonPressAction curr old evArg (ev : _ Event) =
    if (curr = ButtonState.Pressed) && (old = ButtonState.Released) then
      ev.Trigger evArg
  
  // If the given button is down, fire a MouseDown event
  let buttonDownAction b evArg (ev : _ Event) =
    if b = ButtonState.Pressed then
      ev.Trigger evArg
  
  // If the given button has been released (clicked), fire a MouseRelease event
  let buttonReleaseAction curr old evArg (ev : _ Event) =
    if (curr = ButtonState.Released) && (old = ButtonState.Released) then
     ev.Trigger evArg
  
  let updateMouseButton currb oldb mb =
    buttonPressAction currb oldb mb mousePress
    buttonDownAction currb mb mouseDown
    buttonReleaseAction currb oldb mb mouseRelease
  
  let updateMouseEvents () =
    let mouseState = Mouse.GetState ()
    
    updateMouseButton mouseState.LeftButton oldMouseState.LeftButton MouseButtons.Left
    updateMouseButton mouseState.MiddleButton oldMouseState.MiddleButton MouseButtons.Middle
    updateMouseButton mouseState.RightButton oldMouseState.RightButton MouseButtons.Right
    
    oldMouseState <- mouseState
  
  // Keep those events flowing.
  let update () =
    updateMouseEvents ()