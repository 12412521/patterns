#include <iostream>

class ITransport {

  public:

  virtual ~ITransport() {}
  virtual void message() const = 0;

};


class Machine : public ITransport {

  public:

  void message() const override {
    std::cout << "Врум.\n";
  }

};


class Bike : public ITransport {

  public:

  void message() const override {
    std::cout << "Вжих!\n";
  }

};



class IFactory {
  
  public:

  virtual ITransport* createTransport() const = 0;

  void getMessage() const {
    ITransport* transport = this -> createTransport();

    transport->message();

    delete transport;
  }

};


class MachineFactory : public IFactory {

  public:

  ITransport* createTransport() const override {
    return new Machine();
  }
  
};


class BikeFactory : public IFactory {

  public:

  ITransport* createTransport() const override {
    return new Bike();
  }
  
};


void ClientCode(const IFactory& factory) {
  factory.getMessage();
}

int main() {
  MachineFactory machineFactory;
  BikeFactory bikeFactory;

  ClientCode(machineFactory);
  ClientCode(bikeFactory);

  return 0;
}
