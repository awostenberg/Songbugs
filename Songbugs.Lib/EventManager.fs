namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Input
open Songbugs.Lib.Input

module EventManager =
  
  let mutable private oldMouseState = Mouse.GetState ()
  
  let private mouseMove = new Event<Vector2>()
  let private leftMouseClick = new Event<MouseButtons>()
  let private middleMouseClick = new Event<MouseButtons>()
  let private rightMouseClick = new Event<MouseButtons>()
  
  let LeftMouseClick = leftMouseClick.Publish
  let MiddleMouseClick = middleMouseClick.Publish
  let RightMouseClick = rightMouseClick.Publish
  
  let updateMouseEvents () =
    let mouseState = Mouse.GetState ()
    if (mouseState.LeftButton = ButtonState.Pressed) && (oldMouseState.LeftButton = ButtonState.Released) then
      leftMouseClick.Trigger MouseButtons.Left
    if (mouseState.MiddleButton = ButtonState.Pressed) && (oldMouseState.MiddleButton = ButtonState.Released) then
      leftMouseClick.Trigger MouseButtons.Middle
    if (mouseState.RightButton = ButtonState.Pressed) && (oldMouseState.RightButton = ButtonState.Released) then
      leftMouseClick.Trigger MouseButtons.Right
  
  // Call this to keep events flowing
  let update () =
    updateMouseEvents ()