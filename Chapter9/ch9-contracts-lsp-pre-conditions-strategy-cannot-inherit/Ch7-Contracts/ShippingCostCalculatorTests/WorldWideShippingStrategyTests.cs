﻿using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShippingCostCalculator;

using NUnit.Framework;
using FluentAssertions;

namespace ShippingCostCalculatorTests
{
    [TestFixture]
    public class WorldWideShippingStrategyTests
    {
        [Test]
        public void ShippingRegionMustBeProvided()
        {
            strategy.Invoking(s => s.CalculateShippingCost(1f, ValidSize, null))
                .ShouldThrow<ArgumentNullException>("Destination must be provided")
                .And.ParamName.Should().Be("destination");
        }

        [Test]
        public void ShippingWeightMustBePositive()
        {
            strategy.Invoking(s => s.CalculateShippingCost(-1f, ValidSize, RegionInfo.CurrentRegion))
                .ShouldThrow<ArgumentOutOfRangeException>("Package weight must be positive and non-zero")
                .And.ParamName.Should().Be("packageWeightInKilograms");
        }

        [Test]
        public void ShippingWeightMustBeNonZero()
        {
            strategy.Invoking(s => s.CalculateShippingCost(0, ValidSize, RegionInfo.CurrentRegion))
                .ShouldThrow<ArgumentOutOfRangeException>("Package weight must be positive and non-zero")
                .And.ParamName.Should().Be("packageWeightInKilograms");
        }

        [Test]
        public void ShippingDimensionsXMustBePositive()
        {
            var negativeSizeX = new Size<float> { X = -1f, Y = 1f };
            strategy.Invoking(s => s.CalculateShippingCost(1, negativeSizeX, RegionInfo.CurrentRegion))
                .ShouldThrow<ArgumentOutOfRangeException>("Package dimension must be positive and non-zero")
                .And.ParamName.Should().Be("packageDimensionsInInches");
        }

        [Test]
        public void ShippingDimensionsXMustBeNonZero()
        {
            var zeroSizeX = new Size<float> { X = 0f, Y = 1f };
            strategy.Invoking(s => s.CalculateShippingCost(1, zeroSizeX, RegionInfo.CurrentRegion))
                .ShouldThrow<ArgumentOutOfRangeException>("Package dimension must be positive and non-zero")
                .And.ParamName.Should().Be("packageDimensionsInInches");
        }

        [Test]
        public void ShippingDimensionsYMustBePositive()
        {
            var negativeSizeY = new Size<float> { X = 1f, Y = -1f };
            strategy.Invoking(s => s.CalculateShippingCost(1, negativeSizeY, RegionInfo.CurrentRegion))
                .ShouldThrow<ArgumentOutOfRangeException>("Package dimension must be positive and non-zero")
                .And.ParamName.Should().Be("packageDimensionsInInches");
        }

        [Test]
        public void ShippingDimensionsYMustBeNonZero()
        {
            var zeroSizeY = new Size<float> { X = 1f, Y = 0f };
            strategy.Invoking(s => s.CalculateShippingCost(1, zeroSizeY, RegionInfo.CurrentRegion))
                .ShouldThrow<ArgumentOutOfRangeException>("Package dimension must be positive and non-zero")
                .And.ParamName.Should().Be("packageDimensionsInInches");
        }

        [Test]
        public void ShippingCostMustBePositiveAndNonZero()
        {
            strategy.CalculateShippingCost(1f, ValidSize, RegionInfo.CurrentRegion)
                .Should().BeGreaterThan(0m);
        }

        [Test]
        public void ShippingFlatRateMustBePositive()
        {
            Action constructor = () => new ShippingStrategy(decimal.MinusOne);

            constructor.ShouldThrow<ArgumentOutOfRangeException>("Flat rate must be postive and non-zero")
                .And.ParamName.Should().Be("flatRate");
        }

        [Test]
        public void ShippingFlatRateMustBeNonZero()
        {
            Action constructor = () => new ShippingStrategy(decimal.MinusOne);

            constructor.ShouldThrow<ArgumentOutOfRangeException>("Flat rate must be postive and non-zero")
                .And.ParamName.Should().Be("flatRate");
        }

        [SetUp]
        public void SetUp()
        {
            this.strategy = new WorldWideShippingStrategy(decimal.One);
        }

        protected WorldWideShippingStrategy strategy;
        protected readonly Size<float> ValidSize = new Size<float> { X = 1f, Y = 1f };
    }
}
