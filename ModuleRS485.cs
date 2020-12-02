public class ModuleRS485 //Модуль Интерфейса RS485 Для стандарной платы
{
    protected int Adress; //Адрес устройства в RS485
    protected string NameDevices; //Имя Устройства
    protected int SpeedIntefaces; //Скорость интерфейса
    protected double VersionProgramm; //Версия прошивки устройства
    protected byte[] MACDevices = new byte[8]; //Уникальный индификатор устройства
    public delegate void DelegateWriteRS485(int AdressOut, int AdressGet, byte[] OutByte); 
    //Экзимпляр делегаты записи в интерфейса
    public DelegateWriteRS485 WriteRS485; //Для првязки всех устройств в интерфейсе

    public void ReadRS485(int AdressOut, int AdressGet, byte[] OutByte) //Для првязки всех устройств в интерфейсе
    {
        System.Console.WriteLine("DeBug: " + AdressOut + " " + AdressGet + " " + System.Text.UTF8Encoding.UTF8.GetString(MACDevices));
    }

    public ModuleRS485(int NewAdress, string NameDevices, double GetVersionDevices, int GetSpeedDevices) //Обявление Класса
    {
        this.Adress = NewAdress;
        this.NameDevices = NameDevices;
        this.VersionProgramm = GetVersionDevices;
        this.SpeedIntefaces = GetSpeedDevices;
        new System.Random(System.DateTime.Now.Millisecond).NextBytes(MACDevices);

    }
}