using Microsoft.Hadoop.Avro.Schema;
using Microsoft.Hadoop.Avro.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Hadoop.Avro;
using System.IO;
using System.Reflection;

namespace tes2
{
    class Program
    {
        static void Main(string[] args)
        {
            string schema = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("tes2.user.avsc")).ReadToEnd();
            var serializer = AvroSerializer.CreateGeneric(schema);
        }
    }
}
