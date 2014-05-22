 //Sulyagina Anastasia (c) 2014
//Map using AVL Tree


open System
open System.Collections
open System.Collections.Generic
    
type Tree<'Key, 'Value> =
    | Empty
    | Node of 'Key * 'Value * Tree<'Key, 'Value> * Tree<'Key, 'Value> * int

 
let isEmpty m =
    match m with
        | Empty -> true
        | _ -> false

let key = function
    | Empty -> failwith "Tree does not exist"
    | Node(x, _, _, _, _) -> x
         
let value = function
    | Empty -> failwith "Tree does not exist"
    | Node(_, x, _, _, _) -> x

let left = function
    | Empty -> failwith "Tree does not exist"
    | Node(_, _, x, _, _) -> x

let right = function
    | Empty -> failwith"Tree does not exist"
    | Node(_, _, _, x, _) -> x

let height = function
    | Empty -> 0
    | Node(_, _, _, _, x) -> x

let rec count = function
    | Empty -> 0
    | Node(_, _, l, r, _) -> count l + 1 + count r

let makeNode k v l r =
    let hl = height l
    let hr = height r
    let m = if hl < hr then hr else hl
    Node(k,v,l,r,m+1)

    
let rotateLeft = function
    | Node(k, v, l, Node(k2, v2, l2, r2, h2), h) as t ->
        makeNode k2 v2 (makeNode k v l l2) r2 
    | _ -> failwith "Failed to balance tree"
         
let rotateRight = function
    | Node(k, v, Node(k2, v2, l2, r2, h2), r, h) as t ->
        makeNode k2 v2 l2 (makeNode k v r2 r) 
    | _ -> failwith "Failed to balance tree"

let rebalance = function
    | Empty -> Empty
    | Node(k, v, l, r, h) as t ->
        if height r - height l > 1 then
            if not (height (left r) <= height (right r) )
            then makeNode k v l (rotateRight r) 
            else t |> rotateLeft
        elif height l - height r > 1 then
            if not (height (right l) <= height(left l) )
            then makeNode k v (rotateLeft l) r 
            else t |> rotateRight
        else t

let rec add k v = function
    | Empty -> Node(k, v, Empty, Empty, 1)
    | Node(k1, v1, l, r, _) ->
        if k < k1 then makeNode k1 v1 (add k v l) r
        else makeNode k1 v1 l (add k v r)
        |> rebalance

let rec findInLeft = function
    | Empty -> failwith "Node not found"
    | Node(k, v, l, r, _) as node -> if height r = 0 then node
                                        else findInLeft r

let rec findInRight = function
    | Empty -> failwith "Node not found"
    | Node(k, v, l, r, _) as node -> if height l = 0 then node
                                        else findInRight l

let rec remove k = function
    | Empty -> Empty
    | Node(k1, v1, l, r, _) when k <> k1 ->
        if k < k1
        then makeNode k1 v1 (remove k l) r
        else makeNode k1 v1 l (remove k r)
        |> rebalance
    | Node(k, v, l, r, _) as t ->
        if isEmpty l && isEmpty r then Empty
        else
            if height l > height r then
                let v = findInRight l
                makeNode (key v) (value v) (remove (key v) l) r 
            else
                let v = findInLeft r
                makeNode (key v) (value v) l (remove (key v) r)  
            |> rebalance

type Map<'Key, 'Value  when 'Key: comparison> (tree:Tree<'Key, 'Value>) = 
   
    member this.IsEmpty = isEmpty tree
    member this.Add key value = new Map<_, _>(add key value tree)
    member this.Count = count tree
    member this.Remove key = new Map<_, _>(remove key tree)
    member this.TryFind key =
        let rec TryFind key tree =
            match tree with
                | Empty -> None
                | Node(k, v, l, r, _) -> if key = k then Some(v)
                                         elif key > k then TryFind key r
                                         else TryFind key l
        TryFind key tree
    member this.ContainsKey = Option.isSome << this.TryFind
    member this.Item = Option.get << this.TryFind
    override this.ToString() =
            let rec ToString = function
                | Empty -> "Empty"
                | Node(k, v, l, r, h) ->
                    "Node(" + k.ToString() + ", " + v.ToString() + ToString l + ", " + ToString r + ", " + ")"
            ToString tree

    member this.getEnumerator() =
        let rec toList = function
            | Empty -> []
            | Node(k, v, l, r, h) -> toList l @ (k, v) :: toList r
        let list = toList tree
        let curList = ref list
        let isStart = ref true
        let current() =
            if !isStart then failwith("Current iterator not found")
            else (!curList).Head

        {new IEnumerator<'Key * 'Value> with
                member this.Current = current()
            interface IEnumerator with
                member this.Current = current() :> obj

                member this.MoveNext() =
                    if !isStart then isStart := false
                    curList := (!curList).Tail
                    not (!curList).IsEmpty

                member this.Reset() =
                    isStart := true
                    curList := list
                
            interface System.IDisposable with
                member this.Dispose() = ()
        }

    interface IEnumerable<'Key * 'Value> with
        member this.GetEnumerator() = this.getEnumerator()
    interface IEnumerable with
        member this.GetEnumerator() = this.getEnumerator() :> IEnumerator

let m = new Map<_,_>(Empty)
let m1 = m.Add 1 1
let m2 = m1.Add 2 2
let m3 = m2.Add 3 3
printfn "%A" m3.Count
