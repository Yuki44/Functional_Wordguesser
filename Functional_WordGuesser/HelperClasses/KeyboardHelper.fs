module KeyboardHelper

open System

let GetKeysAndModifiers() : ConsoleKeyInfo =
    Console.TreatControlCAsInput <- true

    let cki = Console.ReadKey()
    match cki.Modifiers with
    | ConsoleModifiers.Alt -> printfn ""
    | ConsoleModifiers.Shift -> printfn ""
    | ConsoleModifiers.Control -> printfn ""
    | _ -> printfn ""

    cki