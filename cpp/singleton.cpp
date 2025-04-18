#include <map>
#include <iostream>

class DataBase {

    public:

    std::map<const char*, const char*> datas;

    static DataBase* database;

    static DataBase* getInstance() {
        if (!database) DataBase::database = new DataBase();

        return DataBase::database;
    }

    void printValue(const char* key) {
        std::cout << datas[key] << "\n";
    }

    void setValue(const char* key, const char* value) {
        datas[key] = value;
    }

};

DataBase* DataBase::database = 0;

int main() {
    DataBase* data = DataBase::getInstance();

    data->setValue("Лол", "Бомжур!!!");
    data->printValue("Лол");
    DataBase::getInstance()->printValue("Лол");

    return 0;
}
