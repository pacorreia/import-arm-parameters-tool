using System;
using Newtonsoft.Json;
using Common.Dto.Devops;
using Services.Mappers;
using System.Collections.Generic;
using Utils.HttpClient;
using Common.Exceptions;
using RestSharp;

namespace Repositories
{
    public class AzureDevopsClient : IAzureDevopsClient
    {
        private readonly string DevopsOrganization;
        private readonly ProjectDto DevopsProject;
        private readonly string PAT;
        private readonly string VariableGroupName;

        public AzureDevopsClient(string DevopsOrganization, string DevopsProjectName, string VariableGroupName, string PAT)
        {
            this.DevopsOrganization=DevopsOrganization;
            this.VariableGroupName=VariableGroupName;
            this.PAT=PAT;

            this.DevopsProject=InitDevopsProjectDto(DevopsProjectName);
        }

        private ProjectDto InitDevopsProjectDto(string ProjectName)
        {
            
            string url=$"https://dev.azure.com/{this.DevopsOrganization}/_apis/projects/{ProjectName}?api-version=6.1-preview.2";
            
            AppHttpClient DevopsAPIClient=new(url, "user",this.GetPAT());            

            try{                
                return JsonConvert.DeserializeObject<ProjectDto>(DevopsAPIClient.SendGet().Content);
            }
            catch (AppRuntimeException ex){               
                
                Console.WriteLine($"Response status: {ex.Status}");
                Console.WriteLine($"Message: {ex.Message}");

                throw;                
            }
        }
        public string GetProjectName()
        {
            return this.DevopsProject.Name;
        }

        public string GetPAT()
        {
            return this.PAT;
        }

        public string GetProjectId()
        {
            return this.DevopsProject.Id;
        }

        public string GetProjectUrl()
        {
            return this.DevopsProject.Url;
        }

        public VariableGroupRequestDto CreateVariableGroupFromARM(string FilePath){
            
            IArmParameters parameters = new ArmParameters(FilePath);            

            VariableGroupRequestDto VariableGroupRequest = ARMtoDevopsMapper.MapParametersToVariableGroupRequest(parameters.GetParametersDto());

            VariableGroupRequest.Name=VariableGroupName;
            VariableGroupRequest.VariableGroupProjectReferences = new List<VariableGroupProjectReferencesDto>
            {
                new VariableGroupProjectReferencesDto
                {
                    Name = VariableGroupName,
                    Description = "",
                    ProjectReference = new ProjectReferenceDto
                    {
                        Id = GetProjectId(),
                        Name = ""
                    }

                }
            };

            return UploadVariableGroup(VariableGroupRequest);
        }
        private VariableGroupRequestDto UploadVariableGroup(VariableGroupRequestDto RequestDto)
        {
            string url=$"https://dev.azure.com/{DevopsOrganization}/_apis/distributedtask/variablegroups?api-version=6.1-preview.2";
            
            AppHttpClient DevopsAPIClient=new(url,"user",GetPAT());

            try
            {
                IRestResponse response = DevopsAPIClient.SendPost(RequestDto);

                return JsonConvert.DeserializeObject<VariableGroupRequestDto>(response.Content);
            }
            catch (AppRuntimeException ex){

                VariableGroupError error = JsonConvert.DeserializeObject<VariableGroupError>(ex.Message);

                Console.WriteLine(error.Message);

                throw;               
            }
        }
    }
}

