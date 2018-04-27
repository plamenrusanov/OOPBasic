using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Controllers
{
   
    public class Engine
    {
        private StorageMaster storageMaster;
        private StringBuilder sb;

        public Engine()
        {
            this.storageMaster = new StorageMaster();
            this.sb = new StringBuilder();
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] token = input.Split();
                string command = token[0];

                try
                {
                    switch (command)
                    {
                        case "AddProduct":
                            string typeProduct = token[1];
                            double price = double.Parse(token[2]);
                            sb.AppendLine(storageMaster.AddProduct(typeProduct, price));
                            break;

                        case "RegisterStorage":
                            string typeStorage = token[1];
                            string name = token[2];
                            sb.AppendLine(storageMaster.RegisterStorage(typeStorage, name));
                            break;

                        case "SelectVehicle":
                            string storageName = token[1];
                            int garageSlot = int.Parse(token[2]);
                            sb.AppendLine(storageMaster.SelectVehicle(storageName, garageSlot));
                            break;

                        case "LoadVehicle":
                            sb.AppendLine(storageMaster.LoadVehicle(token.Skip(1).ToList()));
                            break;

                        case "SendVehicleTo":
                            string sourceName = token[1];
                            int sourceGarageSlot = int.Parse(token[2]);
                            string destinationName = token[3];
                            sb.AppendLine(storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName));
                            break;

                        case "UnloadVehicle":
                            string storageN = token[1];
                            int garSlot = int.Parse(token[2]);
                            sb.AppendLine(storageMaster.UnloadVehicle(storageN, garSlot));
                            break;

                        case "GetStorageStatus":
                            string storage = token[1];
                            sb.AppendLine(storageMaster.GetStorageStatus(storage));
                            break;
                        default:
                            break;
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    sb.AppendLine($"Error: {ioe.Message }");
                }
            }
            sb.AppendLine(storageMaster.GetSummary());
            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
