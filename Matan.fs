 // Anastasia Sulyagina (c) 2014
// Objective matan world

//humans

type Human (name:string) =
    let mutable skill = 5
    let mutable health = 5
    member this.Skill = skill
    member this.Health = health
    member this.Name = name
    member this.ChangeSkill (value:int) = 
        skill <- (if this.Skill + value >= 0 && this.Skill + value <= 10 
        then this.Skill + value 
        else if this.Skill + value < 0 then 0
        else if value > 10 this.Skill + value 
        else 10)
    member this.ChangeHealth (value:int) = 
        health <- (if this.Health + value >= 0 && this.Health + value <= 10 
                   then this.Health + value 
                   else if this.Health + value < 0 then 0
                   else if value > 10 this.Health + value 
                   else 10) 

type Student (name:string) = 
    inherit Human(name)
    let mutable status = "student"
    member this.Status = status
    member this.ChangeStatus (newStatus:string) = status <- newStatus 

type Tarasov (name:string) = 
    inherit Human(name)
    let mutable mood = 1
    member this.Mood = mood    
    member this.GODMODE() = 
        this.ChangeSkill(100000000)
        this.ChangeHealth(100000000)
        mood <- mood + 1
    member this.Mock (student:Student) = 
        student.ChangeSkill (-this.Mood)
        this.GODMODE ()

//monsters

type Monster (power:int) =
    let mutable pow = power
    member this.Power = pow
    member this.LosePower() = pow <- 0

type Integral (power:int) =
    inherit Monster(power)
    member this.Integrate (human:Human) = 
        human.ChangeSkill (1)
        if human.Skill > this.Power then human.ChangeHealth (this.Power)
                                         this.LosePower()
        else human.ChangeHealth (-this.Power)
                                                   
type GreenMan (power:int) =
    inherit Monster(power)
    member this.CheckForArmy (student:Student) = 
        if student.Skill = 0 then student.ChangeStatus ("soldier")
                                  student.ChangeHealth (10 - student.Health)  
        else if student.Health = 0 then student.ChangeStatus ("dead")    

type Hedgehog (power:int) =
    inherit Monster(power)
    member this.GetHeadKick (human:Human) = 
        human.ChangeSkill (this.Power)
        this.LosePower()
    member this.LaughAt (student:Student) = 
        student.ChangeSkill (-this.Power)
       
type HungryHedgehog (power:int) =
    inherit Hedgehog(power)
    let mutable hunger = power
    member this.Hunger = hunger
    member this.Eat (human:Human) = human.ChangeHealth (-this.Hunger)
        
//test        
        
let Vasya = new Student("Vasya")
let Tarasov171 = new Tarasov("Alexandr")
let littleHedgehog = new HungryHedgehog(2)
let bigHedgehog = new HungryHedgehog(6)
let easyThing = new Integral(1)
let complicatedStuff = new Integral(6)
let Petr = new GreenMan(10)

Petr.CheckForArmy (Vasya)               // lol go away
easyThing.Integrate (Vasya)             // success (skill + 1, health + 1)
Tarasov171.Mock (Vasya)                 // :c ( Vasya : (skill - 1), Tarasov -> GODMODE )
bigHedgehog.Eat (Tarasov171)            // HAHA USELESS
bigHedgehog.GetHeadKick (Tarasov171)    // Sweet revenge
easyThing.Integrate(Vasya)              // success (skill + 1, health + 1)
littleHedgehog.LaughAt(Vasya)           // :c (skill - 1)
complicatedStuff.Integrate(Vasya)       // fail (skill + 1, health - 6)
littleHedgehog.Eat(Vasya)               // omnomnom (Vasya : health - 1)
littleHedgehog.GetHeadKick (Vasya)      // DIE YOU (Hedgehog : dead, Vasya : skill + 1)
Petr.CheckForArmy (Vasya)               // Oops he is dead
printfn "%A" Vasya.Status               // the end
