namespace Console

open System

module Logic =

    let mutable countTries = 0

    let words = Config.WORDS


    let toPartialWord (word : string) (used : char seq) =
        word
        |> String.map (fun c ->
            if Seq.exists ((=) c) used then c
            else Config.HIDDEN)

    let isGuessValid (used : char seq) (guess : char) =
        Seq.exists ((=) guess) [ 'a'..'z' ] && not (used |> Seq.exists ((=) guess))

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

    let rec play word used =
        let word' = toPartialWord word used
        Console.WriteLine(word')
        if word = word' then
            Console.WriteLine("...")
            Console.WriteLine("You guessed it! Using only " + (used |> List.length).ToString() + " guesses!")
            Console.ReadKey(true)
        else
            let guess = getGuess used

            if word |> String.exists ((=) guess) then play word (used @ [ guess ])
            else play word (used @ [ guess ])

    let word = words.[Random().Next(words.Length)]


    do play word [] |> ignore