using System;
using System.Collections.Generic;
using System.IO;
public class ModuleMemory
{
    public string Indificator;
    public List<byte> ListMemotyBytes;
    public delegate void DelegWriteCPU(byte[] ReadInfoCPU);
    public DelegWriteCPU WriteCPU;
    public ModuleMemory(byte[] GetIndificatiom)
    {
        ListMemotyBytes = new List<byte>();
        ReadMemory();
        Indificator +=
        Convert.ToString(GetIndificatiom[0]) + '-' +
        Convert.ToString(GetIndificatiom[1]) + '-' +
        Convert.ToString(GetIndificatiom[2]) + '-' +
        Convert.ToString(GetIndificatiom[3]) + '-' +
        Convert.ToString(GetIndificatiom[4]) + '-' +
        Convert.ToString(GetIndificatiom[5]) + '-' +
        Convert.ToString(GetIndificatiom[6]) + '-' +
        Convert.ToString(GetIndificatiom[7]);
        System.Console.WriteLine(Indificator);
    }

    public void ReadMemory()
    {
        if (File.Exists(Indificator))
        {
            ListMemotyBytes = new List<byte>(File.ReadAllBytes(Indificator));
        }
    }

    public void ReadCPU(byte[] DataReadCPU)
    {
        if (ConvertByteText(DataReadCPU) == "Считать")
        {
            if (ListMemotyBytes.Count == 0)
            {
                WriteCPU(null);
            }
            else
            {
                WriteCPU(ListMemotyBytes.ToArray());
            }

        }
        else
        {
            ListMemotyBytes = new List<byte>(DataReadCPU);
            File.WriteAllBytes(Indificator, ListMemotyBytes.ToArray());
        }

    }

    public string ConvertByteText(byte[] GetBytes)
    {
        return System.Text.UTF8Encoding.UTF8.GetString(GetBytes);
    }
}