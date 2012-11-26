// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using System;
using System.IO;
using System.Web.Hosting;
using LayersCMS.Data.Persistence.Implementations.Reads;
using LayersCMS.Data.Persistence.Interfaces.Reads;
using LayersCMS.Images.Manipulation;
using LayersCMS.Images.Manipulation.Implementations;
using LayersCMS.Images.Storage;
using LayersCMS.Util.Security.Implementations;
using LayersCMS.Util.Security.Interfaces;
using StructureMap;

namespace LayersCMS.MvcApp.Application.DependencyResolution {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.AssemblyContainingType<HashHelper>();
                                        scan.AssemblyContainingType<LayersCmsUserReads>();
                                        scan.WithDefaultConventions();
                                    });

                            String cmsUploadPath = HostingEnvironment.MapPath("~/Content/_files/");
                            String cmsImageUploadPath = Path.Combine(cmsUploadPath, @"img/");
                            x.For<IImageStore>().Use<ImageFileStore>().Ctor<String>("folderPath").Is(cmsImageUploadPath);
                            x.For<IImageManipulator>().Use<ImageResizerManipulator>();

                            x.SetAllProperties(y =>
                                {
                                    y.OfType<ILayersCmsUserReads>();
                                    y.OfType<IHashHelper>();
                                });
                        });
            return ObjectFactory.Container;
        }
    }
}