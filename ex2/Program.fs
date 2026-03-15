open System

// Получение первой цифры числа
let search n = 
    let s = string n
    int(string s.[0]) // Получение первого символа в строке .[0]

// Поиск суммы
let sum target input =
    input |> Seq.filter (fun x -> search x = target) |> Seq.sum

[<EntryPoint>]
let main _ =
    printfn "Введите цифру c которой должны начинаться числа"
    let target = int(Console.ReadLine())

    printfn "Введите число (ex для выхода)"

    // Создание последовательности
    let input = 
        Seq.initInfinite(fun _ -> Console.ReadLine())
        |> Seq.takeWhile (fun x -> x <> "ex")
        |> Seq.map int
        |> List.ofSeq   // Фиксирует данные в памяти

    let res = sum target input
    
    printfn "Список: %A" input
    printfn "Сумма чисел начинающихся на %d: %d" target res
    0