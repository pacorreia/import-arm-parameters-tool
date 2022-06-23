using System.Collections.Generic;
using Repositories;
using CommandLine;
using Common.Dto;
using System;

namespace tools
{
    static class ImportParametersTool
    {
        static int Main(string[] args)
        {
            ImportParametersToolArgumentsDto arguments=new();
            IEnumerable<Error> ParseErrors=null;

            Parser.Default.ParseArguments<ImportParametersToolArgumentsDto>(args)
                .WithParsed(result => arguments=result)
                .WithNotParsed(errors => ParseErrors=errors);
                       
            if (ParseErrors is not null)
            {
                return -1;
            }

            string FilePath = arguments.ParametersFile;
            string DevopsOrganization=arguments.DevopsOrganization;
            string DevopsProjectName=arguments.DevopsProjectName;
            string VariableGroupName=arguments.VariableGroupName;
            string PAT=arguments.PersonalAccessToken;

            AzureDevopsClient DevopsClient=new(DevopsOrganization,DevopsProjectName,VariableGroupName,PAT);

            Console.WriteLine(DevopsClient.CreateVariableGroupFromARM(FilePath));
            return 0;
        }
    }
}
