using Common.Dto.Template;
using System.IO;
using Newtonsoft.Json;

namespace Repositories
{
    public class ArmParameters : IArmParameters
    {
        private readonly ParametersDto Parameters;

        public ArmParameters(string FilePath)
        {
            using StreamReader fileReader = new(FilePath);
            string JsonContent = fileReader.ReadToEnd();

            this.Parameters = JsonConvert.DeserializeObject<ParametersDto>(JsonContent);
        }

        public ParametersDto GetParametersDto()
        {
            return this.Parameters;
        }
    }
}