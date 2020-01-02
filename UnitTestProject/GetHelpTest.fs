module GetHelpTest

open Xunit

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

[<Fact>]
let ``Get help for word 2`` () =
    //Arrange
    let wordToGuess2 = "full house"
    let wordGuessedSoFar2 = "**ll **us*"
    let lettersUsedSoFar2 = ['l';'y';'c';'k';'z';'u';'s']
    //Act
    let helpingLetter2 = GetHelp.HelpLetter(wordGuessedSoFar2)(wordToGuess2)(lettersUsedSoFar2)
    //Assert
    Assert.True(wordToGuess2.Contains(helpingLetter2))