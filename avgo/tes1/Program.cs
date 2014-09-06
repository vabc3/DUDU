using Avro;
using Avro.IO;
using Avro.File;
using Avro.Generic;
using Avro.Specific;
using example.avro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace tes1
{
    class Program
    {
        static void Main(string[] args)
        {
            string schema = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("tes1.user.avsc")).ReadToEnd();
            Console.WriteLine(schema);
            var sch = Schema.Parse(schema) as RecordSchema;

            MemoryStream ms = new MemoryStream();
            User u1 = new User();
            u1.Put(0, "dfa");
            var writer = new SpecificDatumWriter<User>(sch);
            Avro.IO.Encoder enc= new BinaryEncoder(ms);
            writer.Write(u1, enc);
            ms.Seek(0, SeekOrigin.Begin);
            string st = new StreamReader(ms).ReadToEnd();

            File.WriteAllText("b.txt", st);
            //Console.WriteLine(st);

            //var fs = new FileStream("a.txt", FileMode.Open);
            Avro.IO.Decoder decoder = new BinaryDecoder(ms);
            var reader = new SpecificDatumReader<User>(sch, sch);
            var user = reader.Read(null, decoder);
            Console.WriteLine(user.Name);
        }

        private static void basewrite(RecordSchema sch)
        {
            //Console.WriteLine(sch.GetType());
            var dt = new GenericRecord(sch);
            dt.Add("name", "1111");
            var writer = DataFileWriter<GenericRecord>.OpenWriter(new GenericDatumWriter<GenericRecord>(sch), "a.txt");
            writer.Append(dt);
            writer.Close();
            //DataFileWriter(open("users.avro", "w"), DatumWriter(), schema)
            //writer.append({"name": "Alyssa", "favorite_number": 256})
            //writer.append({"name": "Ben", "favorite_number": 7, "favorite_color": "red"})
            //writer.close()
        }
    }
}
