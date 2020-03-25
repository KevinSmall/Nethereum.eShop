using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Nethereum.Commerce.Contracts.Funding.ContractDefinition
{


    public partial class FundingDeployment : FundingDeploymentBase
    {
        public FundingDeployment() : base(BYTECODE) { }
        public FundingDeployment(string byteCode) : base(byteCode) { }
    }

    public class FundingDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50604051611cb7380380611cb783398101604081905261002f9161009d565b600080546001600160a01b03191633178082556040516001600160a01b039190911691907f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e0908290a3600380546001600160a01b0319166001600160a01b03929092169190911790556100cb565b6000602082840312156100ae578081fd5b81516001600160a01b03811681146100c4578182fd5b9392505050565b611bdd806100da6000396000f3fe608060405234801561001057600080fd5b506004361061010b5760003560e01c80638e5fc30b116100a2578063c016d9b611610071578063c016d9b6146101fc578063c76ea97814610204578063cfb5192814610217578063f2fde38b1461022a578063f3ad65f41461023d5761010b565b80638e5fc30b146101ac5780638f32d59b146101cc5780639cf3037a146101d4578063abefab87146101e75761010b565b80636b6a291a116100de5780636b6a291a14610176578063802706cb1461017e57806387a211b5146101915780638da5cb5b146101a45761010b565b8063150e99f91461011057806340a0a2dd146101255780634360beb5146101385780636b00e9d814610156575b600080fd5b61012361011e36600461133f565b610245565b005b610123610133366004611729565b610320565b610140610527565b60405161014d9190611758565b60405180910390f35b61016961016436600461133f565b610536565b60405161014d91906117a9565b61014061054b565b61012361018c3660046113bb565b61055a565b61012361019f366004611711565b61070e565b6101406108d6565b6101bf6101ba36600461139a565b6108e5565b60405161014d91906117ec565b610169610a0f565b6101236101e2366004611729565b610a20565b6101ef610e42565b60405161014d91906117b4565b610140610e48565b61012361021236600461133f565b610e57565b6101ef610225366004611424565b610f2c565b61012361023836600461133f565b610f4e565b610140610f7b565b61024d610a0f565b6102725760405162461bcd60e51b8152600401610269906119e1565b60405180910390fd5b6001600160a01b03811660009081526001602052604090205460ff16156102e8576001600160a01b038116600081815260016020526040808220805460ff1916905560028054600019019055517f8ddb5a2efd673581f97000ec107674428dc1ed37e8e7944654e48fb0688114779190a261031d565b6040516001600160a01b038216907f21aa6b3368eceb61c9fc1bdfd2cb6337c87cc1510c1afcc7d5a45371551b43b890600090a25b50565b6103286108d6565b6001600160a01b0316336001600160a01b0316148061035657503360009081526001602052604090205460ff165b1561050b57610363610fe5565b60055460405163191a607f60e31b81526001600160a01b039091169063c8d303f8906103939086906004016117b4565b60006040518083038186803b1580156103ab57600080fd5b505afa1580156103bf573d6000803e3d6000fd5b505050506040513d6000823e601f3d908101601f191682016040526103e7919081019061152a565b905060006001830360ff1690506000826101c00151828151811061040757fe5b6020026020010151610120015190506000836101400151905060006001600160a01b031684606001516001600160a01b031614156104575760405162461bcd60e51b8152600401610269906118c8565b606084015160405163a9059cbb60e01b81526000916001600160a01b0384169163a9059cbb9161048b918790600401611790565b602060405180830381600087803b1580156104a557600080fd5b505af11580156104b9573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052506104dd919081019061137e565b90506001811515146105015760405162461bcd60e51b815260040161026990611a9a565b5050505050610523565b60405162461bcd60e51b815260040161026990611ad1565b5050565b6004546001600160a01b031681565b60016020526000908152604090205460ff1681565b6006546001600160a01b031681565b610562610a0f565b61057e5760405162461bcd60e51b8152600401610269906119e1565b60035460405163d9c4c15360e01b81526001600160a01b039091169063d9c4c153906105b090859085906004016117bd565b60206040518083038186803b1580156105c857600080fd5b505afa1580156105dc573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052506106009190810190611362565b600480546001600160a01b0319166001600160a01b0392831617908190551661063b5760405162461bcd60e51b815260040161026990611984565b60035460405163d9c4c15360e01b81526001600160a01b039091169063d9c4c1539061066d90879087906004016117bd565b60206040518083038186803b15801561068557600080fd5b505afa158015610699573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052506106bd9190810190611362565b600680546001600160a01b03199081166001600160a01b0393841617918290556005805492909316911681179091556107085760405162461bcd60e51b815260040161026990611a16565b50505050565b6107166108d6565b6001600160a01b0316336001600160a01b0316148061074457503360009081526001602052604090205460ff165b1561050b57610751610fe5565b60055460405163191a607f60e31b81526001600160a01b039091169063c8d303f8906107819085906004016117b4565b60006040518083038186803b15801561079957600080fd5b505afa1580156107ad573d6000803e3d6000fd5b505050506040513d6000823e601f3d908101601f191682016040526107d5919081019061152a565b90506000805b826101a0015160ff1681101561081a57826101c0015181815181106107fc57fe5b602002602001015161012001518201915080806001019150506107db565b5061014082015160608301516040516323b872dd60e01b81526000916001600160a01b038416916323b872dd91610857913090889060040161176c565b602060405180830381600087803b15801561087157600080fd5b505af1158015610885573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052506108a9919081019061137e565b90506001811515146108cd5760405162461bcd60e51b815260040161026990611883565b5050505061031d565b6000546001600160a01b031690565b6040805160208082528183019092526060918291906020820181803883390190505090506000805b6020811015610963576008810260020a86026001600160f81b031981161561095a578084848151811061093c57fe5b60200101906001600160f81b031916908160001a9053506001909201915b5060010161090d565b50600081851180610972575084155b1561097e575080610985565b5060001984015b6060816040519080825280601f01601f1916602001820160405280156109b2576020820181803883390190505b50905060005b82811015610a02578481815181106109cc57fe5b602001015160f81c60f81b8282815181106109e357fe5b60200101906001600160f81b031916908160001a9053506001016109b8565b5093505050505b92915050565b6000546001600160a01b0316331490565b610a286108d6565b6001600160a01b0316336001600160a01b03161480610a5657503360009081526001602052604090205460ff165b1561050b57610a63610fe5565b60055460405163191a607f60e31b81526001600160a01b039091169063c8d303f890610a939086906004016117b4565b60006040518083038186803b158015610aab57600080fd5b505afa158015610abf573d6000803e3d6000fd5b505050506040513d6000823e601f3d908101601f19168201604052610ae7919081019061152a565b905060006001830360ff1690506000826101c001518281518110610b0757fe5b6020026020010151610120015190506000836101c001518381518110610b2957fe5b60200260200101516101400151905060008461014001519050610b4a611073565b60048054610100880151604051631f91394160e21b81526001600160a01b0390921692637e44e50492610b7e9291016117b4565b60a06040518083038186803b158015610b9657600080fd5b505afa158015610baa573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250610bce91908101906116a8565b60408101519091506001600160a01b0316610bfb5760405162461bcd60e51b8152600401610269906118ff565b83831115610c1b5760405162461bcd60e51b815260040161026990611943565b604080820151905163a9059cbb60e01b8152848603916000916001600160a01b0386169163a9059cbb91610c5491908690600401611790565b602060405180830381600087803b158015610c6e57600080fd5b505af1158015610c82573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250610ca6919081019061137e565b9050600181151514610cca5760405162461bcd60e51b815260040161026990611a9a565b8415610e3557610cd86110a1565b6004805460808b0151604051632cf9174960e21b81526001600160a01b039092169263b3e45d2492610d0b9291016117b4565b60c06040518083038186803b158015610d2357600080fd5b505afa158015610d37573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250610d5b91908101906114ae565b60408101519091506001600160a01b0316610d885760405162461bcd60e51b815260040161026990611a63565b604080820151905163a9059cbb60e01b81526000916001600160a01b0388169163a9059cbb91610dbc918b90600401611790565b602060405180830381600087803b158015610dd657600080fd5b505af1158015610dea573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250610e0e919081019061137e565b9050600181151514610e325760405162461bcd60e51b81526004016102699061183f565b50505b5050505050505050610523565b60025481565b6005546001600160a01b031681565b610e5f610a0f565b610e7b5760405162461bcd60e51b8152600401610269906119e1565b6001600160a01b03811660009081526001602052604090205460ff1615610ed5576040516001600160a01b038216907ff6831fd5f976003f3acfcf6b2784b2f81e3abb43d161884873a310d6beadf38090600090a261031d565b6001600160a01b0381166000818152600160208190526040808320805460ff19168317905560028054909201909155517f3c4dcdfdb789d0f39b8a520a4f83ab2599db1d2ececebe4db2385f360c0d3ce19190a250565b80516000908290610f41575060009050610f49565b505060208101515b919050565b610f56610a0f565b610f725760405162461bcd60e51b8152600401610269906119e1565b61031d81610f8a565b6003546001600160a01b031681565b600080546040516001600160a01b03808516939216917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e091a3600080546001600160a01b0319166001600160a01b0392909216919091179055565b6040805161022081018252600080825260208201819052918101829052606081018290526080810182905260a0810182905260c0810182905260e0810182905261010081018290526101208101829052610140810182905290610160820190815260200160008152602001600060ff16815260200160608152602001600060ff168152602001606081525090565b6040805160a08101825260008082526020820181905291810182905260608101829052608081019190915290565b6040805160c081018252600080825260208201819052918101829052606081018290526080810182905260a081019190915290565b8051610a0981611b75565b600082601f8301126110f1578081fd5b81516111046110ff82611b55565b611b2e565b81815291506020808301908481018184028601820187101561112557600080fd5b60005b8481101561114457815184529282019290820190600101611128565b505050505092915050565b600082601f83011261115f578081fd5b815161116d6110ff82611b55565b81815291506020808301908481016102408085028701830188101561119157600080fd5b60005b858110156112a45781838a0312156111ab57600080fd5b6111b482611b2e565b835181526111c48a868601611334565b8582015260408401516040820152606084015160608201526080840151608082015260a084015160a082015260c084015160c082015260e084015160e08201526101006112138b8287016110d6565b908201526101208481015190820152610140808501519082015261016061123c8b8287016112cf565b9082015261018084810151908201526101a080850151908201526101c080850151908201526101e0808501519082015261020061127b8b8287016112b0565b9082015261022061128e8b8683016112c0565b9082015285529383019391810191600101611194565b50505050505092915050565b80518015158114610a0957600080fd5b805160048110610a0957600080fd5b805160098110610a0957600080fd5b805160038110610a0957600080fd5b60008083601f8401126112fe578182fd5b50813567ffffffffffffffff811115611315578182fd5b60208301915083602082850101111561132d57600080fd5b9250929050565b8051610a0981611b98565b600060208284031215611350578081fd5b813561135b81611b75565b9392505050565b600060208284031215611373578081fd5b815161135b81611b75565b60006020828403121561138f578081fd5b815161135b81611b8a565b600080604083850312156113ac578081fd5b50508035926020909101359150565b600080600080604085870312156113d0578182fd5b843567ffffffffffffffff808211156113e7578384fd5b6113f3888389016112ed565b9096509450602087013591508082111561140b578384fd5b50611418878288016112ed565b95989497509550505050565b60006020808385031215611436578182fd5b823567ffffffffffffffff8082111561144d578384fd5b81850186601f82011261145e578485fd5b803592508183111561146e578485fd5b611480601f8401601f19168501611b2e565b91508282528684848301011115611495578485fd5b8284820185840137509081019091019190915292915050565b600060c082840312156114bf578081fd5b6114c960c0611b2e565b825181526020830151602082015260408301516114e581611b75565b604082015260608301516114f881611b75565b6060820152608083015161150b81611b8a565b608082015260a083015161151e81611b75565b60a08201529392505050565b60006020828403121561153b578081fd5b815167ffffffffffffffff80821115611552578283fd5b610220918401808603831315611566578384fd5b61156f83611b2e565b8151815261158087602084016110d6565b602082015261159287604084016110d6565b60408201526115a487606084016110d6565b60608201526080820151608082015260a082015160a082015260c082015160c08201526115d48760e084016110d6565b60e0820152610100828101519082015261012080830151908201526101409350611600878584016110d6565b848201526101609350611615878584016112de565b84820152610180935083820151848201526101a0935061163787858401611334565b848201526101c093508382015183811115611650578586fd5b61165c8882850161114f565b85830152506101e0935061167287858401611334565b848201526102009350838201518381111561168b578586fd5b611697888285016110e1565b948201949094529695505050505050565b600060a082840312156116b9578081fd5b6116c360a0611b2e565b825181526020830151602082015260408301516116df81611b75565b604082015260608301516116f281611b8a565b6060820152608083015161170581611b75565b60808201529392505050565b600060208284031215611722578081fd5b5035919050565b6000806040838503121561173b578182fd5b82359150602083013561174d81611b98565b809150509250929050565b6001600160a01b0391909116815260200190565b6001600160a01b039384168152919092166020820152604081019190915260600190565b6001600160a01b03929092168252602082015260400190565b901515815260200190565b90815260200190565b60006020825282602083015282846040840137818301604090810191909152601f909201601f19160101919050565b6000602082528251806020840152815b8181101561181957602081860181015160408684010152016117fc565b8181111561182a5782604083860101525b50601f01601f19169190910160400192915050565b60208082526024908201527f4e6f7420656e6f7567682066756e6473207472616e7366657272656420666f726040820152632066656560e01b606082015260800190565b60208082526025908201527f496e73756666696369656e742066756e6473207472616e7366657272656420666040820152646f7220504f60d81b606082015260800190565b6020808252601e908201527f504f20686173206e6f2062757965722077616c6c657420616464726573730000604082015260600190565b60208082526024908201527f53656c6c657220686173206e6f2061646d696e20636f6e7472616374206164646040820152637265737360e01b606082015260800190565b60208082526021908201527f504f204974656d20666565206578636565647320504f204974656d2076616c756040820152606560f81b606082015260800190565b60208082526039908201527f436f756c64206e6f742066696e6420427573696e657373506172746e6572537460408201527f6f72616765206164647265737320696e20726567697374727900000000000000606082015260800190565b6020808252818101527f4f776e61626c653a2063616c6c6572206973206e6f7420746865206f776e6572604082015260600190565b6020808252602d908201527f436f756c64206e6f742066696e642050757263686173696e672061646472657360408201526c7320696e20726567697374727960981b606082015260800190565b6020808252601d908201527f6553686f7020686173206e6f20636f6e74726163742061646472657373000000604082015260600190565b6020808252601c908201527f4e6f7420656e6f7567682066756e6473207472616e7366657272656400000000604082015260600190565b6020808252603e908201527f4f6e6c7920636f6e7472616374206f776e6572206f72206120626f756e64206160408201527f646472657373206d61792063616c6c20746869732066756e6374696f6e2e0000606082015260800190565b60405181810167ffffffffffffffff81118282101715611b4d57600080fd5b604052919050565b600067ffffffffffffffff821115611b6b578081fd5b5060209081020190565b6001600160a01b038116811461031d57600080fd5b801515811461031d57600080fd5b60ff8116811461031d57600080fdfea2646970667358221220b805583efa3fa2ebdea2b2de6ab3802f5b45c0a2b46ff0dcb8044210a1c8e10064736f6c63430006010033";
        public FundingDeploymentBase() : base(BYTECODE) { }
        public FundingDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "contractAddressOfRegistry", 1)]
        public virtual string ContractAddressOfRegistry { get; set; }
    }

    public partial class BoundAddressCountFunction : BoundAddressCountFunctionBase { }

    [Function("BoundAddressCount", "int256")]
    public class BoundAddressCountFunctionBase : FunctionMessage
    {

    }

    public partial class BoundAddressesFunction : BoundAddressesFunctionBase { }

    [Function("BoundAddresses", "bool")]
    public class BoundAddressesFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class AddressRegistryFunction : AddressRegistryFunctionBase { }

    [Function("addressRegistry", "address")]
    public class AddressRegistryFunctionBase : FunctionMessage
    {

    }

    public partial class BindAddressFunction : BindAddressFunctionBase { }

    [Function("bindAddress")]
    public class BindAddressFunctionBase : FunctionMessage
    {
        [Parameter("address", "a", 1)]
        public virtual string A { get; set; }
    }

    public partial class BusinessPartnerStorageFunction : BusinessPartnerStorageFunctionBase { }

    [Function("businessPartnerStorage", "address")]
    public class BusinessPartnerStorageFunctionBase : FunctionMessage
    {

    }

    public partial class Bytes32ToStringFunction : Bytes32ToStringFunctionBase { }

    [Function("bytes32ToString", "string")]
    public class Bytes32ToStringFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "x", 1)]
        public virtual byte[] X { get; set; }
        [Parameter("uint256", "truncateToLength", 2)]
        public virtual BigInteger TruncateToLength { get; set; }
    }

    public partial class ConfigureFunction : ConfigureFunctionBase { }

    [Function("configure")]
    public class ConfigureFunctionBase : FunctionMessage
    {
        [Parameter("string", "nameOfPurchasing", 1)]
        public virtual string NameOfPurchasing { get; set; }
        [Parameter("string", "nameOfBusinessPartnerStorage", 2)]
        public virtual string NameOfBusinessPartnerStorage { get; set; }
    }

    public partial class IsOwnerFunction : IsOwnerFunctionBase { }

    [Function("isOwner", "bool")]
    public class IsOwnerFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class PurchasingFunction : PurchasingFunctionBase { }

    [Function("purchasing", "address")]
    public class PurchasingFunctionBase : FunctionMessage
    {

    }

    public partial class PurchasingContractAddressFunction : PurchasingContractAddressFunctionBase { }

    [Function("purchasingContractAddress", "address")]
    public class PurchasingContractAddressFunctionBase : FunctionMessage
    {

    }

    public partial class StringToBytes32Function : StringToBytes32FunctionBase { }

    [Function("stringToBytes32", "bytes32")]
    public class StringToBytes32FunctionBase : FunctionMessage
    {
        [Parameter("string", "source", 1)]
        public virtual string Source { get; set; }
    }

    public partial class TransferInFundsForPoFromBuyerWalletFunction : TransferInFundsForPoFromBuyerWalletFunctionBase { }

    [Function("transferInFundsForPoFromBuyerWallet")]
    public class TransferInFundsForPoFromBuyerWalletFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "poNumber", 1)]
        public virtual BigInteger PoNumber { get; set; }
    }

    public partial class TransferOutFundsForPoItemToBuyerFunction : TransferOutFundsForPoItemToBuyerFunctionBase { }

    [Function("transferOutFundsForPoItemToBuyer")]
    public class TransferOutFundsForPoItemToBuyerFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "poNumber", 1)]
        public virtual BigInteger PoNumber { get; set; }
        [Parameter("uint8", "poItemNumber", 2)]
        public virtual byte PoItemNumber { get; set; }
    }

    public partial class TransferOutFundsForPoItemToSellerFunction : TransferOutFundsForPoItemToSellerFunctionBase { }

    [Function("transferOutFundsForPoItemToSeller")]
    public class TransferOutFundsForPoItemToSellerFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "poNumber", 1)]
        public virtual BigInteger PoNumber { get; set; }
        [Parameter("uint8", "poItemNumber", 2)]
        public virtual byte PoItemNumber { get; set; }
    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class UnBindAddressFunction : UnBindAddressFunctionBase { }

    [Function("unBindAddress")]
    public class UnBindAddressFunctionBase : FunctionMessage
    {
        [Parameter("address", "a", 1)]
        public virtual string A { get; set; }
    }

    public partial class AddressAlreadyBoundEventDTO : AddressAlreadyBoundEventDTOBase { }

    [Event("AddressAlreadyBound")]
    public class AddressAlreadyBoundEventDTOBase : IEventDTO
    {
        [Parameter("address", "a", 1, true )]
        public virtual string A { get; set; }
    }

    public partial class AddressAlreadyUnBoundEventDTO : AddressAlreadyUnBoundEventDTOBase { }

    [Event("AddressAlreadyUnBound")]
    public class AddressAlreadyUnBoundEventDTOBase : IEventDTO
    {
        [Parameter("address", "a", 1, true )]
        public virtual string A { get; set; }
    }

    public partial class AddressBoundEventDTO : AddressBoundEventDTOBase { }

    [Event("AddressBound")]
    public class AddressBoundEventDTOBase : IEventDTO
    {
        [Parameter("address", "a", 1, true )]
        public virtual string A { get; set; }
    }

    public partial class AddressUnBoundEventDTO : AddressUnBoundEventDTOBase { }

    [Event("AddressUnBound")]
    public class AddressUnBoundEventDTOBase : IEventDTO
    {
        [Parameter("address", "a", 1, true )]
        public virtual string A { get; set; }
    }

    public partial class OwnershipTransferredEventDTO : OwnershipTransferredEventDTOBase { }

    [Event("OwnershipTransferred")]
    public class OwnershipTransferredEventDTOBase : IEventDTO
    {
        [Parameter("address", "previousOwner", 1, true )]
        public virtual string PreviousOwner { get; set; }
        [Parameter("address", "newOwner", 2, true )]
        public virtual string NewOwner { get; set; }
    }

    public partial class BoundAddressCountOutputDTO : BoundAddressCountOutputDTOBase { }

    [FunctionOutput]
    public class BoundAddressCountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("int256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class BoundAddressesOutputDTO : BoundAddressesOutputDTOBase { }

    [FunctionOutput]
    public class BoundAddressesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class AddressRegistryOutputDTO : AddressRegistryOutputDTOBase { }

    [FunctionOutput]
    public class AddressRegistryOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class BusinessPartnerStorageOutputDTO : BusinessPartnerStorageOutputDTOBase { }

    [FunctionOutput]
    public class BusinessPartnerStorageOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class Bytes32ToStringOutputDTO : Bytes32ToStringOutputDTOBase { }

    [FunctionOutput]
    public class Bytes32ToStringOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class IsOwnerOutputDTO : IsOwnerOutputDTOBase { }

    [FunctionOutput]
    public class IsOwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class PurchasingOutputDTO : PurchasingOutputDTOBase { }

    [FunctionOutput]
    public class PurchasingOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class PurchasingContractAddressOutputDTO : PurchasingContractAddressOutputDTOBase { }

    [FunctionOutput]
    public class PurchasingContractAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class StringToBytes32OutputDTO : StringToBytes32OutputDTOBase { }

    [FunctionOutput]
    public class StringToBytes32OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "result", 1)]
        public virtual byte[] Result { get; set; }
    }










}
