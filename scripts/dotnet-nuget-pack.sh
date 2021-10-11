#!/bin/bash

if [ "$TRAVIS_BRANCH" == "main" ]; then
   cd ..
   dotnet pack -p:PackageVersion=1.0.0 --no-restore -o .
   dotnet nuget push *.nupkg --api-key $NYGET_API_KEY --source https://api.nuget.org/v3/index.json
fi