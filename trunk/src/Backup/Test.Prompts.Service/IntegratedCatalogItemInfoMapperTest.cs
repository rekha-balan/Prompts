﻿using NUnit.Framework;
using Prompts.Service.ReportCatalogService;
using Prompts.Service.ReportService;
using Test.Prompts.Service.Infastructure;

namespace Test.Prompts.Service
{
    [TestFixture]
    public class IntegratedCatalogItemInfoMapperTest
    {
        [Test]
        public void ItRemovesRDLFromTheName()
        {
            var catalogItem = A.CatalogItem()
                .WithPath("Path.rdl")
                .WithName("Name.rdl")
                .Build();

            var mapper = new IntegratedCatalogItemInfoMapper();

            var catalogItemInfo = mapper.MapFromCatalogItem(catalogItem);

            Assert.AreEqual(catalogItem.Name.Replace(".rdl", ""), catalogItemInfo.Name);
            Assert.AreEqual(catalogItem.Path, catalogItemInfo.Path);
        }

        [Test]
        public void ItMapsPathAsIs()
        {
            var catalogItem = A.CatalogItem()
                .WithPath("Path.rdl")
                .WithName("Name.rdl")
                .Build();

            var mapper = new IntegratedCatalogItemInfoMapper();

            var catalogItemInfo = mapper.MapFromCatalogItem(catalogItem);

            Assert.AreEqual(catalogItem.Path, catalogItemInfo.Path);
        }

        [Test]
        public void ItMapsAReportAsAReport()
        {
            var catalogItem = A.CatalogItem()
                .WithType(ItemTypeEnum.Report)
                .Build();

            var mapper = new IntegratedCatalogItemInfoMapper();

            var catalogItemInfo = mapper.MapFromCatalogItem(catalogItem);

            Assert.AreEqual(CatalogItemType.Report, catalogItemInfo.Type);
        }

        [Test]
        public void ItMapsDataSourceAsOther()
        {
            var catalogItem = A.CatalogItem()
                .WithType(ItemTypeEnum.DataSource)
                .Build();

            var mapper = new IntegratedCatalogItemInfoMapper();

            var catalogItemInfo = mapper.MapFromCatalogItem(catalogItem);

            Assert.AreEqual(CatalogItemType.Other, catalogItemInfo.Type);
        }

        [Test]
        public void ItMapsLinkedReportAsOther()
        {
            var catalogItem = A.CatalogItem()
                .WithType(ItemTypeEnum.LinkedReport)
                .Build();

            var mapper = new IntegratedCatalogItemInfoMapper();

            var catalogItemInfo = mapper.MapFromCatalogItem(catalogItem);

            Assert.AreEqual(CatalogItemType.Other, catalogItemInfo.Type);
        }

        [Test]
        public void ItMapsLinkedModelAsOther()
        {
            var catalogItem = A.CatalogItem()
                .WithType(ItemTypeEnum.Model)
                .Build();

            var mapper = new IntegratedCatalogItemInfoMapper();

            var catalogItemInfo = mapper.MapFromCatalogItem(catalogItem);

            Assert.AreEqual(CatalogItemType.Other, catalogItemInfo.Type);
        }

        [Test]
        public void ItMapsResourceAsOther()
        {
            var catalogItem = A.CatalogItem()
                .WithType(ItemTypeEnum.Resource)
                .Build();

            var mapper = new IntegratedCatalogItemInfoMapper();

            var catalogItemInfo = mapper.MapFromCatalogItem(catalogItem);

            Assert.AreEqual(CatalogItemType.Other, catalogItemInfo.Type);
        }

        [Test]
        public void ItMapsUnknownAsOther()
        {
            var catalogItem = A.CatalogItem()
                .WithType(ItemTypeEnum.Unknown)
                .Build();

            var mapper = new IntegratedCatalogItemInfoMapper();

            var catalogItemInfo = mapper.MapFromCatalogItem(catalogItem);

            Assert.AreEqual(CatalogItemType.Other, catalogItemInfo.Type);
        }

        [Test]
        public void ItMapsAFolderAsAFolder()
        {
            var catalogItem = A.CatalogItem()
                .WithType(ItemTypeEnum.Folder)
                .Build();

            var mapper = new IntegratedCatalogItemInfoMapper();

            var catalogItemInfo = mapper.MapFromCatalogItem(catalogItem);

            Assert.AreEqual(CatalogItemType.Folder, catalogItemInfo.Type);
        }
    }
}
