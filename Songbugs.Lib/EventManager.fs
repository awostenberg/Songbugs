namespace Songbugs.Lib
open System.Reflection
open Microsoft.FSharp.Reflection
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Input
open Songbugs.Lib.Input

module EventManager =
  
  let (?) o m args =
    let args =
      if box args = null then
        [||]
      elif FSharpType.IsTuple (args.GetType ()) then
        FSharpValue.GetTupleFields args
      else
        [|args|]
    o.GetType().InvokeMember (m, BindingFlags.GetProperty ||| BindingFlags.InvokeMethod, null, o, args)
  
  let mutable private oldKeybState = Keyboard.GetState ()
  let mutable private oldMouseState = Mouse.GetState ()
  
  let private keyPress = new Event<Keys>()
  let private keyDown = new Event<Keys>()
  let private keyRelease = new Event<Keys>()
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
  
  let updateButton currb oldb b evPress evDown evRelease =
    buttonPressAction currb oldb b evPress
    buttonDownAction currb b evDown
    buttonReleaseAction currb oldb b evRelease
  
  let updateMouseEvents () =
    let mouseState = Mouse.GetState ()
    let updateMouseButton currmb oldmb mb = updateButton currmb oldmb mb mousePress mouseDown mouseRelease
    
    updateMouseButton mouseState.LeftButton oldMouseState.LeftButton MouseButtons.Left
    updateMouseButton mouseState.MiddleButton oldMouseState.MiddleButton MouseButtons.Middle
    updateMouseButton mouseState.RightButton oldMouseState.RightButton MouseButtons.Right
    updateMouseButton mouseState.XButton1 oldMouseState.XButton1 MouseButtons.X1
    updateMouseButton mouseState.XButton2 oldMouseState.XButton2 MouseButtons.X2
    
    oldMouseState <- mouseState
  
  // Keep those events flowing.
  let update () =
    updateMouseEvents ()