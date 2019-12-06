module KeyboardHelper

open System

let GetKeysAndModifiers() : ConsoleKeyInfo =
    Console.TreatControlCAsInput <- true

    let cki = Console.ReadKey()
    match cki.Modifiers with
    | ConsoleModifiers.Alt -> printfn "ALT+"
    | ConsoleModifiers.Shift -> printfn "SHIFT+"
    | ConsoleModifiers.Control -> printfn "CTRL+"
    | _ -> printfn "not recognized modifier"

    cki