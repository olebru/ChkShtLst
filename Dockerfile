FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY /home/runner/work/ChkShtLst/ChkShtLst/bin/release/net5.0/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "ChkShtLst.dll"]
