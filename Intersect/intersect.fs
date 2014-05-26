 // Anastasia Sulyagina
// Intersection

type Set =
    | Point of float * float
    | Line of float * float
    | Vertical of float 
    | Segment of (float * float) * (float * float)
    | Empty

let intersectPointPoint (x, y) (x1, y1) =
    if x = x1 && y = y1 then Point (x, y)
        else Empty

let intersectVerticalVertical a b =
    if a = b then Vertical a
        else Empty
        
let intersectPointVertical (x, y) x0 =
    if x = x0 then Point (x, y)
    else Empty

let intersectVerticalLine x (a, b) =
    Point (x, a * x + b)

let intersectPointLine (a, b) (x, y) =
    if a * x + b = y then Point (x, y)
        else Empty

let intersectLineLine (a, b) (c, d) =
    if a = c then
        if b = d then Line (a, b)
        else Empty
    else
        let x = (d - b) / (a - c) in
        Point (x, a * x + b)
        
let intersectVerticalSegment a (c, d) (e, f) =
    if (a = c) && (a = e) then Vertical a
    else if abs(c - a) + abs(e - a) = abs(c - e) 
         then Point (a, (a - c)*(f - d)/(e - c) + d)
    else Empty

let intersectPointSegment (a, b) (c, d) (e, f) =
    if (abs(c - a) + abs(e - a) = abs(c - e)) && (abs(d - b) + abs(f - b) = abs(d - f)) then
        if c = e then intersectPointVertical (a, b) c
        else intersectPointLine (a, b) ((f - d)/(e - c), c*(d - f)/(e - c) + d)
    else Empty

let intersectLineSegment (a, b) (c, d) (e, f) =
    match intersectLineLine (a, b) ((f - d) / (e - c), (c * (d - f) / (e - c) + d)) with
        | Line _ -> Segment ((c, d), (e, f))
        | Point (x, y) -> intersectPointSegment (x, y) (c, d) (e, f)
        | _ -> Empty

let intersectSegmentSegment (c, d) (e, f) (m, n) (k, l) =
    let a' = k - m
    let b' = c - e
    let c' = c - m
    let d' = l - n
    let e' = d - f
    let f' = d - n

    if a' * e' = b' * d' then
        if a' * f' = c' * d' then
            let p1 = intersectPointSegment (k, l) (c, d) (e, f)
            let p2 = intersectPointSegment (m, n) (c, d) (e, f)
            let p3 = intersectPointSegment (e, f) (m, n) (k, l)
            let p4 = intersectPointSegment (c, d) (m, n) (k, l)

            match (p1, p3) with
                | (Point (x1, y1), Point (x2, y2)) -> Segment ((x1, y1), (x2, y2))
                | (Point (x1, y1), Empty) -> 
                    match (p2, p4) with
                        | (_, Point (x2, y2)) | (Point (x2, y2), _) -> Segment ((x1, y1), (x2, y2))
                        | _ -> Empty
                | (Empty, Point(x2, y2)) -> 
                    match (p2, p4) with
                        | (Point (x1, y1), _) | (_, Point (x1, y1)) -> Segment ((x1, y1), (x2, y2))
                        | _ -> Empty
                | (Empty, Empty) -> 
                    match (p2, p4) with
                        | (Point (x1, y1), Point (x2, y2)) -> Segment ((x1, y1), (x2, y2))
                        | _ -> Empty
                | _ -> Empty
        else Empty
    else
        let t1 = (c'*e' - b'*f') / (a'*e' - b'*d')
        let t2 = (a'*f' - c'*d') / (a'*e' - b'*d')

        if (t1 >= 0.0) && (t1 <= 1.0) && (t2 >= 0.0) && (t2 <= 1.0) 
        then Point (m + t1*a', n + t1*d')
        else Empty

let intersect (set1, set2) =
    match set1, set2 with
        | Vertical x, Line (a, b) | Line (a, b), Vertical x -> intersectVerticalLine x (a, b)
        | Point (x, y), Point (x1, y1) -> intersectPointPoint (x, y) (x1, y1)
        | Vertical a, Vertical b -> intersectVerticalVertical a b
        | Point (x, y), Line (a, b) | Line (a, b), Point (x, y) -> intersectPointLine (a, b) (x, y)
        | Line (a, b), Line (c, d) -> intersectLineLine (a, b) (c, d)
        | Point (x, y), Vertical x0 | Vertical x0, Point (x, y) -> intersectPointVertical (x, y) x0
        | Point (x, y), Segment ((a, b), (c, d)) | Segment ((a, b), (c, d)), Point (x, y) -> intersectPointSegment (x, y) (a, b) (c, d)
        | Vertical x, Segment ((a, b), (c, d)) | Segment ((a, b), (c, d)), Vertical x -> intersectVerticalSegment x (a, b) (c, d)
        | Line (u, v), Segment ((a, b), (c, d)) | Segment ((a, b), (c, d)), Line (u, v) ->  intersectLineSegment (u, v) (a, b) (c, d)
        | Segment ((e, f), (g, h)), Segment ((a, b), (c, d)) | Segment ((a, b), (c, d)), Segment ((e, f), (g, h)) -> intersectSegmentSegment (a, b) (c, d) (e, f) (g, h)
        | _ -> Empty


        







