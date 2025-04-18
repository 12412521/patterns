package main

var instance *DataBase = nil

type DataBase struct {
	data map[string]string
}

func GetInstance() *DataBase {
	if instance == nil {
		instance = &DataBase{
			data: make(map[string]string),
		}
	}

	return instance
}

func (t *DataBase) printValue(key string) {
	println(t.data[key])
}

func (t *DataBase) setValue(key string, value string) {
	t.data[key] = value
}

func main() {
	var data = GetInstance()

	data.setValue("Лол", "Бомжур!!!")
	data.printValue("Лол")
	GetInstance().printValue("Лол")
}
