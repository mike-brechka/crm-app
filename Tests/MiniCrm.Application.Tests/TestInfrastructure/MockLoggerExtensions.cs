﻿using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniCrm.Application.Tests.TestInfrastructure
{
    // https://codeburst.io/unit-testing-with-net-core-ilogger-t-e8c16c503a80
    public static class MockLoggerExtensions
    {
        public static void VerifyLog<T>(this Mock<ILogger<T>> loggerMock, LogLevel level, string message, string failMessage = null)
        {
            loggerMock.VerifyLog(level, message, Times.Once(), failMessage);
        }
        public static void VerifyLog<T>(this Mock<ILogger<T>> loggerMock, LogLevel level, string message, Times times, string failMessage = null)
        {
            loggerMock.Verify(l => l.Log(level, It.IsAny<EventId>(),
                       It.Is<It.IsAnyType>((o, _) => o.ToString() == message), It.IsAny<Exception>(),
                       It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                   times, failMessage);
        }
    }
}
