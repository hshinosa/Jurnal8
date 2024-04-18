using modul8_1302220079;
using System.Text.Json;

class Program
{
    public static void Main(string[] args)
    {
        ProgramConfig config = new ProgramConfig();
        if (config.conf.lang == "en")
        {
            Console.Write("Please insert the amount of money to transfer: ");
        } else
        {
            Console.Write("Masukkan jumlah uang yang akan di-transfer: ");
        }

        string jumlahStr = Console.ReadLine();
        int jumlah = int.Parse(jumlahStr);

        if (jumlah <= config.conf.transfer.threshold)
        {
            jumlah += config.conf.transfer.low_fee;
        } else
        {
            jumlah += config.conf.transfer.high_fee;
        }
        
        if (config.conf.lang == "en")
        {
            Console.WriteLine("Total Amount: " + jumlah);
            printMethods();
            Console.WriteLine("Select Transfer Method: ");
        } else
        {
            Console.WriteLine("Total Biaya: " + jumlah);
            printMethods();
            Console.WriteLine("Pilih Metode Transfer: ");
        }

        string methodsStr = Console.ReadLine();
        int methods = int.Parse(methodsStr);

        if (config.conf.lang == "en")
        {
            Console.WriteLine("Please type " + config.conf.confirmation.en + " to confirm the transaction:");
        } else
        {
            Console.WriteLine("Ketik " + config.conf.confirmation.id + " untuk mengkonfirmasi transaksi: ");
        }

        string inputConfirmation = Console.ReadLine();

        if (inputConfirmation == config.conf.confirmation.en)
        {
            Console.WriteLine("The transfer is completed");
        }
        else if (inputConfirmation == config.conf.confirmation.id)
        {
            Console.WriteLine("Proses transfer berhasil");
        }
        else
        {
            if (config.conf.lang == "en")
            {
                Console.WriteLine("Transfer is cancelled");
            }
            else
            {
                Console.WriteLine("transfer dibatalkan");
            }
        }

        void printMethods()
        {
            ProgramConfig config = new ProgramConfig();
            int index = 1;
            foreach (var item in config.conf.methods)
            {
                Console.WriteLine(index++ + ". " + item);
            }
        }
    }
}

class ProgramConfig
{
    public BankTransferConfig conf;
    public string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
    public string configFileName = "bank_transfer_config.json";
    public ProgramConfig()
    {
        try
        {
            ReadConfigFile();
        }
        catch
        {
            SetDefault();
            WriteNewConfigFile();
        }
    }

    private void SetDefault()
    {
        TransferConfig transfer = new TransferConfig(25000000, 6500, 15000);
        ConfirmationConfig confirmation = new ConfirmationConfig("yes", "ya");
        List<string> methods = new List<string>() { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
        conf = new BankTransferConfig("en", transfer, methods, confirmation);

    }

    private BankTransferConfig ReadConfigFile()
    {
        string jsonFromFile = File.ReadAllText(path + '/' + configFileName);
        conf = JsonSerializer.Deserialize<BankTransferConfig>(jsonFromFile);
        return conf;
    }

    private void WriteNewConfigFile()
    {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };

        String jsonString = JsonSerializer.Serialize(conf, options);
        string fullPath = path + '/' + configFileName;
        File.WriteAllText(fullPath, jsonString);
    }
}