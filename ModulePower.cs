public class ModulePower
{
    protected int GetPowerIN1 = 0;
    protected int GetPowerIN2 = 0;
    public delegate void DelegaWriteInfoCPU(byte[] OUTDataCPU);
    public DelegaWriteInfoCPU WriteInfoCPU;
    public void ReadCPU(byte[] GetDataCPU)
    {

    }

    public void IN1Change(int GetPower)
    {
        this.GetPowerIN1 = GetPower;
        WriteInfoCPU(ConverByteText("Напряжение" + '\r' + "Ввод 1" + '\r' + GetPower.ToString()));
    }

    public void IN2Change(int GetPower)
    {
        this.GetPowerIN2 = GetPower;
        WriteInfoCPU(ConverByteText("Напряжение" + '\r' + "Ввод 2" + '\r' + GetPower.ToString()));
    }

    public byte[] ConverByteText(string GetText)
    {
        return System.Text.UTF8Encoding.UTF8.GetBytes(GetText);
    }
    
}