module LogicTest

open Xunit
open Logic

[<Fact>]
let ``Set letters as hidden without a white space`` () =
    //Arrange
    let wordToGuess = "manager"
    let lettersUsedSoFar = []
    //Act
    let hiddenWord = toPartialWord (wordToGuess)(lettersUsedSoFar)
    //Assert
    Assert.Equal("*******", hiddenWord)

[<Fact>]
let ``Set letters as hidden with a white space`` () =
    //Arrange
    let wordToGuess = "official statement"
    let lettersUsedSoFar = []
    //Act
    let hiddenWord = toPartialWord (wordToGuess)(lettersUsedSoFar)
    //Assert
    Assert.Equal("******** *********", hiddenWord)