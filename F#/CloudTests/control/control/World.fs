module World

type CreatureType =
    | Puppy
    | Kitten
    | Hedgehog
    | Bearcub
    | Piglet
    | Bat
    | Balloon

type DaylightType =
    | Morning
    | Noon
    | Evening
    | Night

type CourierType =
    | Daemon
    | Stork
    
type Creature (cType:CreatureType) =
    member x.creatureType = cType
    
type ILuminary =
    abstract member IsShining:bool

type IDaylight =
    abstract member Current: DaylightType

type IWind =
    abstract member Speed:int

type ICourier =
    abstract member GiveBaby : Creature -> unit

type IMagic =
    abstract member CallStork : unit -> ICourier
    abstract member CallDaemon : unit -> ICourier
    
