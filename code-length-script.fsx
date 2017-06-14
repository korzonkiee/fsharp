#r "System.Globalization"
open System.Globalization
open System.IO;

let codeLength s = 
    let elements = 
        seq {
            let tee = StringInfo.GetTextElementEnumerator(s)
            while tee.MoveNext() do 
                let c = tee.GetTextElement()
                if not (System.String.IsNullOrWhiteSpace c) then yield c
        }
    Seq.length elements

let fileStream (path: string) =
    try
        File.OpenRead(path)
    with
        | :? System.IO.FileNotFoundException -> printfn "Error: %s not found." path; exit(1)

let fileContentLength (path: string) =
    use reader = new StreamReader(fileStream path)
    let fileContent = reader.ReadToEnd()

    printfn "Pure code length: %d" (codeLength fileContent)

match fsi.CommandLineArgs with
    | [| scriptName; filePath |] ->
        printfn "Executing script: %s" scriptName
        fileContentLength filePath
    | _ ->
        printfn "USAGE: [filePath]"