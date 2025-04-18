// For more information see https://aka.ms/fsharp-console-apps

type ITransport = 

  abstract member message: unit -> unit
  //                       void() -> unit 


[<AbstractClass>]
type IFactory() = 

  abstract member createTransport: unit -> ITransport
  //                                () -> return type

  // this -> IFactory.
  
  member this.getMessage() = 
    let transport = this.createTransport()
    transport.message()


type Machine() = 
  interface ITransport with
    member this.message() = 
      printfn "Врум."

type Bike() = 

  interface ITransport with 

    member this.message () = 
      printfn "Вжих!"


type MachineFactory() = 

  inherit IFactory()
  
  override this.createTransport (): ITransport = 
    new Machine()


type BikeFactory() = 

  inherit IFactory()
  
  override this.createTransport (): ITransport = 
    new Bike()


let ClientCode(factory: IFactory) = 
  factory.getMessage()

ClientCode(new MachineFactory())
ClientCode(new BikeFactory())

Singleton.singletonTest()
