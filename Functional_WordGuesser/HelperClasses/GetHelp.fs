module GetHelp

open System

let genRandomNumbers high =
    let rnd = Random()
    rnd.Next(high)

let HelpLetter (currentGuess : string) (wordToGuess : string) (usedGuesses : char list) : char =
    let mutable helpChar = []
    for c in wordToGuess do
        if not (currentGuess.Contains(c.ToString())) then helpChar <- [ c ] |> List.append helpChar
    let l = genRandomNumbers (helpChar.Length)
    Console.Write("Help letter: ")
    helpChar.Item(l)
