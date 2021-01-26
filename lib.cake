using YamlDotNet.Serialization;
using Cake.Core.IO;
using Cake.Common.IO;
using Cake.Common.IO.Paths;
// using Amazon;
// using Amazon.KeyManagementService;
// using Amazon.KeyManagementService.Model;
// using Amazon.Runtime;

public class BuildConfiguration {
    [YamlMember(Alias = "solutionName")]
    public string SolutionName { get; set; }

    // [YamlMember(Alias = "output")]
    // public OutputSettings Output { get; set; }

    [YamlMember(Alias = "test")]
    public TestSettings Test { get; set; }

    [YamlMember(Alias = "environment")]
    public EnvironmentVariableSettings EnvironmentVariableSettings { get; set; }

    public ICakeContext Context { get; set; }

    public void SetEnvironmentVariables() {
        foreach(var envVar in EnvironmentVariableSettings.Variables) {
            Environment.SetEnvironmentVariable(string.Format("{0}{1}", EnvironmentVariableSettings.Prefix, envVar.Key.ToUpper()), envVar.Value);
        }
    }

    public string GetEnvironmentVariable(string key) {
        return Environment.GetEnvironmentVariable(string.Format("{0}{1}", EnvironmentVariableSettings.Prefix, key.ToUpper()));
    }
}

public class EnvironmentVariableSettings {
    [YamlMember(Alias = "prefix")]
    public string Prefix { get; set; }

    [YamlMember(Alias = "vars")]
    public Dictionary<string, string> Variables { get; set; }

    // [YamlMember(Alias = "secrets")]
    // public Dictionary<string, Dictionary<string, string>> Secrets { get; set; }
}

// public class OutputSettings {
//     [YamlMember(Alias = "artifacts")]
//     public string ArtifactsFolder { get; set; }
//     [YamlMember(Alias = "publish")]
//     public string PublishFolder { get; set; }
//     [YamlMember(Alias = "projects")]
//     public List<OutputProject> Projects { get; set; }
//     [YamlMember(Alias = "packageSuffix")]
//     public string PackageNameSuffix { get; set; }

//     public IEnumerable<OutputProject> ForBuildMeta() {
//         return Projects.Where(p => p.GenerateBuildMeta);
//     }

//     public IEnumerable<ReleasePackage> PackagesForRelease(string version) {
//         return GetPackages(version, p => p.IncludeInOctopusRelease);
//     }

//     public IEnumerable<ReleasePackage> GetPackages(string version) {
//         return GetPackages(version, p => true);
//     }

//     public IEnumerable<ReleasePackage> GetPackages(string version, Func<OutputProject, bool> projectPredicate)
//     {
//         var artifactsDir = new DirectoryPath(ArtifactsFolder);
//         foreach(var proj in Projects.Where(projectPredicate)) {
//             var packageName = proj.GetPackageName(PackageNameSuffix);
//             var packageFile = artifactsDir.CombineWithFilePath(string.Format("{0}.{1}.nupkg", packageName, version));
                        
//             yield return new ReleasePackage {
//                 Id = proj.Id,
//                 File = packageFile,
//                 Version = version,
//                 Name = packageName.ToString()
//             };
//         }
//     }
// }

// public class OutputProject {

//     public OutputProject() {
//     }

//     [YamlMember(Alias = "path")]
//     public string Path { get; set; }
//     [YamlMember(Alias = "id")]
//     public string Id { get; set; }
//     [YamlMember(Alias = "generate-build-meta")]
//     public bool GenerateBuildMeta { get; set; }

//     public string GetPackageName(string suffix) {
//         var simplePackageName = new FilePath(Path).GetFilenameWithoutExtension();

//         if(string.IsNullOrWhiteSpace(suffix))
//         {
//             return simplePackageName.ToString();
//         }
        
//         return string.Format("{0}.{1}", simplePackageName, suffix);
//     }
// }

public class TestSettings {
    [YamlMember(Alias = "unit")]
    public string UnitProjectPattern { get; set; }
    [YamlMember(Alias = "integration")]
    public string IntegrationProjectPattern { get; set; }
    [YamlMember(Alias = "acceptance")]
    public TestProjectSettings Acceptance { get; set; }
}

public class TestProjectSettings {
    [YamlMember(Alias = "glob")]
    public string Glob { get; set; }

    [YamlMember(Alias = "packageName")]
    public string PackageName { get; set; }
}

public class ReleasePackage {
    public string Id { get; set; }
    public string Version { get; set; }
    public string Name { get; set; }
    public FilePath File { get; set; }

    public override string ToString() {
        return string.Format("ReleasePkg {{Name:{0}, Id:{1}, Version:{2}, File:{3}}}", Name, Id, Version, File.ToString());
    }
}

public static string UriCombine(this string uri1, string uri2) => $"{uri1.TrimEnd('/')}/{uri2.TrimStart('/')}";

void Test(string testDllGlob, Cake.Common.Tools.DotNetCore.DotNetCoreVerbosity dotNetCoreVerbosity, string configuration)
{
    var testAssemblies = GetFiles(testDllGlob);
    var testVerbosity = Cake.Common.Tools.DotNetCore.DotNetCoreVerbosity.Normal;

    foreach(var testProject in testAssemblies)
    {
        Information("Testing '{0}'...", testProject.FullPath);
        var settings = new DotNetCoreTestSettings
        {
            Configuration = configuration,
            Verbosity = testVerbosity,
            NoBuild = true,
            NoRestore = true,
            Logger = "console;verbosity=" + testVerbosity.ToString().ToLower()
        };

        DotNetCoreTest(testProject.FullPath, settings);
    }
}