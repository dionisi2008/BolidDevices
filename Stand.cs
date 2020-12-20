using System;
using System.Collections.Generic;

public class Stand
{
    protected List<ModuleBoard> ListDevices;
    public Stand()
    {
        ListDevices = new List<ModuleBoard>();
    }
    public void NewDevicesStand(ModuleBoard GetNewDevices, int GetNewAdress)
    {
        GetNewDevices.CPU.AdressRS = GetNewAdress;
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
}
