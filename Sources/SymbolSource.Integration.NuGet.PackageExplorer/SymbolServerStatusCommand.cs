﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using NuGet;
using NuGetPackageExplorer.Types;

namespace SymbolSource.Integration.NuGet.PackageExplorer
{
    [PackageCommandMetadata("Symbol server status...")]
    public class SymbolServerStatusCommand : IPackageCommand
    {
        public void Execute(global::NuGetPe.IPackage package, string packagePath)
        {
            new Form1(new SymbolServerChecker(new PackageWrapper(package, packagePath))).ShowDialog();
        }
    }
}
