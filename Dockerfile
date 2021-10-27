FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY ./bin/release/net5.0/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "ChkShtLst.dll"]
CMD [ "arg0" ]
