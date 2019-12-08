module KeyboardHelper

open System

let GetKeysAndModifiers() : ConsoleKeyInfo =
    Console.TreatControlCAsInput <- true

    let cki = Console.ReadKey()

    cki