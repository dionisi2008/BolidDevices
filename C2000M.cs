using System;
public class C2000M
{
    protected Indicators Indicator;
    protected C2000MCPU CPU;
    public C2000M()
    {
        Indicator = new Indicators();

        CPU = new C2000MCPU(Indicator.GetCommandCPU);
    }















































    public class KeyBoard
    {
        public KeyBoard()
        {

        }
        public void KeyKey(string GetKey)
        {

        }
    }

    public class C2000MCPU
    {
        DelegateList.C2000MDelEventIndicator EventIndicator;
        public C2000MCPU(DelegateList.C2000MDelEventIndicator GetEventIndicator)
        {
            EventIndicator = GetEventIndicator;
            EventIndicator("Backlight", true);

        }
    }

    public class Indicators
    {
        protected bool Fire = false;
        protected bool Start = false;
        protected bool Stop = false;
        protected bool Malfunction = false;
        protected bool Disable = false;
        protected bool SoundDisabled = false;
        protected bool Power = false;
        protected bool Backlight = false;

        public void GetCommandCPU(string NameIndicator, bool GetState)
        {
            switch (NameIndicator)
            {
                case "Fire":
                    Fire = GetState;
                    Console.WriteLine("Fire: " + GetState);
                    break;
                case "Start":
                    Start = GetState;
                    Console.WriteLine("Start: " + GetState);
                    break;
                case "Stop":
                    Stop = GetState;
                    Console.WriteLine("Stop: " + GetState);
                    break;
                case "Malfunction":
                    Malfunction = GetState;
                    Console.WriteLine("Malfunction: " + GetState);
                    break;
                case "Disable":
                    Disable = GetState;
                    Console.WriteLine("Disable: " + GetState);
                    break;
                case "SoundDisabled":
                    SoundDisabled = GetState;
                    Console.WriteLine("SoundDisable: " + GetState);
                    break;
                case "Power":
                    Power = GetState;
                    Console.WriteLine("Power: " + GetState);
                    break;
                case "Backlight":
                    Backlight = GetState;
                    Console.WriteLine("BackLight: " + GetState);
                    break;
            }
        }
        public Indicators()
        {

        }
    }
}