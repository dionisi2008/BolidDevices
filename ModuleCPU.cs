using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
public class ModuleCPU
// Модуль обработки событий между всеми модулями платы и доп модцулями
{
    public delegate void ModuleWriteRS485(byte[] OutDataRS);
    // Модуль для записи в Интерфейс
    public ModuleWriteRS485 WriteRS485;
    // Ссылка на фунуцию по взаимодейсвию в модуле интерфеса
    public delegate void DelegaWritePower(byte[] OutDataPower);
    public DelegaWritePower WritePower;
    private int InputVolt1 = 0;
    // Первый источник питания
    private int InputVolt2 = 0;
    // Второй ввод питания

    public int AdressRS;
    public string NameDevices;
    public double VersionProshivki;
    public bool StateConnectPKU = false;
    // Статус подключения к ПКУ в интерфейсе
    // Если нет связи в ПКУ, все пишется в память событий
    public byte[] MACIndificator;
    public List<byte[]> ListMessage;
    // лист сообытий 
    public void EventMemory(byte[] ReadDataByte)
    {
        if (ReadDataByte == null)
        {
            GenericNewConfig();
        }
        else
        {

        }
    }

    public delegate void ModuleWriteMemory(byte[] WriteDataByte);
    public ModuleWriteMemory WriteMemory;
    public void GenericNewConfig()
    {
        string NameDevies = "|DevelopDevice|";
        double VersionProshivki = 0.1;
        AdressRS = 127;
        this.VersionProshivki = 0.1;
        this.NameDevices = "DevelopDevice";
        int Adress = 127;
        List<byte> WriteMemory = new List<byte>();
        WriteMemory.AddRange(GetBytes(Convert.ToString(Adress)));
        WriteMemory.AddRange(GetBytes(NameDevies));
        WriteMemory.AddRange(GetBytes(Convert.ToString(VersionProshivki)));
        this.WriteMemory(WriteMemory.ToArray());
        // WriteMemory
    }

    public ModuleCPU(byte[] ReadMACDevices)
    {
        this.MACIndificator = ReadMACDevices;
        Console.WriteLine("TestCPU 1");
    }

    public void EventRS485(byte[] ReadGetDataRS485)
    // Оброботка событий от модуля интерфейса
    {

    }

    public void EventBoard()
    // Обработка событий от самой платы, вводы, выводы индикаторы, считыватели и прочие.
    {

    }

    public void EventPower(byte[] GetMassByte)
    // Оброботка событий от модуля питания платы 
    {
        string[] TempDataVolt = GetString(GetMassByte).Split('\r');
        switch (TempDataVolt[0])
        {
            case "Напряжение":
                switch (TempDataVolt[1])
                {
                    case "Ввод 1":
                        InputVolt1 = Convert.ToInt32(TempDataVolt[2]);
                        
                        break;
                    case "Ввод 2":
                        InputVolt2 = Convert.ToInt32(TempDataVolt[2]);

                        break;
                }
                break;
        }
    }

    public string GetString(byte[] GetMassByte)
    // Конвертер Масива данных в строку, по окончания разработки
    // эта функция должна пропасть должны только остаться массивы и
    // по ним нужно будет работать
    {
        return UTF8Encoding.UTF8.GetString(GetMassByte);
    }

    public byte[] GetBytes(string GetString)
    {
        return UTF8Encoding.UTF8.GetBytes(GetString);
    }

    public void StartCPU()
    {
        this.WriteMemory(GetBytes("Считать"));
        System.Threading.Thread.Sleep(500);
        
        Console.WriteLine("Debug");
        List<byte> OutRS485 = new List<byte>();
        OutRS485.Add(1);
        OutRS485.Add(Convert.ToByte(this.AdressRS));
        OutRS485.Add(Convert.ToByte(System.Convert.ToString(this.VersionProshivki).Split(',')[0]));
        OutRS485.Add(Convert.ToByte(System.Convert.ToString(this.VersionProshivki).Split(',')[1]));
        OutRS485.Add(0);
        OutRS485.AddRange(GetBytes(NameDevices));
        this.WriteRS485(OutRS485.ToArray());
        // int NewAdress, double GetVersionDevices, int GetSpeedDevices, string NameDevices
    }

}