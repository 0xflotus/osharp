
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using OSharp.CodeGeneration.Schema;

using Shouldly;

using Xunit;

namespace OSharp.CodeGeneration.Tests
{
    public class RazorCodeGeneratorTests
    {
        private readonly ModuleMetadata _module;
        private readonly EntityMetadata _entity;

        public RazorCodeGeneratorTests()
        {
            ProjectMetadata project = new ProjectMetadata()
            {
                Display = "XXXϵͳ",
                Company = "�������",
                Copyright = "Copyright (c) 2014-2019 OSharp. All rights reserved.",
                Creator = "������",
                SiteUrl = "https://www.66soft.net",
                NamespacePrefix = "Liuliu.Site"
            };
            _module = new ModuleMetadata()
            {
                Name = "Infos",
                Display = "��Ϣ",
                Project = project
            };
            _entity = new EntityMetadata()
            {
                Name = "Article",
                Display = "����",
                Module = _module,
                PrimaryKeyTypeFullName = typeof(int).FullName,
                Properties = new List<PropertyMetadata>()
                {
                    new PropertyMetadata() { Name = "Title", Display = "����", TypeName = typeof(string).FullName },
                    new PropertyMetadata() { Name = "Content", Display = "����", TypeName = typeof(string).FullName },
                    new PropertyMetadata() { Name = "IsHoted", Display = "�Ƿ��ȵ�", TypeName = typeof(bool).FullName },
                    new PropertyMetadata() { Name = "IsLocked", Display = "�Ƿ�����", TypeName = typeof(bool).FullName },
                    new PropertyMetadata() { Name = "IsDeleted", Display = "�Ƿ�ɾ��", TypeName = typeof(bool).FullName },
                }
            };
        }

        [Fact]
        public void GenerateEntityCodeTest()
        {
            CodeFile code = new RazorCodeGenerator().GenerateEntityCode(_entity);
            AssertCodeFile(code);
        }

        [Fact]
        public void GenerateEntityConfigurationTest()
        {
            CodeFile code = new RazorCodeGenerator().GenerateEntityConfiguration(_entity);
            AssertCodeFile(code);
        }

        private void AssertCodeFile(CodeFile code)
        {
            code.FileName.ShouldBe("Liuliu.Site.EntityConfiguration/Infos/ArticleConfiguration.cs");
            code.SourceCode.ShouldContain("namespace");
            code.SourceCode.ShouldContain("public class");
        }
    }
}
