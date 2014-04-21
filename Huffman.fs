 // Sulyagina Anastasia (c)2014
 // Huffman

type CodeTree =
  | Fork of CodeTree * CodeTree * char list * int
  | Leaf of char * int


// code tree

let createCodeTree (chars: char list) : CodeTree =
    failwith "Not implemented"

let tree = Fork ( Fork (Leaf ('a', 3), Leaf('b', 2), ['a'; 'b'], 5), Fork (Leaf ('c', 2), Leaf('d', 1), ['c'; 'd'], 3) , ['a'; 'b'; 'c'; 'd'], 8)

// encode

type Bit = int

let rec findBit tree chr =
    match tree with
        | Fork (a, b, c, d) -> if List.exists (fun x -> x = chr) c then
                                    if findBit a chr = [-1] then 1 :: findBit b chr
                                    else 0 :: findBit a chr
                               else [-1]
        | Leaf (a, b) -> if a = chr then []
                         else [-1]

let rec encode (tree: CodeTree) (text: char list) : Bit list =
    match text with
        | [] -> []
        | hd::tl -> (findBit tree hd)@(encode tree tl)
    
printfn "%A" (encode tree ['a'; 'a'; 'b'; 'c'; 'a'; 'b'; 'c'; 'd'])


// decode

let rec getSymb tree bits =
    match bits with
        | [] -> match tree with
                            | Leaf(a, b) -> (a , [])
                            | _ -> (' ', [])
        | hd::tl -> match tree with
                            | Leaf(a, b) -> (a , hd::tl)
                            | Fork (a, b, c, d) -> if hd = 0 then getSymb a tl
                                                   else getSymb b tl
    
let rec decode (tree: CodeTree) (bits: Bit list) : char list =
    match bits with
        | [] -> []
        | hd::tl -> match getSymb tree bits with
                |(b, c) -> b :: decode tree c
    
printfn "%A" (decode tree (encode tree ['a'; 'a'; 'b'; 'c'; 'a'; 'b'; 'c'; 'd']))
