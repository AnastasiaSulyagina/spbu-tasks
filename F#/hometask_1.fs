 //Sulyagina Anastasia (c) 2014
//Hometask 1

let l = [1; 2; 3; 4; 5]
let m = [6; 7; 8]  

let cmp =
    fun x -> x < 3

// list concatenation
let rec concat l m =
    match l with
        | [] -> m
        | hd::tl -> hd :: concat tl m

//add to the end of list
let rec add vl l =
    match l with
        | [] -> vl :: []
        | hd::tl -> hd :: add vl tl

//filter
let rec filter cmp l =
    match l with
        | [] -> []
        | hd::tl -> if cmp hd then hd :: filter cmp tl
                    else filter cmp tl

//sqr list generation
let rec create i n =
        if n < i * i then []
        else i * i :: create (i + 1) n

//list length
let len l =
    let rec len' l acc =
        match l with
            | [] -> acc
            | (hd::tl) ->  len' tl (1 + acc)
    in len' l 0

    
//list sum
let sum l =
    let rec sum' l acc =
        match l with
            | [] -> acc
            | (hd::tl) -> sum' tl (hd + acc)
    in sum' l 0

        