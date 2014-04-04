module Huffman

type CodeTree = 
  | Fork of CodeTree * CodeTree * char list * int
  | Leaf of char * int


// code tree

let createCodeTree (chars: char list) : CodeTree = 
    failwith "Not implemented"

// decode

type Bit = int



let rec find tree chr =
    match tree with
        | Fork (a, b, c, d) -> if List.exists (fun x -> x = chr) c then 
                                    if find a chr = [-1] then 1 :: find b chr
                                    else 0 :: find a chr 
                               else [-1]
        | Leaf (a, b) -> if a = chr then []
                         else [-1]


let rec encode (tree: CodeTree) (text: char list) : Bit list = 
    match text with
        | [] -> []
        | hd::tl -> (find tree hd)@(encode tree tl)
    
let tree = Fork ( Fork (Leaf ('a', 3), Leaf('b', 2), ['a'; 'b'], 5), Fork (Leaf ('c', 2), Leaf('d', 1), ['c'; 'd'], 3) , ['a'; 'b'; 'c'; 'd'], 8)

printfn "%A" (encode tree ['a'; 'a'; 'b'; 'c'; 'a'; 'b'; 'c'; 'd'])







let rec getSymb fullTree tree bits =
    match bits with
        | [] -> (' ' , bits)
        | hd::tl -> match tree with 
                            | Leaf(a, b) -> (a , tl)
                            | Fork (a, b, c, d) -> if hd = 0 then getSymb fullTree a tl
                                                   else getSymb fullTree b tl 
    

let rec decode (tree: CodeTree)  (bits: Bit list) : char list = 
    match bits with
        | [] -> []
        | hd::tl -> match getSymb tree tree bits with
                |(b, c) -> b :: decode tree c 
    

  printfn "%A" (decode tree (encode tree ['a'; 'a'; 'b'; 'c'; 'a'; 'b'; 'c'; 'd']))