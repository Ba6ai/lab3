open System

// Создание последовательности
let input = 
    // Автоматический генератор бесконечного конвейера
    Seq.initInfinite (fun _ -> Console.ReadLine())

    |> Seq.takeWhile (fun x -> x <> "ex")
    |> Seq.map int          // Превращение строки в число

// Вычисление суммы цифр
let sumCount n = 
    let rec loop curr summ =
        if curr = 0 then summ
        else loop (curr/10) (summ + (curr%10))
    loop n 0 

[<EntryPoint>]
let main _ =
    printfn "Введите числа (через Enter), для выхода введите 'ex':"
    let res = 
        // toLost читает все строки в последовательности
        input |> Seq.map sumCount |> Seq.toList     // Подсчёт суммы

    printfn "Результат суммы чисел: %A" (res)
    0
