namespace Songbugs.Lib
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Input
open Songbugs.Lib.Input

module EventManager =
  
  let private mouseMove = new Event<Vector2>()
  let private leftMouseClick = new Event<MouseButtons>()
  let private middleMouseClick = new Event<MouseButtons>()
  let private rightMouseClick = new Event<MouseButtons>()
  
  let LeftMouseClick = leftMouseClick.Publish
  let MiddleMouseClick = middleMouseClick.Publish
  let RightMouseClick = rightMouseClick.Publish