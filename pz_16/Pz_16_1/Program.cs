using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;


namespace Server
{
    public class Server
    {
        static TcpListener tcpListener;
        static List <TcpClient> clients = new List<TcpClient>();

        static void Main(string[] args)
        {
            tcpListener = new TcpListener(IPAddress.Any, 8080); // Выберите свободный порт
            tcpListener.Start();

            Console.WriteLine("Сервер запущен. Ожидание подключений...");

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                clients.Add(client);

                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
                clientThread.Start(client);
            }
        }

        static void HandleClient(object obj)
        {
            TcpClient tcpClient = (TcpClient)obj;
            NetworkStream clientStream = tcpClient.GetStream();
            StreamReader reader = new StreamReader(clientStream);
            StreamWriter writer = new StreamWriter(clientStream);

            while (true)
            {
                try
                {
                    string message = reader.ReadLine();
                    if (message != null)
                    {
                        Console.WriteLine("Получено сообщение от клиента: " + message);

                        // Обработка сообщения и отправка ответа
                        // Например, сохранение данных в БД
                    }
                }
                catch (IOException)
                {
                    // Обработка отключения клиента
                    clients.Remove(tcpClient);
                    break;
                }
            }
        }
    }
}
