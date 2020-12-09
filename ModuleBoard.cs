using System;
using System.Collections.Generic;
public class ModuleBoard
{
    public ModuleRS485 RS485;
    List<InType> Ins;
    List<OutType> outTypes;
    public ModuleBoard()
    {
        
    }
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