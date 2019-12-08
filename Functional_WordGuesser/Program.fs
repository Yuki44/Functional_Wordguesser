namespace Console

open System

module Program =

    [<EntryPoint>]
    let main argv =
        Console.WriteLine("Welcome to Word Guesser\n")
        if Config.HELP then Console.WriteLine("For help press Ctrl+G twice\n")
        Logic.play Logic.word [] |> ignore
        0