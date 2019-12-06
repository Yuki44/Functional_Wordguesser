namespace Console

module Config =


    let readLines = System.IO.File.ReadLines(@"../properties/words.txt")

    let wordList = Seq.toList readLines