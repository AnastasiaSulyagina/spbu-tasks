 //Sulyagina Anastasia (c) 2014
//Hometask 2

// fibonacci sum
let sumFib n=
    let rec fib a b n =
        if a > n then 0L
        else
            if a % 2L = 0L then 
                a + fib b (a+b) n
            else 
                fib b (a+b) n
     in fib 1L 1L n

// greatest prime divisor
let GPD a =
    let rec div a b =
        if a % b = 0L then
            match (a / b) with
                | 1L -> b
                | _ ->  div (a / b) b
        else div a (b + 1L)
    in div a 2L
 
// factorial
let fact n =
    let rec fact' n k =
        if k = n then n
        else k * (fact' n (k + 1I))
    in fact' n 2I

// sum of big digits
let rec sumDig n =
    if n = 0I then 0I
        else (n % 10I) + sumDig (n / 10I)
 

