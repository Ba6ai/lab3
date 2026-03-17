open System
open System.IO

let symbol() = 
    printf "Введите символ для поиска файлов: "
    Console.ReadLine()
    
[<EntryPoint>]
let main _ =
    let path = @"C:\Users\elise\OneDrive\УНИК\2Курс\2\ЯП\lab3\New_fold"
    let s = symbol()

    if Directory.Exists(path) then // Проверка существования папки
        let files = 
            Directory.EnumerateFiles(path) // Получение последовательности путей

            |> Seq.map Path.GetFileName // Преобразует целый путь в короткое имя
            |> Seq.filter (fun name -> name.[0] = s.[0]) // Ищет файлы на введённую букву
            |> Seq.toList
        
        printfn "Список файлов на букву %s: %A " s files
    else
        printfn "Путь не верен"
        
    0