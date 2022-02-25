using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace xUnitBasics
{
    public class SumDataFromJsonTest
    {
        [Theory]
        [JsonFileData("all_data.json")]
        public void Sum_TupleValues_ShouldBeCorrect(
            int expected, int a, int b)
        {
            Assert.Equal(expected, Sum(a, b));
        }

        private static int Sum(int a, int b)
        {
            return a + b;
        }

        public class JsonFileDataAttribute : DataAttribute
        {
            private readonly string _filePath;

            public JsonFileDataAttribute(string filePath)
            {
                _filePath = filePath;
            }

            public override IEnumerable<object[]> GetData(MethodInfo testMethod)
            {
                if (testMethod == null) { throw new ArgumentNullException(nameof(testMethod)); }

                var path =  _filePath;
                if (!File.Exists(path))
                {
                    throw new ArgumentException($"Could not find file at path: {path}");
                }

                var fileData = File.ReadAllText(_filePath);

                return JsonConvert.DeserializeObject<List<object[]>>(fileData);
            }
        }
    }
}
