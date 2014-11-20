module cloud

open World

type Courier () =
    interface ICourier with
        member x.GiveBaby _ = ()

type Magic () =
    interface IMagic with 
        member x.CallStork() = new Courier() :> ICourier
        member x.CallDaemon() = new Courier() :> ICourier

type Daylight (value) = 
    interface IDaylight with
        member x.Current = value

type Luminary (value) = 
    interface ILuminary with 
        member x.IsShining = value

type Wind (value) =
    interface IWind with
        member x.Speed = value

type Cloud (daylight : IDaylight, luminary : ILuminary, wind : IWind, magic : IMagic) =
//    let daylight = new Daylight() :> IDaylight
//    let luminary = new Luminary() :> ILuminary
//    let wind = new Wind() :> IWind

    member private x.InternalCreate() =
        if luminary.IsShining then 
            match daylight.Current with
                | DaylightType.Morning -> CourierType.Daemon, if wind.Speed <= 2 then new Creature(CreatureType.Bat)
                                                              else new Creature(CreatureType.Puppy)
                | DaylightType.Noon -> CourierType.Stork, if wind.Speed <= 2 then new Creature(CreatureType.Bearcub)
                                                          else new Creature(CreatureType.Hedgehog)
                | DaylightType.Evening -> CourierType.Daemon, if wind.Speed <= 2 then new Creature(CreatureType.Kitten)
                                                              else new Creature(CreatureType.Balloon)
                | DaylightType.Night -> CourierType.Stork, if wind.Speed <= 2 then new Creature(CreatureType.Hedgehog)
                                                           else new Creature(CreatureType.Piglet)
        else
            match daylight.Current with
                | DaylightType.Morning -> CourierType.Stork, if wind.Speed <= 2 then new Creature(CreatureType.Piglet)
                                                             else new Creature(CreatureType.Bat)
                | DaylightType.Noon -> CourierType.Daemon, if wind.Speed <= 2 then new Creature(CreatureType.Puppy)
                                                           else new Creature(CreatureType.Hedgehog)
                | DaylightType.Evening -> CourierType.Stork, if wind.Speed <= 2 then new Creature(CreatureType.Bearcub)
                                                             else new Creature(CreatureType.Balloon)
                | DaylightType.Night -> CourierType.Daemon, if wind.Speed <= 2 then new Creature(CreatureType.Hedgehog)
                                                            else new Creature(CreatureType.Kitten)
 
    member x.Create() =
      let courier, creature = x.InternalCreate()
      //let magic = new Magic() :> IMagic   
      if courier = CourierType.Daemon then magic.CallDaemon().GiveBaby(creature)
      else magic.CallStork().GiveBaby(creature)
      courier, creature

