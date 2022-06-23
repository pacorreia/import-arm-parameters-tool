# Import ARM parameters tool

## Description

This tool is intended to assist in importing ARM parameters file (aka parameters.json) into an Azure Devops Variable group.

This helps setting up CI/CD process when doing deployment of ARM templates.

## Build

Just clone the repository and run `dotnet restore` and `dotnet build`.

The binary will be called `ImportParametersTool.exe`

## How to use

The tool requires 5 arguments:

- -f, --parametersfile    Required. ARM parameters file
- -o, --org               Required. Azure Devops Organization
- -p, --project           Required. Azure Devops Project Name
- -v, --variablegroup     Required. Azure Devops Variable Group Name
- -t, --accesstoken       Required. Azure Devops Personal Access Token
- --help                  Display this help screen.
- --version               Display version information.

To run the tool run like this `ImportParametersTool.exe -fc:\deployments\parameters.json -oCOFCOInternational -pIntegration Platform -vTest-Group -tSomeToken`

If everything went well the output will be `Common.Dto.Devops.VariableGroupRequestDto`
At the time of this document, the Dto had no override for string conversion.

In case the variable group already exists, the tool will log a message confirming such.

## TODO

The Azure Devops API is not yet fully mature, so some calls fails. Fro this reason some interesting features were not implemented like:

- Test existing of variable groups
- Update existing variable groups
- Get a list of existing variable groups and choose from there
- Create an automated release pipeline
  