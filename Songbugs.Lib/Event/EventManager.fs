namespace Songbugs.Lib
open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Input
open Songbugs.Lib.Input
open MiscOps

module EventManager =
  let private keyPress = new Event<Keys>()
  let private keyDown = new Event<Keys>()
  let private keyRelease = new Event<Keys>()
  let private mousePress = new Event<MouseButtons>()
  let private mouseDown = new Event<MouseButtons>()
  let private mouseRelease = new Event<MouseButtons>()
  
  let KeyPress = keyPress.Publish
  let KeyDown = keyDown.Publish
  let KeyRelease = keyRelease.Publish
  let MousePress = mousePress.Publish
  let MouseDown = mouseDown.Publish
  let MouseRelease = mouseRelease.Publish
  
  // If the given key has been pressed, fire a KeyPress event
  let keyPressAction (curr : KeyboardState) (old : KeyboardState) k (ev : _ Event) =
    if (curr.IsKeyDown k) && (old.IsKeyUp k) then
      ev.Trigger k
  
  // If the given key is down, fire a KeyDown event
  let keyDownAction (curr : KeyboardState) k (ev : _ Event) =
    if curr.IsKeyDown k then
      ev.Trigger k
  
  // If the given key is up, fire a KeyUp event
  let keyReleaseAction (curr : KeyboardState) (old : KeyboardState) k (ev : _ Event) =
    if (curr.IsKeyUp k) && (old.IsKeyDown k) then
      ev.Trigger k
  
  // If the given mouse button has been clicked, fire a MousePress event
  let mouseButtonPressAction curr old evArg (ev : _ Event) =
    if (curr = ButtonState.Pressed) && (old = ButtonState.Released) then
      ev.Trigger evArg
  
  // If the given mouse button is down, fire a MouseDown event
  let mouseButtonDownAction b evArg (ev : _ Event) =
    if b = ButtonState.Pressed then
      ev.Trigger evArg
  
  // If the given mosue button has been released (clicked), fire a MouseRelease event
  let mouseButtonReleaseAction curr old evArg (ev : _ Event) =
    if (curr = ButtonState.Released) && (old = ButtonState.Pressed) then
     ev.Trigger evArg
  
  let updateMouseButton currb oldb b =
    mouseButtonPressAction currb oldb b mousePress
    mouseButtonDownAction currb b mouseDown
    mouseButtonReleaseAction currb oldb b mouseRelease
  
  let updateKeyboardEvents (oldKeybState : KeyboardState) (keybState : KeyboardState) =
    // Iterate over every key
    for k in Enum.GetValues typeof<Keys> do
      // Unbox it to a value of Keys
      let key = unbox<Keys> k
      // Test each event using the key
      keyPressAction keybState oldKeybState key keyPress
      keyDownAction keybState key keyDown
      keyReleaseAction keybState oldKeybState key keyRelease
  
  let updateMouseEvents (oldMouseState : MouseState) (mouseState : MouseState) =
    for mb in ["left"; "middle"; "right"] do
      let short = (cap mb)
      let long = short + "Button"
      // Use some fancy reflection to get the mouse button info and pass it to updateMouseButton
      updateMouseButton (unbox ((?) mouseState long ())) (unbox ((?) oldMouseState long ())) (getEnumValue<MouseButtons> short)
    
    // Some exceptions where the names don't apply to the above formula (for lack of a better term)
    updateMouseButton mouseState.XButton1 oldMouseState.XButton1 MouseButtons.X1
    updateMouseButton mouseState.XButton2 oldMouseState.XButton2 MouseButtons.X2
  
  // Keep those events flowing.
  let update oldKeybState oldMouseState keybState mouseState =
    updateKeyboardEvents oldKeybState keybState
    updateMouseEvents oldMouseState mouseState