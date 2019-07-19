            ManagementScope ms = new ManagementScope(@"\\192.168.20.194\root\cimv2");
            ConnectionOptions cop = new ConnectionOptions();
            cop.Username = "administrator";
            cop.Password = "dell@2019NV";
            ms.Options = cop;

            ms.Connect();

            System.IO.File.Delete(@"\\192.168.20.194\dt\test.txt");
            Console.WriteLine("ok");