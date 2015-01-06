﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageConfigBuilder.cs" company="Appccelerate">
//   Copyright (c) 2008-2015
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Appccelerate.CheckNugetDependenciesTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class PackageConfigBuilder
    {
        private List<string> references = new List<string>();

        private PackageConfigBuilder()
        {
        }

        public static PackageConfigBuilder Create()
        {
            return new PackageConfigBuilder();
        }

        public PackageConfigBuilder AddReference(string id, string version)
        {
            this.references.Add(string.Concat("<package id=\"", id, "\" version=\"", version, "\" targetFramework=\"net45\" />"));

            return this;
        }

        public PackageConfigBuilder AddDevelopmentReference(string id, string version)
        {
            this.references.Add(string.Concat("<package id=\"", id, "\" version=\"", version, "\" targetFramework=\"net45\" developmentDependency=\"true\" />"));

            return this;
        }

        public XDocument Build()
        {
            return XDocument.Parse(
@"<?xml version=""1.0"" encoding=""utf-8""?>
<packages>"
  + string.Join(Environment.NewLine, this.references) +
"</packages>");
        }
    }
}