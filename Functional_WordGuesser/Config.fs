﻿module Config

let readLines = System.IO.File.ReadLines(@"../properties/words.txt")

let WORDS = Seq.toList readLines

let HIDDEN = '*'

let HELP = false

let CASE_SENSITIVE = false

let ALLOW_BLANKS = true

let MULTIPLE = false