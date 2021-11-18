#!/bin/bash
if [ "$CIRCLE_BRANCH" == "main" ]; then
   dotnet pack --output ./publish --configuration Release -p:PackageVersion=1.1.$CIRCLE_BUILD_NUM
   dotnet nuget push "./publish/*.nupkg" --api-key $NYGET_API_KEY --source $NUGET_API_URL
fi
