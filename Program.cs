using System;
using System.Collections.Generic;
namespace BolidDevices
{
    class Program
    {
        public static Stand TestStand;

        static void Main(string[] args)
        {
            System.Console.WriteLine(System.Console.ReadKey());
            C2000M C2000MDevelop = new C2000M();
            
            // C2000M C2000MDevelop = new C2000M(new int[]{205,137,162,64,241,160,67,155});

            Console.WriteLine("Добро пожаловать в стенд тестирования оборудования");
            Console.WriteLine("Выберите дальнейшие действя");
            Console.WriteLine("1 - Создать новый стенд");
            Console.WriteLine("2 - Загрузить стенд");
            Console.WriteLine("3 - Получить справку");


            switch (System.Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    TestStand = new Stand();

                    System.Console.WriteLine("Стэнд создан");

                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
            System.Console.WriteLine("1 - Добаить новое утсройство");
            switch (System.Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    System.Console.WriteLine("Укажите Адрес прибора");
                    int NewAdress = GetIntReadLine();
                    if (NewAdress >= 0 & NewAdress < 128)
                    {
                        System.Console.WriteLine("Укажите прибор");
                        System.Console.WriteLine("1 - С2000-4");
                        switch (GetIntReadLine())
                        {
                            case 1:
                                S2000_4 C2_4 = new S2000_4("205-137-162-64-241-160-67-155");
                                TestStand.NewDevicesStand(C2_4, NewAdress);
                                break;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Не допустимый диопозон значений");
                    }


                    break;
            }
            System.Console.ReadLine();

            // Stand StandDevelop = new Stand();
            // StandDevelop.NewDevicesStand(new S2000_4("205-137-162-64-241-160-67-155"), 1);
            // StandDevelop.DevicesPowerChange(1, 12, 0);
            // //StandDevelop.GetACP(1, 1);
            // System.Console.ReadLine();



            // ModuleBoard DevelopBoard = new ModuleBoard("205-137-162-64-241-160-67-155");
            // DevelopBoard.Power.IN1Change(12);
            // DevelopBoard.CPU.StartCPU();
            // System.Console.ReadLine();

            // передаю на цпу питани с модуля питания



            //     //Инцилизируем Интерфейс RS485, по
            //     //сути двухжильный кабель на который садяться приборы
            //     List<ModuleRS485> TestRS485 = new List<ModuleRS485>();

            //     //Запускаем пульт в интерфейс
            //     TestRS485.Add(new ModuleRS485(1, "С2000М", 4.12, 9600));

            //     //Функция для добавления нового прибора
            //     //и прявязка его к пульту
            //     NewDevicesRS485PKU(TestRS485, TestRS485[0], new ModuleRS485(2, "С2000-КДЛ", 2.27, 9600));
            //     NewDevicesRS485PKU(TestRS485, TestRS485[0], new ModuleRS485(3, "С2000-КДЛ", 2.27, 9600));


            //     //Запись в от пульта в интерфейса данных
            //     TestRS485[0].WriteRS485(2, 1,System.Text.UTF8Encoding.UTF8.GetBytes("Поиск Устройства" + '\r' + ""));
            //     System.Console.ReadLine();
        }

        static void NewDevicesRS485PKU(List<ModuleRS485> GetRS485, ModuleRS485 GetPKU, ModuleRS485 GetNewDevices)
        {
            GetNewDevices.WriteRS485 += GetPKU.ReadRS485;
            GetPKU.WriteRS485 += GetNewDevices.ReadRS485;
            GetRS485.Add(GetNewDevices);
        }

        static byte[] GetByteMessage(string GetMessage)
        {
            return System.Text.UTF8Encoding.UTF8.GetBytes(GetMessage);
        }

        public static int GetIntReadLine()
        {
            return System.Convert.ToInt32(System.Console.ReadLine());
        }

        public static bool ShearchDevicesAdress(int GetAdress)
        {

            return false;
        }
    }
}
