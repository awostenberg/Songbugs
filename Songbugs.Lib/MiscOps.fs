namespace Songbugs.Lib
open System.Reflection
open Microsoft.FSharp.Reflection

module MiscOps =
  let (?) o m args =
    let args =
      if box args = null then
        [||]
      elif FSharpType.IsTuple (args.GetType ()) then
        FSharpValue.GetTupleFields args
      else
        [|args|]
    o.GetType().InvokeMember (m, BindingFlags.GetProperty ||| BindingFlags.InvokeMethod, null, o, args)
  