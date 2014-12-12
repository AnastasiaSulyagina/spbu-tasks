module Tests

open NUnit.Framework
open NSubstitute
open FsCheck
open World
open cloud
    
let test (isShining : bool) (light : DaylightType) (speed : int) (expectedCourier : CourierType) (expectedCreature : CreatureType) =
    let luminary = Substitute.For<ILuminary>()
    let wind = Substitute.For<IWind>()
    let daylight = Substitute.For<IDaylight>()
    let magic = Substitute.For<IMagic>()
    let courier = Substitute.For<ICourier>()

    ignore <| luminary.IsShining.Returns(isShining) 
    ignore <| wind.Speed.Returns(speed)
    ignore <| daylight.Current.Returns(light)
    ignore <| magic.CallDaemon().Returns(courier)
    ignore <| magic.CallStork().Returns(courier)

    let (returnedCourier, returnedCreature) = (new Cloud(daylight, luminary, wind, magic)).Create()

    if expectedCourier = Stork then ignore <| magic.Received(1).CallStork()
                                    ignore <| magic.DidNotReceive().CallDaemon
    else ignore <| magic.Received(1).CallDaemon()
         ignore <| magic.DidNotReceive().CallStork()
    
    courier.Received().GiveBaby(returnedCreature)
    (returnedCreature.creatureType, returnedCourier) = (expectedCreature, expectedCourier)


[<Test>]
let testShineWindyMorning() = Assert.IsTrue(test true DaylightType.Morning 10 CourierType.Daemon CreatureType.Puppy)

[<Test>]
let testShineWindyNoon() = Assert.IsTrue(test true DaylightType.Noon 10 CourierType.Stork CreatureType.Hedgehog)

[<Test>]
let testShineWindyEvening() = Assert.IsTrue(test true DaylightType.Evening 10 CourierType.Daemon CreatureType.Balloon)

[<Test>]
let testShineWindyNight() = Assert.IsTrue(test true DaylightType.Night 10 CourierType.Stork CreatureType.Piglet)

[<Test>]
let testShineNonWindyMorning() = Assert.IsTrue(test true DaylightType.Morning 1 CourierType.Daemon CreatureType.Bat)

[<Test>]
let testShineNonWindyNoon() = Assert.IsTrue(test true DaylightType.Noon 1 CourierType.Stork CreatureType.Bearcub)

[<Test>]
let testShineNonWindyEvening() = Assert.IsTrue(test true DaylightType.Evening 1 CourierType.Daemon CreatureType.Kitten)

[<Test>]
let testShineNonWindyNight() = Assert.IsTrue(test true DaylightType.Night 1 CourierType.Stork CreatureType.Hedgehog)

[<Test>]
let testNonShineWindyMorning() = Assert.IsTrue(test false DaylightType.Morning 10 CourierType.Stork CreatureType.Bat)

[<Test>]
let testNonShineWindyNoon() = Assert.IsTrue(test false DaylightType.Noon 10 CourierType.Daemon CreatureType.Hedgehog)

[<Test>]
let testNonShineWindyEvening() = Assert.IsTrue(test false DaylightType.Evening 10 CourierType.Stork CreatureType.Balloon)

[<Test>]
let testNonShineWindyNight() = Assert.IsTrue(test false DaylightType.Night 10 CourierType.Daemon CreatureType.Kitten)

[<Test>]
let testNonShineNonWindyMorning() = Assert.IsTrue(test false DaylightType.Morning 1 CourierType.Stork CreatureType.Piglet)

[<Test>]
let testNonShineNonWindyNoon() = Assert.IsTrue(test false DaylightType.Noon 1 CourierType.Daemon CreatureType.Puppy)

[<Test>]
let testNonShineNonWindyEvening() = Assert.IsTrue(test false DaylightType.Evening 1 CourierType.Stork CreatureType.Bearcub)

[<Test>]
let testNonShineNonWindyNight() = Assert.IsTrue(test false DaylightType.Night 1 CourierType.Daemon CreatureType.Hedgehog)
        

type IntGenerator0_2 = static member Wnd() = Arb.fromGen <| Gen.choose(0, 2)
type IntGenerator3_10 = static member Wnd() = Arb.fromGen <| Gen.choose(3, 10)

