open System

// Создание списка
let rec numberss(currentlist: int list) : int list = 
    let x = Console.ReadLine()
    if x = "ex" then
        currentlist
    else
        numberss(currentlist @ [int(x)])

// Вычисление суммы списка
let sumCount n = 
    let rec loop curr summ =
        if curr = 0 then summ
        else loop (curr/10) (summ + (curr%10))
    loop n 0 

let sumList num = 
    // Выполняется только когда к нему обращаются
    num |> Seq.map sumCount

[<EntryPoint>]
let main _ =
    printfn "Введите числа (через Enter), для выхода введите 'ex':"
    let res = numberss []
    let result = sumList res

    printfn "Исходный список: %A" res
    printfn "Суммы цифр: %A" result
    0
