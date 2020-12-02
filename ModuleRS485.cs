public class ModuleRS485
{
    protected int Aress;
    protected string NameDevices;
    protected int SpeedIntefaces;
    protected double VersionProgramm;

    public delegate void DelegateWriteRS485(int AdressOut, int AdressGet, byte[] OutByte);

    public DelegateWriteRS485 WriteRS485;
    
    public void ReadRS485(int AdressOut, int AdressGet, byte[] OutByte)
    {
        System.Console.WriteLine("DeBug: " + AdressOut + " " + AdressGet);
    }

    public ModuleRS485(int NewAdress, string NameDevices, double GetVersionDevices, int GetSpeedDevices)
    {
        
    }
}