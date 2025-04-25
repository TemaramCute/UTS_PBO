using System;

namespace BankPelita
{
    // Class Nasabah
    class Nasabah
    {
        // Atribut
        public string NomorRekening { get; set; }
        public string NamaPemilik { get; set; }
        public decimal Saldo { get; set; }

        // Constructor
        public Nasabah(string nomorRekening, string namaPemilik, decimal saldoAwal)
        {
            NomorRekening = nomorRekening;
            NamaPemilik = namaPemilik;
            Saldo = saldoAwal;
        }

        // Method Penarikan Dana
        public void TarikDana(decimal jumlah)
        {
            if (Saldo >= jumlah)
            {
                Saldo -= jumlah;
                Console.WriteLine($"Penarikan berhasil. Sisa saldo: {Saldo:C}");
            }
            else
            {
                Console.WriteLine("Saldo tidak mencukupi untuk penarikan.");
            }
        }

        // Method Setor Tunai
        public void SetorTunai(decimal jumlah)
        {
            Saldo += jumlah;
            Console.WriteLine($"Setoran berhasil. Saldo sekarang: {Saldo:C}");
        }

        // Method Transfer
        public void Transfer(Nasabah penerima, decimal jumlah)
        {
            if (Saldo >= jumlah)
            {
                Saldo -= jumlah;
                penerima.Saldo += jumlah;
                Console.WriteLine($"Transfer berhasil ke {penerima.NamaPemilik}. Sisa saldo: {Saldo:C}");
            }
            else
            {
                Console.WriteLine("Saldo tidak mencukupi untuk transfer.");
            }
        }

        // Method Menampilkan Data Rekening
        public void TampilkanData()
        {
            Console.WriteLine($"Nomor Rekening: {NomorRekening}");
            Console.WriteLine($"Nama Pemilik: {NamaPemilik}");
            Console.WriteLine($"Saldo: {Saldo:C}");
        }
    }

    // Program Utama
    class Program
    {
        static void Main(string[] args)
        {
            // Membuat beberapa nasabah
            Nasabah nasabah1 = new Nasabah("1234567890", "Kiya", 5000000);
            Nasabah nasabah2 = new Nasabah("0987654321", "Andika", 3000000);

            Console.WriteLine("Data Nasabah 1:");
            nasabah1.TampilkanData();
            Console.WriteLine();

            Console.WriteLine("Data Nasabah 2:");
            nasabah2.TampilkanData();
            Console.WriteLine();

            // Contoh Penarikan Dana
            Console.WriteLine("Penarikan Dana dari Nasabah 1 sebesar 1.000.000:");
            nasabah1.TarikDana(1000000);
            Console.WriteLine();

            // Contoh Setor Tunai
            Console.WriteLine("Setor Tunai ke Nasabah 2 sebesar 500.000:");
            nasabah2.SetorTunai(500000);
            Console.WriteLine();

            // Contoh Transfer Antar Rekening
            Console.WriteLine("Transfer dari Nasabah 1 ke Nasabah 2 sebesar 2.000.000:");
            nasabah1.Transfer(nasabah2, 2000000);
            Console.WriteLine();

            // Tampilkan Data Akhir
            Console.WriteLine("Data Nasabah 1 Setelah Transaksi:");
            nasabah1.TampilkanData();
            Console.WriteLine();

            Console.WriteLine("Data Nasabah 2 Setelah Transaksi:");
            nasabah2.TampilkanData();

            Console.ReadKey();
        }
    }
}