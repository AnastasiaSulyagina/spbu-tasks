module Tests

open EmailChecker
open NUnit.Framework

[<TestFixture>]
type Tests() =
    [<Test>]
    member x.Test1() =
        Assert.IsTrue(isEmail "a@b.cc", "1. OK")

    [<Test>]
    member x.Test2() =
        Assert.IsTrue(isEmail "victor.polozov@mail.ru", "2. OK")

    [<Test>]
    member x.Test3() =
        Assert.IsTrue(isEmail "my@domain.info", "3. OK")

    [<Test>]
    member x.Test4() =
        Assert.IsTrue(isEmail "_.1@mail.com", "4. OK")

    [<Test>]
    member x.Test5() =
        Assert.IsTrue(isEmail "paints_department@hermitage.museum", "5. OK")

    [<Test>]
    member x.Test6() =
        Assert.IsTrue(isEmail "a@b.c", "6. OK")

    [<Test>]
    member x.Test7() =
        Assert.IsTrue(isEmail "a..b@mail.ru", "7. OK")

    [<Test>]
    member x.Test8() =
        Assert.IsTrue(isEmail ".a@mail.ru", "8. OK")

    [<Test>]
    member x.Test9() =
        Assert.IsTrue(isEmail "yo@domain.somedomain", "9. OK")

    [<Test>]
    member x.Test10() =
        Assert.IsTrue(isEmail "1@mail.ru", "10. OK")