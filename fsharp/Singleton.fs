module Singleton


type DataBase private () = 

    static let mutable instance: DataBase option = None


    let mutable data: Map<string, string> = Map.empty


    static member getInstance(): DataBase = 
        match instance with
        | Some db -> db // NOTE: Этот момент изучить нужно
        | None -> 
            let newInstance = DataBase()
            instance <- Some newInstance
            newInstance


    member this.printValue(key: string) = 
        let isContains, value = data.TryGetValue key
        // bool * string - тип кортежа в F#
        
        if isContains then 
            printfn "%s" value
        else
            printfn "Нету тут никого."


    member this.setValue(key: string, value: string) = 
        data <- data.Add(key, value) 


let singletonTest() = 
    let db = DataBase.getInstance()

    db.setValue("Лол", "Бомжур!!!")
    db.printValue "Лол"


    DataBase.getInstance().printValue "Лол"



