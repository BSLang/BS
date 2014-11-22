module BS.Compiler

// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open System.IO
open System

open FParsec
open NPOI.HWPF

open BS.AST

let ReadFile () = 
    use stream = new FileStream("../../../sourcefiles/hello world.doc", FileMode.Open)
    let doc = NPOI.HWPF.HWPFDocument(stream)
    doc.Text.ToString()

let test p str =
    match run p str with
    | Success(result, _, _)   -> printfn "%A" result
    | Failure(errorMsg, _, _) -> printfn "Failure: %s" errorMsg

[<EntryPoint>]
let main argv = 
    let str s = pstring s
    let space = str " "
    let literal = manyChars (noneOf "'")

    let asciiString = str "'" >>. literal .>> str "'"
    let comment = str "     " >>. restOfLine false
    let stat = str "echo" >>. space >>. asciiString .>> comment .>> opt newline |>> fun n -> Echo(String(n))
    
    let statements = many stat

    let source = (ReadFile())
    let r = test statements source
    let s = Console.ReadKey()
    0 // return an integer exit code
