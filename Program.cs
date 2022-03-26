using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace csDNact3
{
    class database
    {
        public void testdb()
        {
            using (
                SqlConnection con = new SqlConnection("data source = ASKAR;database = bakeryexe;" + "user ID = sa; Password = 123456")
                )
            {
                con.Open();
                Console.WriteLine("Berhasil terhubung ke database!");
                Console.Read();
            }
        }

        public void masukindata()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=ASKAR;database=bakeryexe;Integrated Security = TRUE");
                con.Open();
                SqlCommand cm = new SqlCommand(

                    //kostumer
                    "insert into KOSTUMER(ID_KOSTUMER,NAMA,NO_HP) VALUES ('C000001'     ,'Ahmad'    ,'081324370987');"
                    + "insert into KOSTUMER(ID_KOSTUMER,NAMA,NO_HP) VALUES ('C000002'    ,'Mustofa'  ,'081867097232');"
                    + "insert into KOSTUMER(ID_KOSTUMER,NAMA,NO_HP) VALUES ('C000003'    ,'Rizki'    ,'081301017888');"
                    + "insert into KOSTUMER(ID_KOSTUMER,NAMA,NO_HP) VALUES ('C000004'    ,'Putra'    ,'081124938762');"
                    + "insert into KOSTUMER(ID_KOSTUMER,NAMA,NO_HP) VALUES ('C000005'    ,'Sulung'   ,'081308421123');" +
                    //kasir
                    "insert into KASIR(ID_KASIR,NAMA) VALUES ('K000001'     ,'Anas');" +
                    "insert into KASIR(ID_KASIR,NAMA) VALUES ('K000002'     ,'Malik');" +
                    "insert into KASIR(ID_KASIR,NAMA) VALUES ('K000003'     ,'Abdul');" +
                    "insert into KASIR(ID_KASIR,NAMA) VALUES ('K000004'     ,'Muhamad');" +
                    "insert into KASIR(ID_KASIR,NAMA) VALUES ('K000005'     ,'Yuli');" +
                    //baranag
                    "insert into BARANG(ID_BARANG,NAMA,HARGA) VALUES ('B000001'     ,'Kue Pandan'       ,12000);" +
                    "insert into BARANG(ID_BARANG,NAMA,HARGA) VALUES ('B000002'     ,'Bolu Coklat'      ,15000);" +
                    "insert into BARANG(ID_BARANG,NAMA,HARGA) VALUES ('B000003'     ,'Cookies Keju'     ,10000);" +
                    "insert into BARANG(ID_BARANG,NAMA,HARGA) VALUES ('B000004'     ,'Onde-Onde'        ,7000);" +
                    "insert into BARANG(ID_BARANG,NAMA,HARGA) VALUES ('B000005'     ,'Pisang Stroberi'  ,17000);" +
                    //transaksi
                    "insert into TRANSAKSI(ID_TRANSAKSI,TANGGAL_TRANSAKSI) VALUES ('TR00001'    ,'2021-01-08');" +
                    "insert into TRANSAKSI(ID_TRANSAKSI,TANGGAL_TRANSAKSI) VALUES ('TR00002'    ,'2021-02-08');" +
                    "insert into TRANSAKSI(ID_TRANSAKSI,TANGGAL_TRANSAKSI) VALUES ('TR00003'    ,'2019-11-18');" +
                    "insert into TRANSAKSI(ID_TRANSAKSI,TANGGAL_TRANSAKSI) VALUES ('TR00004'    ,'2021-12-31');" +
                    "insert into TRANSAKSI(ID_TRANSAKSI,TANGGAL_TRANSAKSI) VALUES ('TR00005'    ,'2022-01-01');" +
                    //order
                    "insert into [ORDER](ID_ORDER,FK_KASIR,FK_BARANG,FK_TRANSAKSI,FK_KOSTUMER,QTY) VALUES ('O000001','K000001','B000001','TR00001','C000001', 20); " +
                    "insert into [ORDER](ID_ORDER,FK_KASIR,FK_BARANG,FK_TRANSAKSI,FK_KOSTUMER,QTY) VALUES ('O000002','K000002','B000002','TR00002','C000002', 5);" +
                    "insert into [ORDER](ID_ORDER,FK_KASIR,FK_BARANG,FK_TRANSAKSI,FK_KOSTUMER,QTY) VALUES ('O000003','K000003','B000003','TR00003','C000003', 18);" +
                    "insert into [ORDER](ID_ORDER,FK_KASIR,FK_BARANG,FK_TRANSAKSI,FK_KOSTUMER,QTY) VALUES ('O000004','K000004','B000004','TR00004','C000004', 18);" +
                    "insert into [ORDER](ID_ORDER,FK_KASIR,FK_BARANG,FK_TRANSAKSI,FK_KOSTUMER,QTY) VALUES ('O000005','K000005','B000005','TR00005','C000005', 9);", con);

                cm.ExecuteNonQuery();
                Console.WriteLine("Data telah dimasukkan ke dalam database");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, Sepertinya ada yang salah. " + e);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            database db = new database();
            string pilihan;
            Console.WriteLine("1. Tes Konektivitas Database");
            Console.WriteLine("2. Memasukkan Data ke semua tabel");
            Console.WriteLine("3. keluar");
            Console.Write("Pilihan Anda : ");
            pilihan = Console.ReadLine();
            switch (pilihan)
            {
                case "1":
                    db.testdb();
                    break;

                case "2":
                    db.masukindata();
                    break;

                case "3":
                    Console.WriteLine("Keluar");
                    break;
            }
        }
    }
}
