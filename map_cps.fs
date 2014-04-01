 //Sulyagina Anastasia (c) 2014
//Map'cps

let dbl x f = f (x * 2);

let rec map'cps f l g =
    match l with
        | [] -> g []
        | hd::tl -> f hd (fun a -> map'cps f tl (fun b -> g (a::b)))

let l = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

map'cps dbl l (printfn "%A")
