[1..100]
    |> List.map (fun x ->
        match x with
        | i when i % 15 = 0 -> printfn "%d fizzbuzz" i
        | i when i % 5 = 0 -> printfn "%d buzz" i
        | i when i % 3 = 0 -> printfn "%d fizz" i
        | _ -> printfn "%d" x)  