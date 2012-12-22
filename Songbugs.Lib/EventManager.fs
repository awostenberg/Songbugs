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
  
  let updateMouseEvents () =
    let mouseState = Mouse.GetState ()
    
    // All these if statements can somehow be refactored into some function. I'll do that soon; this is ugly...
    if (mouseState.LeftButton = ButtonState.Pressed) && (oldMouseState.LeftButton = ButtonState.Released) then
      mousePress.Trigger MouseButtons.Left
    else if mouseState.LeftButton = ButtonState.Pressed then
      mouseDown.Trigger MouseButtons.Left
    else if (mouseState.LeftButton = ButtonState.Released) && (oldMouseState.LeftButton = ButtonState.Pressed) then
      mouseRelease.Trigger MouseButtons.Left
    
    if (mouseState.MiddleButton = ButtonState.Pressed) && (oldMouseState.MiddleButton = ButtonState.Released) then
      mousePress.Trigger MouseButtons.Middle
    else if mouseState.MiddleButton = ButtonState.Pressed then
      mouseDown.Trigger MouseButtons.Middle
    else if (mouseState.MiddleButton = ButtonState.Released) && (oldMouseState.MiddleButton = ButtonState.Pressed) then
      mouseRelease.Trigger MouseButtons.Middle
    
    if (mouseState.RightButton = ButtonState.Pressed) && (oldMouseState.RightButton = ButtonState.Released) then
      mousePress.Trigger MouseButtons.Right
    else if mouseState.RightButton = ButtonState.Pressed then
      mouseDown.Trigger MouseButtons.Right
    else if (mouseState.RightButton = ButtonState.Released) && (oldMouseState.RightButton = ButtonState.Pressed) then
      mouseRelease.Trigger MouseButtons.Right
    
    oldMouseState <- mouseState
  
  // Keep those events flowing.
  let update () =
    updateMouseEvents ()