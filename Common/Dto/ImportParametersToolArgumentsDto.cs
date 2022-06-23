using CommandLine;

namespace Common.Dto
{
    public class ImportParametersToolArgumentsDto
    {
        [Option('f',"parametersfile",Required = true, HelpText = "ARM parameters file")]
        public string ParametersFile {get; set;}
        
        [Option('o',"org",Required = true, HelpText = "Azure Devops Organization")]
        public string DevopsOrganization {get; set;}

        [Option('p',"project",Required = true, HelpText = "Azure Devops Project Name")]
        public string DevopsProjectName {get; set;}

        [Option('v',"variablegroup",Required=true,HelpText = "Azure Devops Variable Group Name")]        
        public string VariableGroupName {get; set;}

        [Option('t',"accesstoken",Required = true,HelpText = "Azure Devops Personal Access Token")]
        public string PersonalAccessToken {get; set;}
    }
}