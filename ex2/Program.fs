open System

let search n = 
    let s = string (abs n)
    int(string s.[0])

[<EntryPoint>]
let main _ =
    printfn "Введите цифру c которой должны начинаться числа"
    let target = int(Console.ReadLine())

    printfn "Введите числа (ex для выхода)"
    let input = 
        Seq.initInfinite(fun _ -> Console.ReadLine())
        |> Seq.takeWhile (fun x -> x <> "ex")
        |> Seq.choose (fun x ->
            match System.Int32.TryParse(x) with
            | true, value -> Some value
            | false, _ ->
                printfn "'%s'Не является числом " x
                None)

    let totalSum =
        input
        |> Seq.fold (fun acc x ->
        if search x = target then
            acc + x
        else
            acc) 0

    printfn "Сумма чисел начинающихся на %d: %d" target totalSum
    0