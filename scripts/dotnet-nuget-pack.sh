#!/bin/bash
if [ "$CIRCLE_BRANCH" == "main" ]; then
   dotnet pack -p:PackageVersion=1.1.$CIRCLE_BUILD_NUM --no-restore -o .
   dotnet nuget push *.nupkg --api-key $NYGET_API_KEY --source $NUGET_API_URL
fi
