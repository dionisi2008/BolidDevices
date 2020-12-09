using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
public class ModuleCPU 
// Модуль обработки событий между всеми модулями платы и доп модцулями
{
    public delegate void ModuleWriteRS485(byte[] OutDataRS, int AdressOut);
    // Модуль для записи в Интерфейс
    public ModuleWriteRS485 WriteRS485;
    // Ссылка на фунуцию по взаимодейсвию в модуле интерфеса
    private int InputVolt1 = 0;
    // Первый источник питания
    private int InputVolt2 = 0;
    // Второй ввод питания
    public bool StateConnectPKU = false;
    // Статус подключения к ПКУ в интерфейсе
    // Если нет связи в ПКУ, все пишется в память событий
    public List<byte[]> ListMessage;
    // лист сообытий 
    public void EventRS485()
    // Оброботка событий от модуля интерфейса
    {

    }

    public void EventBoard()
    // Обработка событий от самой платы, вводы, выводы индикаторы, считыватели и прочие.
    {

    }

    public void EventVolt(byte[] GetMassByte)
    // Оброботка событий от модуля питания платы 
    {
        string[] TempDataVolt = GetString(GetMassByte).Split('\r');
        switch (TempDataVolt[0])
        {
            case "Напряжение":
                switch (TempDataVolt[1])
                {
                    case "Ввод 1":
                        InputVolt1 = Convert.ToInt32(TempDataVolt[2]);

                        break;
                    case "Ввод 2":
                        InputVolt2 = Convert.ToInt32(TempDataVolt[2]);

                        break;
                }
                break;
        }
    }

    public string GetString(byte[] GetMassByte)
    // Конвертер Масива данных в строку, по окончания разработки
    // эта функция должна пропасть должны только остаться массивы и
    // по ним нужно будет работать
    {
        return UTF8Encoding.UTF8.GetString(GetMassByte);
    }

}