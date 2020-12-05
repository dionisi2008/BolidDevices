﻿using System;
using System.Collections.Generic;
namespace BolidDevices
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!!");

            //Инцилизируем Интерфейс RS485, по
            //сути двухжильный кабель на который садяться приборы
            List<ModuleRS485> TestRS485 = new List<ModuleRS485>();

            //Запускаем пульт в интерфейс
            TestRS485.Add(new ModuleRS485(1, "С2000М", 4.12, 9600));

            //Функция для добавления нового прибора
            //и прявязка его к пульту
            NewDevicesRS485PKU(TestRS485, TestRS485[0], new ModuleRS485(2, "С2000-КДЛ", 2.27, 9600));
            NewDevicesRS485PKU(TestRS485, TestRS485[0], new ModuleRS485(3, "С2000-КДЛ", 2.27, 9600));


            //Запись в от пульта в интерфейса данных
            TestRS485[0].WriteRS485(2, 1,System.Text.UTF8Encoding.UTF8.GetBytes("Поиск Устройства" + '\r' + ""));
            System.Console.ReadLine();
        }

        public static void NewDevicesRS485PKU(List<ModuleRS485> GetRS485, ModuleRS485 GetPKU, ModuleRS485 GetNewDevices)
        {
            GetNewDevices.WriteRS485 += GetPKU.ReadRS485;
            GetPKU.WriteRS485 += GetNewDevices.ReadRS485;
            GetRS485.Add(GetNewDevices);
        }
    }
}
