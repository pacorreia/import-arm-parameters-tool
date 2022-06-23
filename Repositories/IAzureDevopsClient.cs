using Common.Dto.Devops;

namespace Repositories
{
    public interface IAzureDevopsClient
    {
        public string GetProjectUrl();
        public string GetProjectId();
        public string GetProjectName();
        public string GetPAT();
        public VariableGroupRequestDto CreateVariableGroupFromARM(string FilePath);

    }
}