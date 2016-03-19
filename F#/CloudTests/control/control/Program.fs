// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
module program
open World
open cloud

[<EntryPoint>]
let main argv = 
    let daylight = new NewDaylight()
    let luminary = new NewLuminary()
    let wind = new NewWind()
    let magic = new Magic()
    let cloud = new Cloud(daylight, luminary , wind , magic)
    for i = 0 to 10 do
        let (courier, creature) = cloud.Create()
        printfn "%A %A" courier creature.creatureType

    0 // return an integer exit code
