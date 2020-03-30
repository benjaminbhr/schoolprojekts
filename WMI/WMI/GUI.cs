using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace WMI
{
    public static class GUI
    {
        //Writes out the user,org and O/S on the Operating system
        private static void UserInfo()
        {
            foreach (ManagementObject result in DALManager.UserInfo())
            {
                Console.WriteLine("User:\t{0}", result["RegisteredUser"]);
                Console.WriteLine("Org.:\t{0}", result["Organization"]);
                Console.WriteLine("O/S :\t{0}", result["Name"]);
            }
        }
        //Writes out the current Boot device
        private static void BootDevice()
        {
            foreach (ManagementObject m in DALManager.BootDevice())
            {
                // access properties of the WMI object
                Console.WriteLine("BootDevice : {0}", m["BootDevice"]);
            }
        }

        //Writes out the currently connected drives and their location
        private static void PopulateDisk()
        {
            foreach (string item in DALManager.PopulateDisk())
            {
                Console.WriteLine(item);
            }
        }
        //Writes out the main storage memory values.
        private static void MainStorage()
        {
            foreach (ManagementObject result in DALManager.MainStorage())
            {
                Console.WriteLine("Total Visible Memory: {0}KB", result["TotalVisibleMemorySize"]);
                Console.WriteLine("Free Physical Memory: {0}KB", result["FreePhysicalMemory"]);
                Console.WriteLine("Total Virtual Memory: {0}KB", result["TotalVirtualMemorySize"]);
                Console.WriteLine("Free Virtual Memory: {0}KB", result["FreeVirtualMemory"]);
            }
        }

        //Writes out the name of the drive, the free space, and the total disk size
        private static void DiskMetaData()
        {
            foreach (ManagementObject managementObject in DALManager.DiskMetaData())
            {
                Console.WriteLine("Disk Name : " + managementObject["Name"].ToString());
                Console.WriteLine("FreeSpace: " + managementObject["FreeSpace"].ToString());
                Console.WriteLine("Disk Size: " + managementObject["Size"].ToString());
                Console.WriteLine("---------------------------------------------------");
            }
        }
        //Writes out the serial number of the C drive
        private static void HardDiskSerialNumber()
        {
            Console.WriteLine(DALManager.HardDiskSerialNumber());
        }
        //Lists all the currently running services on the PC
        private static void ListAllServices()
        {
            Console.WriteLine("There are {0} Windows services: ", DALManager.ListAllServices().Count);
            foreach (ManagementObject windowsService in DALManager.ListAllServices())
            {
                PropertyDataCollection serviceProperties = windowsService.Properties;
                foreach (PropertyData serviceProperty in serviceProperties)
                {
                    if (serviceProperty.Value != null)
                    {
                        Console.WriteLine("Windows service property name: {0}", serviceProperty.Name);
                        Console.WriteLine("Windows service property value: {0}", serviceProperty.Value);
                    }
                }
                Console.WriteLine("---------------------------------------");
            }
        }
        //writes out every CPU/logical core, and it's current processor time
        private static void ProcessorTime()
        {
            foreach (ManagementObject obj in DALManager.ProcessorTime().Get())
            {
                var usage = obj["PercentProcessorTime"];
                var name = obj["Name"];
                Console.WriteLine(name + " : " + usage);
                Console.WriteLine("CPU");
            }
        }
        //Gets Key info and returns it as ConsoleKeyInfo for the Menu switch case to switch on
        private static ConsoleKeyInfo UserKeyInput()
        {
            ConsoleKeyInfo cki;
            cki = Console.ReadKey(true);
            return cki;
        }
        public static void Menu()
        {
            bool showmenu = true;
            while (showmenu)
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("        PC Information");
                Console.WriteLine("================================");
                Console.WriteLine("(1) See MainStorage");
                Console.WriteLine("(2) See User Info");
                Console.WriteLine("(3) Boot Device");
                Console.WriteLine("(4) Get DiskMetaData");
                Console.WriteLine("(5) Hard Disk Serial number");
                Console.WriteLine("(6) List all services");
                Console.WriteLine("(7) Processor Time");
                Console.WriteLine("(8) Populate Disk");
                Console.WriteLine("(9) Exit");
                switch (UserKeyInput().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        MainStorage();
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        UserInfo();
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        BootDevice();
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        DiskMetaData();
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        HardDiskSerialNumber();
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D6:
                        Console.Clear();
                        ListAllServices();
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D7:
                        Console.Clear();
                        ProcessorTime();
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D8:
                        Console.Clear();
                        PopulateDisk();
                        Console.WriteLine("Press 'Enter' to return to main menu");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D9:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
