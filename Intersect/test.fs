open Intersect
open NUnit.Framework


[<TestFixture>]
module Tests =
    [<Test>]
    let Test1 () =
        Assert.AreEqual((intersect(Empty, Empty)), Empty)
    [<Test>]
    let Test2 () =
        Assert.AreEqual((intersect(Point(0.0, 0.1), Point(0.0, 0.0))), Empty)
    [<Test>]
    let Test3 () =
        Assert.AreEqual((intersect(Point(1.0, 0.0), Vertical 1.0)), Point(1.0, 0.0))
    [<Test>]
    let Test4 () =
        Assert.AreEqual((intersect(Point(1.0, 1.0), Line(1.0, 0.0))), Point(1.0, 1.0))
    [<Test>]
    let Test5 () =
        Assert.AreEqual((intersect(Line(1.0, 5.0), Line(1.0, 5.0))), Line(1.0, 5.0))
    [<Test>]
    let Test6 () =
        Assert.AreEqual((intersect(Point(1.0, 1.0), Line(1.0, 0.0001))), Empty)
    [<Test>]
    let Test7 () =
        Assert.AreEqual((intersect(Vertical 2.0, Point(1.0, 0.0))), Empty)
    [<Test>]
    let Test8 () =
        Assert.AreEqual((intersect(Point(1.0, 1.0), Segment((0.0, 0.0), (2.0, 2.0)) )), Point(1.0, 1.0))
    [<Test>]
    let Test9 () =
        Assert.AreEqual((intersect(Line(1.0, 5.0), Line(-3.0, 2.0))), Point(-0.75, 4.25))
    [<Test>]
    let Test10 () =
        Assert.AreEqual((intersect(Point(10.0, 10.0), Segment((1.0, 2.0), (2.0, 1.0)) )), Empty)
    [<Test>]
    let Test11 () =
        Assert.AreEqual((intersect(Point(1.0, 1.0), Point(1.0, 1.0))), Point(1.0, 1.0))
    [<Test>]
    let Test12 () =
        Assert.AreEqual((intersect(Segment((0.0, 0.0),(10.0,10.0)), Segment((10.0,10.0),(10.0,0.0)))), Point(10.0, 10.0))
    [<Test>]
    let Test13 () =
        Assert.AreEqual((intersect((Segment ((0.0, 0.0), (3.0, 3.0))), (Segment ((2.0, 2.0), (4.0, 4.0))))), Segment((2.0, 2.0), (3.0, 3.0)))
    [<Test>]
    let Test14 () =
        Assert.AreEqual((intersect(Segment((-1.0, -1.0),(0.0, 0.0)), Line(1.0, 0.0))), Segment((-1.0, -1.0),(0.0, 0.0)))