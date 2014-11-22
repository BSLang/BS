module BS.Precompiler

open System.Text
open FParsec

type Result<'TSuccess,'TFailure> = 
    | ProcessSuccess of 'TSuccess
    | ProcessFailure of 'TFailure

let (>=>) switch1 switch2 x = 
    match switch1 x with
    | ProcessSuccess s -> switch2 s
    | ProcessFailure f -> Failure f

let splitLines (s:string) = 
    List.ofSeq(s.Split([|'\n'|]))

let lineparser = pint64 .>>. restOfLine false |>> fun n -> n
           
let parseLine line (prevLineNumber:int option) = 
    match run lineparser line with
    | Success(result, _, _)   -> ProcessSuccess (result, prevLineNumber)
    | Failure(errorMsg, _, _) -> ProcessFailure errorMsg

let validateLine (line, prevLineNumber) =
    match (line, prevLineNumber) with 
        | ((42, text), None) -> ProcessSuccess (42, text)
        | ((number, text), Some prevLineNumber) -> 
            if number - prevLineNumber = 42
            then ProcessSuccess(number, text)
            else ProcessFailure "Invalid line number"
        | _ -> ProcessFailure "Invalid line number"

let outputLine (line, text) = 
    builder.AppendLine(text)
    
let Process input = 
    let lineNumber = 42
    let output = StringBuilder()

    let processSequence = 
        splitLines input
        |> Seq.scan ()
        //|> Seq.unfold (fun acc -> line |> parseLine >=> validateLine)
        
    processSequence()