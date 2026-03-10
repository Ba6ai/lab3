open System

// Создание списка
let rec numberss(currentlist: int list) : int list = 
    printfn "Введите числа (через Enter), для выхода введите 'ex':"
    let x = Console.ReadLine()
    if x = "ex" then
        currentlist
    else
        numberss(currentlist @ [int(x)])

// Получение первой цифры числа
let search n = 
    let s = string n
    int(string s.[0]) // Получение первого символа в строке .[0]

// Поиск суммы
let sum target list =
    list |> Seq.fold (fun a x -> // Анонимная функция
        if search x  = target then
            a+x
        else
            a
    )0

[<EntryPoint>]
let main _ =
    let numbers = numberss[]

    printfn "Введите цифру c которой должны начинаться числа"
    let target = int(Console.ReadLine())
    printfn "%A" target

    let res = sum target numbers
    
    printfn "Список: %A" numbers
    printfn "Сумма числе начинающихся на %d: %d" target res
    0