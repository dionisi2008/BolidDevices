public class S2000_4 : ModuleBoard
{
    
    public S2000_4(string GetIndificators) :base(GetIndificators) 
    {
       CPU = new S2000_4CPU(MACDevices);
       
    }
}