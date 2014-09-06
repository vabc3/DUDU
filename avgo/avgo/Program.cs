using Avro;
using Avro.File;
using Avro.Generic;
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
            //Console.WriteLine(sch.GetType());
            var dt = new GenericRecord(sch);
           // dt.Add("name", "be");
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
