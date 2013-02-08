namespace Songbugs.Lib
open Microsoft.Xna.Framework

module Note =
  type Notes = C4 | D4 | E4 | F4 | G4 | A4 | B4 | Rest
  
  let color =
    function
    | C4 -> Color.Red
    | D4 -> Color.Orange
    | E4 -> new Color(255, 191, 0)
    | F4 -> Color.Yellow
    | G4 -> new Color(191, 255, 0)
    | A4 -> Color.Green
    | B4 -> Color.Cyan
    | Rest -> Color.Black