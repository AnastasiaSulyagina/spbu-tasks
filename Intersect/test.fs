open Intersect
open NUnit.Framework


let eps = 1e-4
let cmp x y = abs(x - y) < eps

let compare (s1, s2) =
    match s1 with
    | Empty -> s1 = s2
    | Point(a, b) -> match s2 with
                     | Point(c, d) -> (cmp a c) && (cmp b d)
                     | _ -> false
    | Line (a, b) -> match s2 with
                     | Line(c, d) -> (cmp a c) && (cmp b d)
                     | _ -> false

    | Vertical x -> match s2 with
                        | Vertical y -> if cmp x y then true
                                        else false
                        | _ -> false
    | Segment ((x1, y1), (x2, y2)) -> match s2 with
                                          | Segment ((x3, y3), (x4, y4)) -> ((cmp x1 x3) && (cmp x2 x4) && (cmp y1 y3) && (cmp y2 y4)) ||
                                                                            ((cmp x1 x4) && (cmp x2 x3) && (cmp y1 y4) && (cmp y2 y3))
                                          | _ -> false

[<TestFixture>]
module Tests =
    [<Test>]
    let Test1 () =
        Assert.AreEqual(compare((intersect(Empty, Empty)), Empty), true)
    [<Test>]
    let Test2 () =
        Assert.AreEqual(compare((intersect(Point(0.0, 0.001), Point(0.0, 0.0))), Empty), true)
    [<Test>]
    let Test3 () =
        Assert.AreEqual(compare((intersect(Point(1.0, 0.0000001), Vertical 1.0)), Point(1.0, 0.0)), true)
    [<Test>]
    let Test4 () =
        Assert.AreEqual(compare((intersect(Point(1.0, 1.0000001), Line(1.0, 0.0))), Point(1.0, 1.0)), true)
    [<Test>]
    let Test5 () =
        Assert.AreEqual(compare((intersect(Line(1.0, 5.0), Line(1.0, 5.0))), Line(1.0, 5.0)), true)
    [<Test>]
    let Test6 () =
        Assert.AreEqual(compare((intersect(Point(1.0, 1.0), Line(1.0, 0.01))), Empty), true)
    [<Test>]
    let Test7 () =
        Assert.AreEqual(compare((intersect(Vertical 2.0, Point(1.0, 0.0))), Empty), true)
    [<Test>]
    let Test8 () =
        Assert.AreEqual(compare((intersect(Point(1.0, 1.0000001), Segment((0.0, 0.0), (2.0, 2.0)) )), Point(1.0, 1.0)), true)
    [<Test>]
    let Test9 () =
        Assert.AreEqual(compare((intersect(Line(1.0, 5.0), Line(-3.0, 2.0))), Point(-0.75, 4.25)), true)
    [<Test>]
    let Test10 () =
        Assert.AreEqual(compare((intersect(Point(10.0, 10.0), Segment((1.0, 2.0), (2.0, 1.0)) )), Empty), true)
    [<Test>]
    let Test11 () =
        Assert.AreEqual(compare((intersect(Point(1.0, 1.0000001), Point(1.0, 1.0))), Point(1.0, 1.0)), true)
    [<Test>]
    let Test12 () =
        Assert.AreEqual(compare((intersect(Segment((0.0, 0.0),(10.0,10.0)), Segment((10.0,10.0000001),(10.0,0.0)))), Point(10.0, 10.0)), true)
    [<Test>]
    let Test13 () =
        Assert.AreEqual(compare((intersect((Segment ((0.0, 0.0), (3.0, 3.0))), (Segment ((2.0, 2.0), (4.0, 4.0))))), Segment((2.0, 2.0), (3.0, 3.0))), true)
    [<Test>]
    let Test14 () =
        Assert.AreEqual(compare((intersect(Segment((-1.0, -1.0),(0.0, 0.0)), Line(1.0, 0.0))), Segment((-1.0, -1.0),(0.0, 0.0))), true)