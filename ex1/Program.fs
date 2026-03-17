open System

// Вычисление суммы цифр
let sumCount n = 
    let rec loop curr summ =
        if curr = 0 then 
            summ
        else 
            loop (curr/10) (summ + (curr%10))
    loop n 0 

// Создание последовательности
let input = 
    // Автоматический генератор бесконечного конвейера
    Seq.initInfinite (fun _ -> Console.ReadLine())

    |> Seq.takeWhile (fun x -> x <> "ex")

    |> Seq.choose (fun x -> // Проверка на корректность ввода
        match System.Int32.TryParse(x) with
        // Распознавание корректных значений для фильтрации
        | true, value -> Some value
        | false, _ ->
            printfn "'%s'Не является числом " x
            None) // Игнорируется ввод
    |> Seq.map sumCount 

[<EntryPoint>]
let main _ =
    printfn "Введите числа (через Enter), для выхода введите 'ex':"
    let res = 
        input
            // Сразу выводит сумму ведённого числа
            |> Seq.iter (fun s -> printfn "Сумма цифр этого числа: %d" s)
    0
