﻿// <copyright file="Program.cs" company="Physics.NET">
// Physics.NET
// https://github.com/HamletTanyavong/Physics.NET
//
// MIT License
//
// Copyright (c) 2024-present Hamlet Tanyavong
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// </copyright>

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

Console.WriteLine("Physics.NET Development Application");
Console.WriteLine();

#region Development Application Configuration

var builder = Host.CreateApplicationBuilder();

// Configure services.
builder.Services.AddSingleton<ILogger<Program>, Logger<Program>>();
builder.Services.AddHttpClient();

// Configure logging.
#if DEBUG
builder.Logging.AddFilter(logLevel => logLevel >= LogLevel.Debug);
#elif RELEASE
builder.Logging.AddFilter(logLevel => logLevel >= LogLevel.Warning);
#endif

// Build the application.
var app = builder.Build();

#endregion

#region Useful Services

var logger = app.Services.GetRequiredService<ILogger<Program>>();
var httpClientFactory = app.Services.GetRequiredService<IHttpClientFactory>();

#endregion

// Run the application and/or add code below for quick testing and verification.
