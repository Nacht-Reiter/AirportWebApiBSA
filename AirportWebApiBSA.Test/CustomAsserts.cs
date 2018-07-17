using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportWebApiBSA.Test
{
    public class CustomAsserts
    {
        public static bool AreEqualByJson(object expected, object actual)
        {

            var expectedJson = JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(actual);
            return expectedJson.Equals(actualJson);
        }
    }
}
