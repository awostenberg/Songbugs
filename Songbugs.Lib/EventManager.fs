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
    
    let mousePress curr old evArg =
      if (curr = ButtonState.Pressed) && (old = ButtonState.Released) then
        mousePress.Trigger evArg
    
    let mouseDown b evArg =
      if b = ButtonState.Pressed then
        mouseDown.Trigger evArg
    
    let mouseRelease curr old evArg =
      if (curr = ButtonState.Released) && (old = ButtonState.Released) then
        mouseRelease.Trigger evArg
    
    let currl = mouseState.LeftButton
    let oldl = oldMouseState.LeftButton
    let ml = MouseButtons.Left
    mousePress currl oldl ml
    mouseDown currl ml
    mouseRelease currl oldl ml
    
    let currm = mouseState.MiddleButton
    let oldm = oldMouseState.MiddleButton
    let mm = MouseButtons.Middle
    mousePress currm oldm mm
    mouseDown currm mm
    mouseRelease currm oldm mm
    
    let currr = mouseState.RightButton
    let oldr = oldMouseState.RightButton
    let mr = MouseButtons.Right
    mousePress currr oldr mr
    mouseDown currr mr
    mouseRelease currr oldr mr
    
    oldMouseState <- mouseState
  
  // Keep those events flowing.
  let update () =
    updateMouseEvents ()