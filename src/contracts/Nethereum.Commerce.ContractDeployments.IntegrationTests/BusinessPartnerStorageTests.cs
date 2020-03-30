using FluentAssertions;
using Nethereum.ABI.FunctionEncoding;
using Nethereum.Commerce.ContractDeployments.IntegrationTests.Config;
using Nethereum.Commerce.Contracts.BusinessPartnerStorage.ContractDefinition;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using static Nethereum.Commerce.ContractDeployments.IntegrationTests.PoTestHelpers;

namespace Nethereum.Commerce.ContractDeployments.IntegrationTests
{
    [Collection("Contract Deployment Collection")]
    public class BusinessPartnerStorageTests
    {
        private readonly ITestOutputHelper _output;
        private readonly ContractDeploymentsFixture _contracts;

        public BusinessPartnerStorageTests(ContractDeploymentsFixture fixture, ITestOutputHelper output)
        {
            // ContractDeploymentsFixture performed a complete deployment.
            // See Output window -> Tests for deployment logs.
            _contracts = fixture;
            _output = output;
        }

        [Fact]
        public async void ShouldStoreAndRetrieveSeller()
        {
            var sellerAdminContractAddress = _contracts.Deployment.SellerAdminService.ContractHandler.ContractAddress;

            // Create a Seller to store
            var sellerExpected = new Seller()
            {
                SellerId = "SellerToTest" + GetRandomString(),
                SellerDescription = "SellerDescription",
                AdminContractAddress = sellerAdminContractAddress,
                IsActive = true,
                CreatedByAddress = string.Empty // filled by contract
            };

            // Store Seller
            var txReceipt = await _contracts.Deployment.BusinessPartnerStorageService.SetSellerRequestAndWaitForReceiptAsync(sellerExpected);
            txReceipt.Status.Value.Should().Be(1);

            // Retrieve Seller
            var sellerActual = (await _contracts.Deployment.BusinessPartnerStorageService.GetSellerQueryAsync(sellerExpected.SellerId)).Seller;

            // They should be the same
            CheckEverySellerFieldMatches(sellerExpected, sellerActual, createdByAddress: _contracts.Web3.TransactionManager.Account.Address);
        }

        [Fact]
        public async void ShouldStoreAndRetrieveEshop()
        {
            await Task.Delay(1);
            // Create an eShop to store
            var eShopExpected = new Eshop()
            {
                EShopId = "eShopToTest" + GetRandomString(),
                EShopDescription = "eShopDescription",
                PurchasingContractAddress = "0x94618601FE6cb8912b274E5a00453949A57f8C1e",
                IsActive = true,
                CreatedByAddress = string.Empty,  // filled by contract
                QuoteSignerCount = 2,
                QuoteSigners = new List<string>()
                {
                    "0x32A555F2328e85E489f9a5f03669DC820CE7EBe9",
                    "0x94618601FE6cb8912b274E5a00453949A57f8C1e"
                }
            };

            // Store eShop
            var txReceipt = await _contracts.Deployment.BusinessPartnerStorageService.SetEshopRequestAndWaitForReceiptAsync(eShopExpected);
            txReceipt.Status.Value.Should().Be(1);

            // Retrieve eShop
            var eShopActual = (await _contracts.Deployment.BusinessPartnerStorageService.GetEshopQueryAsync(eShopExpected.EShopId)).EShop;

            // They should be the same
            CheckEveryEshopFieldMatches(eShopExpected, eShopActual, createdByAddress: _contracts.Web3.TransactionManager.Account.Address);
        }

        [Fact]
        public async void ShouldFailToCreateEshopWhenMissingPurchasingAddress()
        {
            await Task.Delay(1);
            // Create an eShop to store, but miss out required field PurchasingContractAddress            
            var eShopExpected = new Eshop()
            {
                EShopId = "eShopToTest" + GetRandomString(),
                EShopDescription = "eShopDescription",
                PurchasingContractAddress = string.Empty,  // causes error
                IsActive = true,
                CreatedByAddress = string.Empty,           // filled by contract
                QuoteSignerCount = 0,                      // filled by contract
                QuoteSigners = new List<string>()
                {
                    "0x32A555F2328e85E489f9a5f03669DC820CE7EBe9",
                    "0x94618601FE6cb8912b274E5a00453949A57f8C1e"
                }
            };

            // Try to store eShop, it should fail
            Func<Task> act = async () => await _contracts.Deployment.BusinessPartnerStorageService.SetEshopRequestAndWaitForReceiptAsync(eShopExpected);
            act.Should().Throw<SmartContractRevertException>().WithMessage(BP_EXCEPTION_ESHOP_MISSING_PURCH_CONTRACT);
        }

        [Fact]
        public async void ShouldFailToCreateEshopWhenMissingSigners()
        {
            await Task.Delay(1);
            // Create an eShop to store, but miss out all quote signers            
            var eShopExpected = new Eshop()
            {
                EShopId = "eShopToTest" + GetRandomString(),
                EShopDescription = "eShopDescription",
                PurchasingContractAddress = "0x32A555F2328e85E489f9a5f03669DC820CE7EBe9",
                IsActive = true,
                CreatedByAddress = string.Empty,       // filled by contract
                QuoteSignerCount = 0,                  // filled by contract
                QuoteSigners = new List<string>() { }  // causes error
            };

            // Try to store eShop, it should fail
            Func<Task> act = async () => await _contracts.Deployment.BusinessPartnerStorageService.SetEshopRequestAndWaitForReceiptAsync(eShopExpected);
            act.Should().Throw<SmartContractRevertException>().WithMessage(BP_EXCEPTION_ESHOP_MISSING_SIGNERS);
        }

        [Fact]
        public async void ShouldFailToCreateSellerWhenMissingAdminAddress()
        {
            await Task.Delay(1);
            // Create a Seller to store, but miss out required field adminContractAddress            
            var sellerExpected = new Seller()
            {
                SellerId = "Seller" + GetRandomString(),
                SellerDescription = "SellerDescription",
                AdminContractAddress = string.Empty,  // causes error
                IsActive = true,
                CreatedByAddress = string.Empty       // filled by contract
            };

            // Try to store Seller, it should fail
            Func<Task> act = async () => await _contracts.Deployment.BusinessPartnerStorageService.SetSellerRequestAndWaitForReceiptAsync(sellerExpected);
            act.Should().Throw<SmartContractRevertException>().WithMessage(BP_EXCEPTION_SELLER_MISSING_CONTRACT);
        }
    }
}
