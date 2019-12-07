module GetHelp
open System

let genRandomNumbers high =
    let rnd = Random()
    rnd.Next (high)

//Get a helping character based on which parts of the words have or haven't been guessed.
let HelpLetter(currentGuess : string) (wordToGuess : string) : char =
    let mutable helpChar = []
    for c in wordToGuess do
        if not (currentGuess.Contains(c.ToString())) then 
            helpChar  <- [c] |> List.append helpChar
    let l = genRandomNumbers (helpChar.Length)
    helpChar.Item(l)


