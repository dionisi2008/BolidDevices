using System.Collections.Generic;
using System.Text;
using System;
using System.Timers;
public class ModuleRS485 //Модуль Интерфейса RS485 Для стандарной платы
{
    protected int Adress; //Адрес устройства в RS485
    public double Resistor = 0.0;
    protected System.Timers.Timer RSTimer; //Таймер ожидания опроса ПКУ
    protected string NameDevices; //Имя Устройства
    protected int SpeedIntefaces; //Скорость интерфейса

    private bool ConnectPKU = true; //Состояние подключения к ПКУ
    protected double VersionProgramm; //Версия прошивки устройства
    protected byte[] MACDevices = new byte[8]; //Уникальный индификатор устройства
    public delegate void DelegateWriteRS485(int AdressOut, int AdressGet, byte[] OutByte);
    //Экзимпляр делегаты записи в интерфейса

    public delegate void DelegateCPUWriteEventRS485(byte[] GetDataRS485); //Делегата для общения модуля RS-485 c CPU    
    public DelegateCPUWriteEventRS485 CPUWriteDataRS; //Для записи в CPU

    public DelegateWriteRS485 WriteRS485; //Для првязки всех устройств в интерфейсе

    public void ReadRS485(int AdressOut, int AdressGet, byte[] OutByte) //Для чтения из интерфейса
    {
        if (AdressOut == Adress) //Обращение именно к этому устройству
        {
            FuncConnectPKU(true); //Передача ЦПУ статус устоновки связи с ПКУ

            // ЗАДЕЙСТВОВАТЬ!!!! CPUWriteDataRS(OutByte); // Передача в CPU

            // System.Console.WriteLine(System.Text.UTF8Encoding.UTF8.GetString(OutByte));
            // string[] GetInfoInterfacesRS485 = UTF8Encoding.UTF8.GetString(OutByte).Split('\r');
            // switch (GetInfoInterfacesRS485[0])
            // {
            //     case "Поиск Устройства":
            //     System.Console.WriteLine("Поиск Устройства " + Adress);
            //     List<byte> OutDate = new List<byte>(UTF8Encoding.UTF8.GetBytes("Поиск Устройства" + '\r' + "Принято" + '\r'));
            //     OutDate.AddRange(MACDevices);
            //     WriteRS485.Invoke(Adress, AdressOut, OutDate.ToArray());
            //     break;
            // }
        }
    }
    public void FuncConnectPKU(bool StateConnectGet) //Фукция оброботки события подключения / откючения ПКУ
    {
        if (StateConnectGet == false & ConnectPKU == true)
        {
            ConnectPKU = false;
            System.Console.WriteLine("Нет связи с ПКУ");
            //CPUWriteDataRS(UTF8Encoding.UTF8.GetBytes("Нет связи с ПКУ"));
        }
        else
        {
            RSTimer.Stop();
            RSTimer.Start();
            ConnectPKU = true;
            System.Console.WriteLine("Cвязь с ПКУ востановлена");
            
            //CPUWriteDataRS(UTF8Encoding.UTF8.GetBytes("Cвязь с ПКУ востановлена"));
        }
    }
    public ModuleRS485(int NewAdress, string NameDevices, double GetVersionDevices, int GetSpeedDevices) //Обявление Класса
    {
        this.Adress = NewAdress;
        this.NameDevices = NameDevices;
        this.VersionProgramm = GetVersionDevices;
        this.SpeedIntefaces = GetSpeedDevices;
        new System.Random(System.DateTime.Now.Millisecond).NextBytes(MACDevices);
        this.RSTimer = new System.Timers.Timer(this.SpeedIntefaces);
        this.RSTimer.Start();
        this.RSTimer.Elapsed += (object sender, ElapsedEventArgs e) =>
        {
            if (ConnectPKU != false)
            {

                FuncConnectPKU(false);
            }

            System.Console.WriteLine("Debug Истёк таймер");
        };
    }

    public void CPUReadDataRS(byte[] ReadDataCPU, int AdressOut)
    {

    }
}