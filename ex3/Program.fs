open System
open System.IO

let symbol() = 
    printf "Введите символ для поиска файлов: "
    Console.ReadLine()[0] // Сразу берёт первый символ из введённой строки
    
[<EntryPoint>]
let main _ =
    let path = "C:\\Users\\elise\\OneDrive\\УНИК\\2Курс\\2\\ЯП\\kt1\\lab3\\New_fold"
    let target = symbol()

    if Directory.Exists(path) then // Проверка существования папки
        let files = 
            Directory.EnumerateFiles(path) // Возвращает ленивую последовательность путей
            |> Seq.map Path.GetFileName // Преобразует целый путь в короткое имя
            |> Seq.filter (fun name ->
                name.Length > 0 && name[0] = target) // Ищет файлы на введённую букву
            |> Seq.toList  // Жадно собирает результаты в итоговый список
        
        printfn "Список файлов на букву %c: %A " target files
    else
        printfn "Путь не верен"
        
    0