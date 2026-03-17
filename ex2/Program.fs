open System

// Получение первой цифры числа
let search n = 
    let s = string n
    int(string s.[0]) // Получение первого символа в строке .[0]

[<EntryPoint>]
let main _ =
    printfn "Введите цифру c которой должны начинаться числа"
    let target = int(Console.ReadLine())

    printfn "Введите числа (ex для выхода)"
    // Создание последовательности
    let input = 
        Seq.initInfinite(fun _ -> Console.ReadLine())
        |> Seq.takeWhile (fun x -> x <> "ex")

        |> Seq.choose (fun x -> // Проверка на корректность ввода
            match System.Int32.TryParse(x) with
            // Распознавание корректных значений для фильтрации
            | true, value -> Some value
            | false, _ ->
                printfn "'%s'Не является числом " x
                None) // Игнорируется ввод

        // Подсчёт суммы
        |>Seq.fold (fun acc x ->
            if search x = target then
                acc + x 
            else
                acc
        ) 0

    printfn "Сумма чисел начинающихся на %d: %d" target input
    0