using System;
using System.Collections.Generic;
public class ModuleBoard
// Модуль платы, включает в себя
// модуль питания, модуль интрфейса
// модуль процессора
{
    public InType InPort;
    public OutType OutPort;
    protected byte[] MACDevices = new byte[8]; //Уникальный индификатор устройства
    public string NameDevices = "DevelopDevices";
    //Тип устройсва
    public double RevisionBoard = 0.0;
    // Ревищия платы
    public ModuleRS485 RS485;
    // Модуль интерфейса
    public ModuleCPU CPU;
    // Процессор и его инструкции
    public ModuleMemory MemoryDevies;
    // Модуль памяти
    List<InType> INCommunication;
    // Список входов прибора
    List<OutType> OUTCommunication;
    // Выходы прибора
    public ModulePower Power;
    // Модуль питания
    public ModuleBoard(string GetIndificator)
    {
        if (GetIndificator != "")
        {
            Console.WriteLine("Устройство с индификатором " + GetIndificator);
            string[] TempStringIndificator = GetIndificator.Split('-');
            for (int shag = 0; shag <= 7; shag++)
            {
                MACDevices[shag] = System.Convert.ToByte(TempStringIndificator[shag]);
            }
        }
        else
        {
            new System.Random(System.DateTime.Now.Millisecond).NextBytes(MACDevices);
            // Генерация случайного индификатора платы
        }
        MemoryDevies = new ModuleMemory(MACDevices);
        // Генерация модуля памяти, попытка открыть конфигурацию
        // с жесткого диска по названию индификатора
        this.CPU = new ModuleCPU(MACDevices);
        // Генерация модуля Процессора, передается уникальный индификатор
        this.Power = new ModulePower();
        // Генерация модуля питания 
        RS485 = new ModuleRS485();
        // AdressRS, NameDevices, VersionProshivki, 9600

        // Генерация модуля Интерфейса.
        // Конструктор нужно разобрать, кофигурация модуля интерфейса происходит
        // через процессор

        this.MemoryDevies.WriteCPU += CPU.EventMemory;
        CPU.WriteMemory += this.MemoryDevies.ReadCPU;

        Power.WriteInfoCPU += CPU.EventPower;
        // Приявяска модуля питания к Процессору
        CPU.WritePower += Power.ReadCPU;
        // Привязка модуля процессора к модуля питания

        RS485.CPUWriteDataRS += CPU.EventRS485;
        CPU.WriteRS485 += RS485.CPUReadDataRS;
    }







    public class InType
    {
        public double Resisr;
        public int ACP;
        public void NewState(double GetResist, int GetACP)
        {
            this.ACP = GetACP;
            this.Resisr = GetResist;
        }
    }

    public class OutType
    {
        public void NewACP(int GetACP)
        {
            this.ACP = GetACP;
        }
        public int ACP;
        public bool StateActiveOut = false;
    }

}