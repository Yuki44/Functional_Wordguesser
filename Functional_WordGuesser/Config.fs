namespace Console

module Config =


    let readLines = System.IO.File.ReadLines(@"../properties/words.txt")

    let WORDS = Seq.toList readLines

    let HIDDEN = '*'