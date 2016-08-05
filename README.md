This code demoes a small problem that [I reported to the dotnet core team.](https://github.com/dotnet/corefx/issues/10566) See that issue for a work-around solution.

According to my understanding of the conversation in [this issue](https://github.com/dotnet/corefx/issues/2936), dotnet core supports APM methods for sockets, such as `BeginConnect` and `EndConnect`. I believe the support for it appears [here](https://github.com/dotnet/corefx/blob/master/src/Common/src/System/Net/Sockets/SocketAPMExtensions.cs) in the source code. I must be doing something wrong, however, because I am unable to access those methods in my code. This repo has the necessary code to reproduce the issue.
```bash
docker-compose build
```
I get the following:
```bash
Building app
Step 1 : FROM microsoft/dotnet:latest
 ---> 3502ab7a3654
Step 2 : COPY . /app
 ---> d129994eb685
Removing intermediate container a6ad53b0061f
Step 3 : RUN dotnet restore /app
 ---> Running in a04726ff78a2
log  : Restoring packages for /app/project.json...
log  : Writing lock file to disk. Path: /app/project.lock.json
log  : /app/project.json
log  : Restore completed in 608ms.
 ---> b3934c2e0aeb
Removing intermediate container a04726ff78a2
Step 4 : RUN dotnet build /app
 ---> Running in 38dfed6ca88a
Project app (.NETStandard,Version=v1.6) will be compiled because expected outputs are missing
Compiling app for .NETStandard,Version=v1.6
/usr/share/dotnet/dotnet compile-csc @/app/obj/Debug/netstandard1.6/dotnet-compile.rsp returned Exit Code 1
/app/Program.cs(15,35): error CS1061: 'Socket' does not contain a definition for 'BeginConnect' and no extension method 'BeginConnect' accepting a first argument of type 'Socket' could be found (are you missing a using directive or an assembly reference?)
/app/Program.cs(16,56): error CS1061: 'Socket' does not contain a definition for 'EndConnect' and no extension method 'EndConnect' accepting a first argument of type 'Socket' could be found (are you missing a using directive or an assembly reference?)

Compilation failed.
    0 Warning(s)
    2 Error(s)

Time elapsed 00:00:01.2293181
```
