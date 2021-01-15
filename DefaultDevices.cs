public class DefaultDevices
{
    protected ModuleRS485 RS485;


    public DefaultDevices(int GetAdressRS485)
    {
        RS485 = new ModuleRS485();
        
        RS485.Adress = GetAdressRS485;

    }
}