module Config

let readLines = System.IO.File.ReadLines(@"../properties/words.txt")

let WORDS = Seq.toList readLines

let HIDDEN = '*'

let HELP = true

let CASE_SENSITIVE = true

let ALLOW_BLANKS = true

let MULTIPLE = false