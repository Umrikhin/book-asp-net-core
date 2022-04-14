using MobileDevices;
using MobileDevices.Entities;
// Что бы создать базу данных и протестировать приложение, необходимо провести следующие операции:
// Консоль диспетчера пакетов -> Add-Migration Initial
// Консоль диспетчера пакетов -> Update-Database
// После чего приложение можно запускать.
// Операции с базой данных (CRUD)
// Создание (Create)
MobileDevice newDevice = new MobileDevice()
{
    Model = "Samsung",
    ClientPhone = "+79185004078"
};
int newId = Operations.Create(newDevice);
// Чтение (Read)
var table = Operations.Read();
foreach (var device in table)
{
    Console.WriteLine(new string('-', 50));
    Console.WriteLine("Модель: " + device.Model);
    Console.WriteLine("Телефон клиента: " + device.ClientPhone);
}
//Чтение одного элемента
MobileDevice? gotDevice = Operations.Read(newId);
Console.WriteLine("Модель: " + gotDevice?.Model);
Console.WriteLine("Телефон клиента: " + gotDevice?.ClientPhone);
// Обновление (Update)
if (gotDevice != null)
{
    gotDevice.Model = "Apple";
    Operations.Update(gotDevice);
}
// Удаление (Delete)
if (gotDevice != null) Operations.Delete(gotDevice);
Console.ReadKey();


