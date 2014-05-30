 //Sulyagina Anastasia
//Web crawler
module web

open System
open WebR
open Map'cps

let imgCount page =
    let rec imgCount' (page : string) (pos : int) =
        let x = page.IndexOf("<img", pos)
        if x = -1
        then 0
        else 1 + imgCount' page (x + 1)
    imgCount' page 0

let rec getLink x =
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
    match x with
        | [] -> []
        | hd::tl -> getLink' hd 0 @ getLink tl


let rec getImg l f =
    let check = ref false
    let rec wait() =
         while !check = false 
            do System.Threading.Thread.Sleep(100)
    let x = map'cps getUrl l (fun x -> f (Seq.toList (Seq.distinct (getLink x)))
                                       check := true)
    wait()


getImg [ "http://www.yandex.ru/"; "http://www.4pda.ru/"] (printfn "%A")
 