 //Sulyagina Anastasia
//Web crawler
module web

open System
open WebR

let imgCount page =
    let rec imgCount' (page : string) (pos : int) =
        let x = page.IndexOf("<img", pos)
        if x = -1
        then 0
        else 1 + imgCount' page (x + 1)
    imgCount' page 0

let rec getLink page =
    let rec getLink' (page : string) (pos : int) =
        if imgCount page < 5 then []
        else
            let count = 0
            let x = page.IndexOf("<img", pos)
            if x = -1 then []
            else
                let st = page.IndexOf("src=", x) + 5
                let fin = page.IndexOf("\"", st)
                page.Substring(st, fin - st) :: getLink' page (fin)
    getLink' page 0

let rec getImg l f =
    match l with
        | [] -> f []
        | hd :: tl -> getUrl hd (fun x -> getImg tl (fun y -> f (Seq.toList (Seq.distinct ([getLink x] @ y )))))

getImg [ "http://www.google.com/"; "http://www.4pda.ru/"] (printfn "%A")

Console.ReadLine() |> ignore