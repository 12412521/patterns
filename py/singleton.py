
from typing import Optional


class DataBase:

    _instance = None 

    def __new__(cls) -> "DataBase":
        if not DataBase._instance:
            cls._instance = super().__new__(cls)
            cls._instance.data = {}
        
        return cls._instance # type: ignore
    
    def setValue(self, key: str, value: str):
        self.data[key] = value
    
    def printValue(self, key: str):
        print(self.data[key])

d = DataBase()
d.setValue("Лол", "Бомжур!!!")
d.printValue("Лол")
DataBase().printValue("Лол")
