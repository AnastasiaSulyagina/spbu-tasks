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

type NewWind () =
    let rand = System.Random();
    interface IWind with
        member x.Speed = let y = rand.Next() % 11
                         printf "%A " y
                         y

type NewDaylight () = 
    let rand = System.Random();
    interface IDaylight with
        member x.Current = 
            match rand.Next() % 4 with
                  | 0 -> printf "%A " DaylightType.Morning
                         DaylightType.Morning
                  | 1 -> printf "%A " DaylightType.Noon
                         DaylightType.Noon                  
                  | 2 -> printf "%A " DaylightType.Evening
                         DaylightType.Evening                  
                  | _ -> printf "%A " DaylightType.Night
                         DaylightType.Night
            

type NewLuminary () = 
    let rand = System.Random();
    interface ILuminary with 
        member x.IsShining =
            match rand.Next() % 3 with
                  | 0 -> printf "Not shining "
                         false
                  | _ -> printf "Shining "
                         true


type Cloud (daylight : IDaylight, luminary : ILuminary, wind : IWind, magic : IMagic) =

    member private x.InternalCreate() =
        let speed = wind.Speed
        let current = daylight.Current
        let isShining = luminary.IsShining
        if isShining then 
            match current with
                | DaylightType.Morning -> CourierType.Daemon, if speed <= 2 then new Creature(CreatureType.Bat)
                                                              else new Creature(CreatureType.Puppy)
                | DaylightType.Noon -> CourierType.Stork, if speed <= 2 then new Creature(CreatureType.Bearcub)
                                                          else new Creature(CreatureType.Hedgehog)
                | DaylightType.Evening -> CourierType.Daemon, if speed <= 2 then new Creature(CreatureType.Kitten)
                                                              else new Creature(CreatureType.Balloon)
                | DaylightType.Night -> CourierType.Stork, if speed <= 2 then new Creature(CreatureType.Hedgehog)
                                                           else new Creature(CreatureType.Piglet)
        else
            match current with
                | DaylightType.Morning -> CourierType.Stork, if speed <= 2 then new Creature(CreatureType.Piglet)
                                                             else new Creature(CreatureType.Bat)
                | DaylightType.Noon -> CourierType.Daemon, if speed <= 2 then new Creature(CreatureType.Puppy)
                                                           else new Creature(CreatureType.Hedgehog)
                | DaylightType.Evening -> CourierType.Stork, if speed <= 2 then new Creature(CreatureType.Bearcub)
                                                             else new Creature(CreatureType.Balloon)
                | DaylightType.Night -> CourierType.Daemon, if speed <= 2 then new Creature(CreatureType.Hedgehog)
                                                            else new Creature(CreatureType.Kitten)

    member x.Create() =
        let courier, creature = x.InternalCreate()
        //let magic = new Magic() :> IMagic   
        if courier = CourierType.Daemon then magic.CallDaemon().GiveBaby(creature)
        else magic.CallStork().GiveBaby(creature)
        courier, creature

