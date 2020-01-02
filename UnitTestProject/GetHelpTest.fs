module GetHelpTest

open Xunit
open System

[<Fact>]
let ``Get help for word`` () =
    //Arrange
    let wordToGuess1 = "mountain"
    let wordGuessedSoFar1 = "***ntain"
    let lettersUsedSoFar1 = ['n';'t';'a';'i';'z']
    //Act
    let helpingLetter1 = GetHelp.HelpLetter(wordGuessedSoFar1)(wordToGuess1)(lettersUsedSoFar1)
    //Assert
    Assert.True(wordToGuess1.Contains(helpingLetter1))

[<Theory>]
[<InlineData("full house","*ull **us*")>]
[<InlineData("manager","*******")>]
let ``Get help for word with inline data`` (wordToGuess2 : string, wordGuessedSoFar2 : string) =
    let emptyList = []
    //Act
    let helpingLetter2 = GetHelp.HelpLetter(wordGuessedSoFar2)(wordToGuess2)(emptyList)
    //Assert
    Assert.True(wordToGuess2.Contains(helpingLetter2))