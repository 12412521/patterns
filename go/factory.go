package main

type IFactory interface {
	GetMessage()
	CreateTransport() ITransport
}

type MachineFactory struct{}

func (t *MachineFactory) CreateTransport() ITransport {
	return &Machine{}
}

func (t *MachineFactory) GetMessage() {
	t.CreateTransport().Message()
}

type BikeFactory struct{}

func (t *BikeFactory) CreateTransport() ITransport {
	return &Bike{}
}

func (t *BikeFactory) GetMessage() {
	t.CreateTransport().Message()
}

type ITransport interface {
	Message()
}

type Machine struct{}
type Bike struct{}

func (t *Machine) Message() {
	print("Врум.\n")
}

func (t *Bike) Message() {
	print("Вжих!\n")
}

func ClientCode(factory IFactory) {
	factory.GetMessage()
}

func main() {
	ClientCode(&MachineFactory{})
	ClientCode(&BikeFactory{})
}
