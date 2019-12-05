namespace Console

open System

module Program =

    [<EntryPoint>]
    let main argv =
        Console.WriteLine("Welcome to Word Guesser")
        Console.WriteLine("")
        Logic.play Logic.word [] 0
        0