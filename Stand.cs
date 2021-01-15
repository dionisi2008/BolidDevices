using System;
using System.Collections.Generic;

public class Stand
//Стэнд для тестирования оборудования 
{
    protected List<ModuleBoard> ListDevices;
    // Список устройств на стенде
    protected ModuleRS485 RS485;
    public Stand()
    {
        ListDevices = new List<ModuleBoard>();
        RS485 = new ModuleRS485();
    }

    public void NewDevicesStand(ModuleBoard GetNewDevices, int GetNewAdress)
    {
        // Если на стедне больше нет приборов с указанным адресом..
        GetNewDevices.CPU.AdressRS = GetNewAdress;
        AddDevicesRS485(GetNewDevices.RS485);
        ListDevices.Add(GetNewDevices);
        System.Console.WriteLine("На стэнд добавлено новое устройство");
        Console.WriteLine("На стэнд добавлено оборудование с адреслм " + GetNewDevices.CPU.AdressRS + " Тип оборудования: " + GetNewDevices.CPU.NameDevices);
    }
    public void DevicesPowerChange(int GetAdress, int UPower1, int UPower2)
    {
        for (int shag = 0; shag <= ListDevices.Count - 1; shag++)
        {
            if (ListDevices[shag].CPU.AdressRS == GetAdress)
            {
                ListDevices[shag].Power.IN1Change(UPower1);
                ListDevices[shag].Power.IN2Change(UPower2);
            }
        }
    }

    public void GetACP()
    {

    }

    public void AddDevicesRS485(ModuleRS485 GetRS485)
    {
        GetRS485.WriteRS485 += RS485.ReadRS485;
        RS485.WriteRS485 += GetRS485.ReadRS485;
    }
}