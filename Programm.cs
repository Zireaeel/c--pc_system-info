using System;
using System.Management;

namespace ComputerSystemInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Computer System Information:");
            Console.WriteLine();

            GetOperatingSystemInfo();
            GetProcessorInfo();
            GetMemoryInfo();
            GetDiskInfo();
            GetNetworkInfo();
        }

        static void GetOperatingSystemInfo()
        {
            Console.WriteLine("Operating System Information:");
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
            {
                foreach (ManagementObject os in searcher.Get())
                {
                    Console.WriteLine("Name: " + os["Caption"]);
                    Console.WriteLine("Version: " + os["Version"]);
                    Console.WriteLine("Manufacturer: " + os["Manufacturer"]);
                    Console.WriteLine("Configuration: " + os["ConfigManagerErrorCode"]);
                    Console.WriteLine("Build Number: " + os["BuildNumber"]);
                }
            }
            Console.WriteLine();
        }

        static void GetProcessorInfo()
        {
            Console.WriteLine("Processor Information:");
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor"))
            {
                foreach (ManagementObject proc in searcher.Get())
                {
                    Console.WriteLine("Name: " + proc["Name"]);
                    Console.WriteLine("Manufacturer: " + proc["Manufacturer"]);
                    Console.WriteLine("Current Clock Speed: " + proc["CurrentClockSpeed"]);
                    Console.WriteLine("Number Of Cores: " + proc["NumberOfCores"]);
                    Console.WriteLine("Processor Id: " + proc["ProcessorId"]);
                }
            }
            Console.WriteLine();
        }

        static void GetMemoryInfo()
        {
            Console.WriteLine("Memory Information:");
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
            {
                foreach (ManagementObject os in searcher.Get())
                {
                    ulong totalMemory = (ulong)os["TotalVisibleMemorySize"];
                    ulong freeMemory = (ulong)os["FreePhysicalMemory"];
                    Console.WriteLine("Total Visible Memory: " + (totalMemory / 1024) + " MB");
                    Console.WriteLine("Free Physical Memory: " + (freeMemory / 1024) + " MB");
                }
            }
            Console.WriteLine();
        }


        static void GetDiskInfo()
        {
            Console.WriteLine("Disk Information:");
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive"))
            {
                foreach (ManagementObject disk in searcher.Get())
                {
                    Console.WriteLine("Model: " + disk["Model"]);
                    Console.WriteLine("Interface Type: " + disk["InterfaceType"]);
                    Console.WriteLine("Media Type: " + disk["MediaType"]);
                    Console.WriteLine("Serial Number: " + disk["SerialNumber"]);
                }
            }
            Console.WriteLine();
        }

        static void GetNetworkInfo()
        {
            Console.WriteLine("Network Information:");
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = True"))
            {
                foreach (ManagementObject net in searcher.Get())
                {
                    Console.WriteLine("Description: " + net["Description"]);
                    Console.WriteLine("MAC Address: " + net["MACAddress"]);
                    string[] addresses = (string[])net["IPAddress"];
                    if (addresses != null)
                    {
                        foreach (string ip in addresses)
                        {
                            Console.WriteLine("IP Address: " + ip);
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
