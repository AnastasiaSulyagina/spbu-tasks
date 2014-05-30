 //Sulyagina Anastasia (c) 2014
//Map'cps

module Map'cps

let rec map'cps f l g =
    match l with
        | [] -> g []
        | hd::tl -> f hd (fun x -> map'cps f tl (fun y -> g (x::y)))
