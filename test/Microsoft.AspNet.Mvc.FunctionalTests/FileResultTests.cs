﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.AspNet.Mvc.FunctionalTests
{
    public class FileResultTests
    {
        [Fact]
        public async Task FileFromDisk_CanBeEnabled_WithMiddleware()
        {
            // Arrange
            var site = TestWebSite.Create(nameof(FilesWebSite));
            var client = site.CreateClient();

            // Act
            var response = await client.GetAsync("http://localhost/DownloadFiles/DowloadFromDisk");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            Assert.NotNull(response.Content.Headers.ContentType);
            Assert.Equal("text/plain", response.Content.Headers.ContentType.ToString());

            var body = await response.Content.ReadAsStringAsync();
            Assert.NotNull(body);
            Assert.Equal("This is a sample text file", body);
        }

        [Fact]
        public async Task FileFromDisk_ReturnsFileWithFileName()
        {
            // Arrange
            var site = TestWebSite.Create(nameof(FilesWebSite));
            var client = site.CreateClient();

            // Act
            var response = await client.GetAsync("http://localhost/DownloadFiles/DowloadFromDiskWithFileName");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            Assert.NotNull(response.Content.Headers.ContentType);
            Assert.Equal("text/plain", response.Content.Headers.ContentType.ToString());

            var body = await response.Content.ReadAsStringAsync();
            Assert.NotNull(body);
            Assert.Equal("This is a sample text file", body);

            var contentDisposition = response.Content.Headers.ContentDisposition.ToString();
            Assert.NotNull(contentDisposition);
            Assert.Equal("attachment; filename=downloadName.txt", contentDisposition);
        }

        [Fact]
        public async Task FileFromStream_ReturnsFile()
        {
            // Arrange
            var site = TestWebSite.Create(nameof(FilesWebSite));
            var client = site.CreateClient();

            // Act
            var response = await client.GetAsync("http://localhost/DownloadFiles/DowloadFromStream");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            Assert.NotNull(response.Content.Headers.ContentType);
            Assert.Equal("text/plain", response.Content.Headers.ContentType.ToString());

            var body = await response.Content.ReadAsStringAsync();
            Assert.NotNull(body);
            Assert.Equal("This is sample text from a stream", body);
        }

        [Fact]
        public async Task FileFromStream_ReturnsFileWithFileName()
        {
            // Arrange
            var site = TestWebSite.Create(nameof(FilesWebSite));
            var client = site.CreateClient();

            // Act
            var response = await client.GetAsync("http://localhost/DownloadFiles/DowloadFromStreamWithFileName");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            Assert.NotNull(response.Content.Headers.ContentType);
            Assert.Equal("text/plain", response.Content.Headers.ContentType.ToString());

            var body = await response.Content.ReadAsStringAsync();
            Assert.NotNull(body);
            Assert.Equal("This is sample text from a stream", body);

            var contentDisposition = response.Content.Headers.ContentDisposition.ToString();
            Assert.NotNull(contentDisposition);
            Assert.Equal("attachment; filename=downloadName.txt", contentDisposition);
        }

        [Fact]
        public async Task FileFromBinaryData_ReturnsFile()
        {
            // Arrange
            var site = TestWebSite.Create(nameof(FilesWebSite));
            var client = site.CreateClient();

            // Act
            var response = await client.GetAsync("http://localhost/DownloadFiles/DowloadFromBinaryData");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            Assert.NotNull(response.Content.Headers.ContentType);
            Assert.Equal("text/plain", response.Content.Headers.ContentType.ToString());

            var body = await response.Content.ReadAsStringAsync();
            Assert.NotNull(body);
            Assert.Equal("This is a sample text from a binary array", body);
        }

        [Fact]
        public async Task FileFromBinaryData_ReturnsFileWithFileName()
        {
            // Arrange
            var site = TestWebSite.Create(nameof(FilesWebSite));
            var client = site.CreateClient();

            // Act
            var response = await client.GetAsync("http://localhost/DownloadFiles/DowloadFromBinaryDataWithFileName");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            Assert.NotNull(response.Content.Headers.ContentType);
            Assert.Equal("text/plain", response.Content.Headers.ContentType.ToString());

            var body = await response.Content.ReadAsStringAsync();
            Assert.NotNull(body);
            Assert.Equal("This is a sample text from a binary array", body);

            var contentDisposition = response.Content.Headers.ContentDisposition.ToString();
            Assert.NotNull(contentDisposition);
            Assert.Equal("attachment; filename=downloadName.txt", contentDisposition);
        }
    }
}