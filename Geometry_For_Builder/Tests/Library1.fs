namespace Tests

module Tests = 
    open System
    open Logic
    open NUnit.Framework

    [<Test>]
    let ``Intersect in point``() =
        let a = new Circle(10.0, 10.0, 10.0);
        let b = new Circle(20.0, 10.0, 10.0);
        Assert.IsTrue(Geometry.Check(a, b));

    [<Test>]
    let ``Do not intersect``() = 
        let a = new Circle(10.0, 10.0, 10.0);
        let b = new Circle(30.0, 10.0, 10.0);
        Assert.IsFalse(Geometry.Check(a, b));

    [<Test>]
    let ``Intersect in field``() = 
        let a = new Circle(10.0, 10.0, 10.0);
        let b = new Circle(15.0, 10.0, 10.0);
        Assert.IsTrue(Geometry.Check(a, b));

    [<Test>]
    let ``Fully coincide``() = 
        let a = new Circle(10.0, 10.0, 10.0);
        let b = new Circle(10.0, 10.0, 10.0);
        Assert.IsTrue(Geometry.Check(a, b));    
        
    [<Test>]
    let ``Are coinciding points``() = 
        let a = new Circle(10.0, 10.0, 0.0);
        let b = new Circle(10.0, 10.0, 0.0);
        Assert.IsFalse(Geometry.Check(a, b));


