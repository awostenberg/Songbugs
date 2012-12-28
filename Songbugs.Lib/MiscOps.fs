namespace Songbugs.Lib
open System
open System.Reflection
open Microsoft.FSharp.Reflection

module MiscOps =
  // An inplementation of the dynamic lookup operator -- uses reflection to find a method at runtime instead of compile time
  let (?) o m args =
    // Convert arguments (can be a tuple) to an array that Type.InvokeMember can use
    let args =
      if box args = null then
        [||]
      elif FSharpType.IsTuple (args.GetType ()) then
        FSharpValue.GetTupleFields args
      else
        [|args|]
    // Cast to some type to bring it back to the safe static world
    unbox (o.GetType().InvokeMember (m, BindingFlags.InvokeMethod ||| BindingFlags.GetProperty ||| BindingFlags.GetField, null, o, args))
  
  let setProperty o p args = unbox (o.GetType().InvokeMember (p, BindingFlags.SetProperty, null, o, args))
  
  // Dynamically get a value of an Enum
  // Can't merge this into op_Dynamic as much as I'd like to...
  let getEnumValue<'E> field =
    let enumType = typeof<'E>
    unbox<'E> (enumType.InvokeMember(field, BindingFlags.Static ||| BindingFlags.GetField, null, enumType, [||]))
  
  // Return a clone of s with the first letter uppercased
  let cap (s : string) = (Char.ToUpper s.[0] |> string) + (s.Substring 1)