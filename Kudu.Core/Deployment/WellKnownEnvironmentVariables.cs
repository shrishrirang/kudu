﻿namespace Kudu.Core.Deployment
{
    internal static class WellKnownEnvironmentVariables
    {
        public const string NuGetPackageRestoreKey = "EnableNuGetPackageRestore";
        public const string SourcePath = "DEPLOYMENT_SOURCE";
        public const string TargetPath = "DEPLOYMENT_TARGET";
        public const string WebRootPath = "WEBROOT_PATH";
        public const string MSBuildPath = "MSBUILD_PATH";
        public const string KuduSyncCommandKey = "KUDU_SYNC_CMD";
        public const string NuGetExeCommandKey = "NUGET_EXE";
        public const string PostDeploymentActionsCommandKey = "POST_DEPLOYMENT_ACTION";
        public const string SelectNodeVersionCommandKey = "KUDU_SELECT_NODE_VERSION_CMD";
        public const string NpmJsPathKey = "NPM_JS_PATH";
        public const string BuildTempPath = "DEPLOYMENT_TEMP";
        public const string PreviousManifestPath = "PREVIOUS_MANIFEST_PATH";
        public const string NextManifestPath = "NEXT_MANIFEST_PATH";
        public const string InPlaceDeployment = "IN_PLACE_DEPLOYMENT";
        public const string PostDeploymentActionsDirectoryKey = "POST_DEPLOYMENT_ACTIONS_DIR";
        public const string ApplicationPoolId = "APP_POOL_ID";

        public const string WebJobsDeployCommandKey = "WEBJOBS_DEPLOY_CMD";
        public const string WebJobsRootPath = "WEBJOBS_PATH";
        public const string WebJobsName = "WEBJOBS_NAME";
        public const string WebJobsType = "WEBJOBS_TYPE";
        public const string WebJobsDataPath = "WEBJOBS_DATA_PATH";
        public const string WebJobsExtraUrlPath = "WEBJOBS_EXTRA_INFO_URL_PATH";
        public const string WebJobsRunId = "WEBJOBS_RUN_ID";
        public const string WebJobsShutdownNotificationFile = "WEBJOBS_SHUTDOWN_FILE";
        public const string WebJobsCommandArguments = "WEBJOBS_COMMAND_ARGUMENTS";

        public const string CommitId = "SCM_COMMIT_ID";
        public const string KreVersion = "SCM_KRE_VERSION";
        public const string KreClr = "SCM_KRE_CLR";
        public const string KreNugetApiUrl = "SCM_KRE_NUGET_API_URL";
        public const string KvmPath = "SCM_KVM_PS_PATH";
        public const string KreBitness = "SCM_KRE_ARCH";

        public const string SiteBitness = "SITE_BITNESS";
    }
}
