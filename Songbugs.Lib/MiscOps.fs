namespace Songbugs.Lib
open System
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
    unbox (o.GetType().InvokeMember (m, BindingFlags.InvokeMethod ||| BindingFlags.GetProperty ||| BindingFlags.GetField, null, o, args))
  
  let getEnumValue<'E> field =
    let enumType = typeof<'E>
    unbox<'E> (enumType.InvokeMember(field, BindingFlags.Static ||| BindingFlags.GetField, null, enumType, [||]))
  
  // Return a clone of s with the first letter uppercased
  let cap (s : string) = (Char.ToUpper s.[0] |> string) + (s.Substring 1)