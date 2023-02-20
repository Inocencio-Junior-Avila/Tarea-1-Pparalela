using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Diagnostics;


namespace PPraralela_1
{
    class Program_A
    {
        public static void Main()
        {
            //A-Cantidad de Procesadores o CPU (Usando "System.Management")
            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem").Get()){
      
               Console.WriteLine("Cantidad de Procesadores o CPU: {0} ",
               item["NumberOfProcessors"]);
            }
        Console.ReadLine();

            //B- Cantidad de Procesos ejecutándose (Usando "System.Diagnostics")
            Process[] processes = Process.GetProcesses();
            int count = processes.Length;
            Console.WriteLine("Cantidad de Procesos ejecutándose: " + count);

        Console.ReadLine();
            //Extra-Cantidad de Nucleos
            int coreCount = 0;
            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get()){
      
               coreCount += int.Parse(item["NumberOfCores"].ToString());
            }
            Console.WriteLine("Number Of Cores: {0}", coreCount);

            //C-Cantidad de Hilos o Threads que posee (Usando "System.Management")
            Console.WriteLine("Cantidad de Hilos o Threads que posee: " +"{0}", 
                Environment.ProcessorCount);
        Console.ReadLine();

            //D-Determinar si posee un Bus de Datos de 32 o 64 bits (Usando "System.Management")
            var query = new ObjectQuery("SELECT AddressWidth FROM Win32_Processor");
            var searcher = new ManagementObjectSearcher(query);
            var result = searcher.Get();

            foreach (var item in result)
            {
                int width = int.Parse(item["AddressWidth"].ToString());

                if (width == 32)
                {
                    Console.WriteLine("Posee un Bus de Datos de: 32-bit");
                }
                else if (width == 64)
                {
                    Console.WriteLine("Posee un Bus de Datos de: 64-bit");
                }
                else
                {
                    Console.WriteLine("Tamaño de bus de datos desconocido");
                }
            }
        Console.ReadLine();
            //E-Cantidad de Memoria RAM (Usando "System.Management")
            var queryR = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
            var searcherR = new ManagementObjectSearcher(queryR);
            var resultR = searcherR.Get();

            long totalRam = 0;

            foreach (var item in resultR)
            {
                long capacity = long.Parse(item["Capacity"].ToString());
                totalRam += capacity;
            }

            Console.WriteLine("Total RAM: " + totalRam / (1024 * 1024) + " MB");

        Console.ReadLine();
        }

    }



}