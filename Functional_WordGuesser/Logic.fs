﻿module Logic

open System

let words = Config.WORDS

let wordsForTesting = ["Orange tree";"Magnet";"Coffee";"London";"Redundant"; "Concrete"; "Wild fire"; "Mirror"]

let mutable word' = ""

let toPartialWord (word : string) (used : char seq) =
    word
    |> String.map (fun c ->
        if Seq.exists ((=) c) used then c
        elif Seq.exists ((=) c) [' '] && Config.ALLOW_BLANKS 
            then c  
        else Config.HIDDEN)

let isGuessValid (used : char seq) (guess : char) =    
    Seq.exists ((=) guess) (Seq.append(Seq.append['A'..'Z'] ['a'..'z'] )[' ']) 
            && not (used |> Seq.exists ((=) guess))

let rnd = System.Random()

let rec getWord() : string =
    let mutable word = words.[rnd.Next(0, words.Length)]
    if Config.CASE_SENSITIVE = false || Config.ALLOW_BLANKS = true then word <- wordsForTesting.[rnd.Next(0, wordsForTesting.Length)]
    if Config.ALLOW_BLANKS = false && word.Contains(" ") then getWord()
    else
        if Config.CASE_SENSITIVE = true then
            let wordList = Seq.toList(word.ToLower())
            String.Concat(Array.ofList(wordList))
        else
            word


let mutable word = getWord()

let rec readGuess used =
    let mutable guess = Console.ReadKey(true).KeyChar
    if KeyboardHelper.GetKeysAndModifiers().Modifiers.Equals(ConsoleModifiers.Shift) && Config.CASE_SENSITIVE = false then
        guess <- guess |> Char.ToUpper
    else
        guess <- guess |> Char.ToLower
    if isGuessValid used guess then guess
    elif KeyboardHelper.GetKeysAndModifiers().Modifiers.Equals(ConsoleModifiers.Control) && Config.HELP then
        GetHelp.HelpLetter (word') (word)
    else readGuess used


let getGuess used =
    Console.Write
        ("Used [" + (used
                     |> List.toArray
                     |> System.String)
         + "]. Guess: ")
    let guess = readGuess used
    Console.Write(guess)
    Console.WriteLine("\n")
    guess


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
    word <- ""
    word <- getWord()
    play word [] |> ignore
