module Tests

open NUnit.Framework
open NSubstitute
open FsCheck
open World
open cloud
                   
let test lum light windSpeed rightCourier rightCreature = 
    let luminary = new Luminary(lum) :> ILuminary
    let daylight = new Daylight(light) :> IDaylight
    let wind = new Wind(windSpeed) :> IWind
    let magic = new Magic() :> IMagic
    let cloud = new Cloud (daylight, luminary, wind, magic)
    let courier, creature = cloud.Create() 
    (courier = rightCourier && creature.creatureType = rightCreature)
        

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

//Последний тест выдает ошибку. Вроде все загружено и правильно, снова не могу понять, что не так. Попробую переставить студию, а то совсем ничего не работает. Может у Вас запустится

//System.IO.FileLoadException : Не удалось загрузить файл или сборку "FSharp.Core, Version=4.3.1.0, 
//Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" либо одну из их зависимостей. Найденное определение 
//манифеста сборки не соответствует ссылке на сборку. (Исключение из HRESULT: 0x80131040)

[<Test>]
let ``with fscheck 1`` () = 
    let tst (wnd: int) = 
        test true DaylightType.Morning wnd CourierType.Daemon CreatureType.Puppy
    Arb.register<IntGenerator3_10>() |> ignore
    Check.Quick tst

