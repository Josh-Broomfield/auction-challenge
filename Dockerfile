FROM mono:latest

#RUN apt-get upgrade && apt-get update
#RUN mono --version
ADD . /src
WORKDIR /src
RUN nuget restore && msbuild Auction-Challenge.sln /p:Configuration=Release

ENTRYPOINT [ "mono", "/src/Auction-Challenge/bin/Release/Auction-Challenge.exe" ]
#ENTRYPOINT [ "mono", "/src/packages/NUnit.ConsoleRunner.3.11.1/tools/nunit3-console.exe", "/src/Auction-Challenge-UnitTest/bin/Release/Auction-Challenge-UnitTest.dll" ]