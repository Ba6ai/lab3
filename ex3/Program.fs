open System
open System.IO

let symbol() = 
    printf "Введите символ для поиска файлов: "
    Console.ReadLine()[0]
    
[<EntryPoint>]
let main _ =
    let path = "C:\\Users\\elise\\OneDrive\\УНИК\\2Курс\\2\\ЯП\\kt1\\lab3\\New_fold"
    let target = symbol()

    if Directory.Exists(path) then
        let files = 
            Directory.EnumerateFiles(path)
            |> Seq.map Path.GetFileName
            |> Seq.filter (fun name ->
                name.Length > 0 && name[0] = target)
            |> Seq.toList
        
        printfn "Список файлов на букву %c: %A " target files
    else
        printfn "Путь не верен"
        
    0