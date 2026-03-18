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
    // Генератор бесконечной полседовательности
    Seq.initInfinite (fun _ -> Console.ReadLine())

    |> Seq.takeWhile (fun x -> x <> "ex") // Условие завершения ввода

    |> Seq.choose (fun x -> // фильтр в котором some - то всё ок, если - None, то ошибка
        match System.Int32.TryParse(x) with
        // Распознавание корректных значений для фильтрации
        | true, value -> Some value
        | false, _ ->
            printfn "'%s'Не является числом " x
            None) // Игнорируется ввод
    |> Seq.map sumCount // Преобразователь

[<EntryPoint>]
let main _ =
    printfn "Введите числа (через Enter), для выхода введите 'ex':"
    let res = 
        input
            // Работает как for
            |> Seq.iter (fun s -> printfn "Сумма цифр этого числа: %d" s)
    0
