using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DemoFileHandling
    {
        public void DemoDriveInfo()
        {
            DriveInfo[] di = DriveInfo.GetDrives();
            foreach (DriveInfo di2 in di)
            {
                Console.WriteLine(di2.Name);
            }

            DriveInfo d1 = new DriveInfo("E");
            Console.WriteLine(d1.Name);
            Console.WriteLine(d1.TotalSize);
            Console.WriteLine(d1.RootDirectory);
        }

        public void DemoDirectoryInfo()
        {
            //DirectoryInfo di = new DirectoryInfo(@"E:\NCL");

            //Console.WriteLine("Full name = {0}" , di.Name);
            //Console.WriteLine("Creation Time = {0}", di.CreationTime);
            //Console.WriteLine("Parent = {0}", di.Parent);

            //create a directory
            //DirectoryInfo d1 = new DirectoryInfo(@"E:\temp\xyz");
            //d1.Create();

            Directory.Delete(@"E:\temp\xyz");
        }

        public void DemoReadAllText()
        {
            string filePath = @"E:\Textfile.txt";
            Console.WriteLine("Reading file using ReadAllText()");

            if(File.Exists(filePath))
            {
                string str = File.ReadAllText(filePath);
                Console.WriteLine(str);
            }
        }

        public void DemoReadAllLines()
        {
            string filePath = @"E:\Textfile.txt";
            Console.WriteLine("Reading file using ReadAllLines()");

            if (File.Exists(filePath))
            {
                string[] str = File.ReadAllLines(filePath);
                foreach (var item in str)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void DemoWriteToFile()
        {
            string filePath = @"E:\Textfile.txt";
            //string str = "this is some text";

            //File.WriteAllText(filePath, str);

            string[] text = {"this is the first line",
                            "this is the second line",
                            "this is the last line"};

            File.WriteAllLines(filePath, text);
        }

        public void DemoFileStream()
        {
            using (FileStream fs = new FileStream(@"E:\Textfile.txt", FileMode.Create))
            {
                string message = "this is the first file stream";
                byte[] byteArray =  Encoding.Default.GetBytes(message);

                fs.Write(byteArray,0, byteArray.Length);
                fs.Write(byteArray, 0, byteArray.Length);
                Console.WriteLine("position in stream {0}", fs.Position);
                fs.Position = 0;
                //read
                byte [] readBytes = new byte[fs.Length];

                fs.Read(readBytes, 0, readBytes.Length);
                Console.WriteLine(Encoding.Default.GetString(readBytes));       
            }
        }

        public void DemoStreamWriter()
        {
            StreamWriter streamWriter = new StreamWriter(@"E:\Textfile.txt");

            Console.WriteLine("Enter the text you want to write to file");
            string message = Console.ReadLine();

            streamWriter.WriteLine(message);
            streamWriter.WriteLine(message);
            streamWriter.WriteLine(message);

            streamWriter.Flush();
            streamWriter.Close();
        }

        public void DemoStreamReader()
        {
            StreamReader streamReader = new StreamReader(@"E:\Textfile.txt");

            Console.WriteLine("content of the file");
            Console.WriteLine("position before seek {0}", streamReader.BaseStream.Position);
            streamReader.BaseStream.Seek(10, SeekOrigin.Begin);
            Console.WriteLine("position after seek {0}", streamReader.BaseStream.Position);

            string str = streamReader.ReadLine();
            while(str != null)
            {
                Console.WriteLine(str);
                str = streamReader.ReadLine();
            }

            streamReader.Close();
        }

        public void DemoBinaryStream()
        {
            FileInfo fileInfo = new FileInfo(@"E:\Samplefile.dat");
            using(BinaryWriter bw = new BinaryWriter(fileInfo.OpenWrite()))
            {
                int x = 98;
                string str = "some sample string";

                bw.Write(x);
                bw.Write(str);
            }

            using(BinaryReader br = new BinaryReader(fileInfo.OpenRead()))
            {
                Console.WriteLine(br.ReadInt32());
                Console.WriteLine(br.ReadInt32());
            }
        }

        public void DemoStreamAndFile()
        {
            using (FileStream fs = new FileStream(@"E:\Textfile.txt", FileMode.Create))
            {
                StreamWriter streamWriter = new StreamWriter(fs);

                streamWriter.WriteLine("some data to file");
                streamWriter.Close();
            }
        }
    }
}
