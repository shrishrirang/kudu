﻿using System.Collections.Generic;
using Kudu.Client.Model;
using Kudu.Client.Models;
using Kudu.Core.Deployment;
using Kudu.Core.Editor;
using Kudu.Core.SourceControl;
using SignalR;
using SignalR.Hubs;

namespace Kudu.Client.Infrastructure {
    public class SiteConfiguration : ISiteConfiguration {
        private static readonly Dictionary<string, ISiteConfiguration> _cache = new Dictionary<string, ISiteConfiguration>();

        public SiteConfiguration(IApplication application) {

            ServiceUrl = application.ServiceUrl;
            SiteUrl = application.SiteUrl;
            Name = application.Name;

            ISiteConfiguration config;
            if (_cache.TryGetValue(Name, out config)) {
                Repository = config.Repository;
                FileSystem = config.FileSystem;
                DeploymentManager = config.DeploymentManager;
                RepositoryManager = config.RepositoryManager;
            }
            else {
                Repository = new RemoteRepository(ServiceUrl + "scm");
                FileSystem = new RemoteFileSystem(ServiceUrl + "files");
                DeploymentManager = new RemoteDeploymentManager(ServiceUrl + "deploy");
                RepositoryManager = new RemoteRepositoryManager(ServiceUrl + "scm");

                DeploymentManager.StatusChanged += OnDeploymentStatusChanged;

                _cache[Name] = this;
            }
        }

        private void OnDeploymentStatusChanged(DeployResult result) {
            // HACK: This is kinda hacky for now since Signalr doesn't have good support
            // for sending messages through hubs from arbitrary code. I promise it will get better
            var connection = Connection.GetConnection<HubDispatcher>();
            ClientAgent.Invoke(connection,
                               "updateDeployStatus",
                               typeof(SourceControl).FullName,
                               "updateDeployStatus",
                               new[] { new DeployResultViewModel(result) });
        }

        public string Name { get; private set; }
        public string ServiceUrl { get; private set; }
        public string SiteUrl { get; private set; }

        public IFileSystem FileSystem {
            get;
            private set;
        }

        public IDeploymentManager DeploymentManager {
            get;
            private set;
        }

        public IRepositoryManager RepositoryManager {
            get;
            private set;
        }

        public IRepository Repository {
            get;
            private set;
        }

    }
}