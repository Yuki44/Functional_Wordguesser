module Logic

open System

let words = Config.WORDS

let mutable word' = ""

let cki = KeyboardHelper.GetKeysAndModifiers()


let toPartialWord (word : string) (used : char seq) =
    word
    |> String.map (fun c ->
        if Seq.exists ((=) c) used then c
        else Config.HIDDEN)

let isGuessValid (used : char seq) (guess : char) =
    Seq.exists ((=) guess) [ 'a'..'z' ] && not (used |> Seq.exists ((=) guess))

let rnd = System.Random()

let word = words.[rnd.Next(0, words.Length)]

let rec readGuess used =
        let guess = Console.ReadKey(true).KeyChar |> Char.ToLower
        if isGuessValid used guess then guess
        else readGuess used

let getGuess used =
    Console.Write
        ("Used [" + (used
                     |> List.toArray
                     |> System.String)
         + "]. Guess: ")
    let guess = readGuess used
    Console.WriteLine(guess)
    Console.WriteLine("")
    guess

let help (wordToGuess : string) (currentGuess : string) =
    let mutable char = cki.KeyChar

    if(cki.Key.ToString().Equals("H") && cki.Modifiers.Equals(ConsoleModifiers.Control) && Config.HELP) then
        char <- GetHelp.HelpLetter(currentGuess)(wordToGuess)

    char

let rec play word used =
    word' <- toPartialWord word used
    Console.WriteLine(word')
    if word = word' then
        Console.WriteLine("...")
        Console.WriteLine("You guessed it! Using only " + (used |> List.length).ToString() + " guesses!")
        Console.ReadKey(true) |> ignore
        Console.Clear()
        Console.WriteLine("Shall we play again?\n")
        Console.ReadKey() |> ignore
        if Config.HELP then Console.WriteLine("For help press Ctrl+G twice\n")
    else

        let guess = getGuess used

        if word |> String.exists ((=) guess) then play word (used @ [ guess ])
        else play word (used @ [ guess ])



while true do
    play words.[rnd.Next(0, words.Length)] [] |> ignore