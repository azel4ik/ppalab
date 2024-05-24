using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppa_lab_test_1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace ppa_lab_test_1
    {

        public interface IObservable //наблюдаемый объект
        {
            //void AddObserver(ICommandLogger observer); //метод для добавления наблюдателя
            //void RemoveObserver(ICommandLogger observer); //удалени наблюдателя
            void NotifyObservers(); //уведомление наблюдателя
        }


        //наблюдатель
        //подписывается на все уведомления наблюдаемого объекта
        public interface ICommandLogger
        {
            void Update(string CommandName, string Status);
        }

        //конкретная реализация интерфейса
        public class CommandLogger : ICommandLogger
        {

            public CommandLogger()
            {
            }

            public void Update(string CommandName, string Status)
            {
                string message = $"[{System.DateTime.Now}]Command {CommandName} has been {Status} ";
                StreamWriter sw = new StreamWriter("CommandLog.txt", true);
                sw.WriteLine(message);
                sw.Close();
            }
        }

    }

}
