using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace WMI
{
    public static class DAL
    {
        //Returns an ObjectCollection containing information about the user on the operating system
        public static ManagementObjectCollection UserInfo()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            return results;
        }

        //Returns an ObjectCollection of Boot devices/device
        public static ManagementObjectCollection BootDevice()
        {
            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\cimv2");
            //create object query
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            //create object searcher
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            //get a collection of WMI objects
            ManagementObjectCollection queryCollection = searcher.Get();
            return queryCollection;
        }

        //Returns a list of strings containing the location/name of the disks/storage devices currently connected to the PC
        public static List<string> PopulateDisk()
        {
            List<string> disk = new List<string>();
            SelectQuery selectQuery = new SelectQuery("Win32_LogicalDisk");
            ManagementObjectSearcher mnagementObjectSearcher = new ManagementObjectSearcher(selectQuery);
            foreach (ManagementObject managementObject in mnagementObjectSearcher.Get())
            {
                disk.Add(managementObject.ToString());
            }
            return disk;
        }
        //Returns an Object collection containing information about the main storage drive's memory
        public static ManagementObjectCollection MainStorage()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            return results;
        }
        //Returns an Object collection containing information about all the drives connected, and the storage status of them.
        public static ManagementObjectCollection DiskMetaData()
        {
            System.Management.ManagementScope managementScope = new System.Management.ManagementScope();
            System.Management.ObjectQuery objectQuery = new System.Management.ObjectQuery("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
            return managementObjectCollection;
        }

        //Returns a string with the serial number of the C drive
        public static string HardDiskSerialNumber(string drive = "C")
        {
            ManagementObject managementObject = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");
            managementObject.Get();
            return managementObject["VolumeSerialNumber"].ToString();
        }
        //Returns a collection containing all the currently running services.
        public static ManagementObjectCollection ListAllServices()
        {
            ManagementObjectSearcher windowsServicesSearcher = new ManagementObjectSearcher("root\\cimv2", "select * from Win32_Service");
            ManagementObjectCollection objectCollection = windowsServicesSearcher.Get();
            return objectCollection;
        }

        //Returns a collection of CPU's/Logical cores and their current Processor Time 
        public static ManagementObjectSearcher ProcessorTime()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");
            return searcher;
        }
    }
}
