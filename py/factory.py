from abc import ABC, abstractmethod

class ITransport(ABC):

  @abstractmethod
  def message(self): ...


class IFactory(ABC):

  @abstractmethod
  def createTransport(self) -> ITransport:
    ...

  def getMessage(self):
    transport = self.createTransport()
    transport.message()


class Machine(ITransport):

  def message(self):
    print("Врум.")


class Bike(ITransport):

  def message(self):
    print("Вжих!")

class MachineFactory(IFactory):

  def createTransport(self) -> ITransport:
    return Machine()


class BikeFactory(IFactory):

  def createTransport(self) -> ITransport:
    return Bike()


def ClientCode(factory: IFactory):
  factory.getMessage()


if __name__ == "__main__":
  ClientCode(MachineFactory())
  ClientCode(BikeFactory())
