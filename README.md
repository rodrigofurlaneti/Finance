
<iframe src="[caminho/para/sua/pagina.html](https://github.com/rodrigofurlaneti/Finance/blob/master/report/index.html)" width="100%" height="100%"></iframe>

Install (run as admin)
dotnet tool install -g dotnet-coverage
dotnet tool install -g dotnet-reportgenerator-globaltool
Run tests with XML output format:
dotnet-coverage collect -f xml -o coverage.xml dotnet test <solution/project>
Generate html report
reportgenerator -reports:coverage.xml -targetdir:.\report -assemblyfilters:+MyTestedAssembly.dll
Open report\index.html
