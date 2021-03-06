using System;
using System.Numerics;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
// using Nethereum.Web3;

public class EVM
{
  public class StringResponse { public string response; }
  public class BoolResponse { public bool response; }
  public class IntResponse { public int response; }

  private readonly static string host = "https://api.gaming.chainsafe.io/evm";

  public static async Task<string> BalanceOf(string _chain, string _network, string _account, string _rpc = "")
  {
    WWWForm form = new WWWForm();
    form.AddField("chain", _chain);
    form.AddField("network", _network);
    form.AddField("account", _account);
    form.AddField("rpc", _rpc);
    string url = host + "/balanceOf";
    UnityWebRequest webRequest = UnityWebRequest.Post(url, form);
    await webRequest.SendWebRequest();
    StringResponse data = JsonUtility.FromJson<StringResponse>(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));
    return data.response;
  }

  public static async Task<string> Verify(string _message, string _signature)
  {
    WWWForm form = new WWWForm();
    form.AddField("message", _message);
    form.AddField("signature", _signature);
    string url = host + "/verify";
    UnityWebRequest webRequest = UnityWebRequest.Post(url, form);
    await webRequest.SendWebRequest();
    StringResponse data = JsonUtility.FromJson<StringResponse>(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));
    return data.response;
  }

  public static async Task<string> Call(string _chain, string _network, string _contract, string _abi, string _method, string _args, string _rpc = "")
  {
    WWWForm form = new WWWForm();
    form.AddField("chain", _chain);
    form.AddField("network", _network);
    form.AddField("contract", _contract);
    form.AddField("abi", _abi);
    form.AddField("method", _method);
    form.AddField("args", _args);
    form.AddField("rpc", _rpc);
    string url = host + "/call";
    UnityWebRequest webRequest = UnityWebRequest.Post(url, form);
    await webRequest.SendWebRequest();
    StringResponse data = JsonUtility.FromJson<StringResponse>(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));
    return data.response; 
  }

  public static async Task<bool> IsTxConfirmed(string _chain, string _network, string _transaction, string _rpc = "")
  {
    WWWForm form = new WWWForm();
    form.AddField("chain", _chain);
    form.AddField("network", _network);
    form.AddField("transaction", _transaction);
    form.AddField("rpc", _rpc);
    string url = host + "/isTxConfirmed";
    UnityWebRequest webRequest = UnityWebRequest.Post(url, form);
    await webRequest.SendWebRequest();
    BoolResponse data = JsonUtility.FromJson<BoolResponse>(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));
    return data.response;
  }

  public static async Task<int> BlockNumber(string _chain, string _network, string _rpc = "")
  {
    WWWForm form = new WWWForm();
    form.AddField("chain", _chain);
    form.AddField("network", _network);
    form.AddField("rpc", _rpc);
    string url = host + "/blockNumber";
    UnityWebRequest webRequest = UnityWebRequest.Post(url, form);
    await webRequest.SendWebRequest();
    IntResponse data = JsonUtility.FromJson<IntResponse>(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));
    return data.response;
  } 

  public static async Task<string> Nonce(string _chain, string _network, string _account, string _rpc = "")
  {
    WWWForm form = new WWWForm();
    form.AddField("chain", _chain);
    form.AddField("network", _network);
    form.AddField("account", _account);
    form.AddField("rpc", _rpc);
    string url = host + "/nonce";
    UnityWebRequest webRequest = UnityWebRequest.Post(url, form);
    await webRequest.SendWebRequest();
    StringResponse data = JsonUtility.FromJson<StringResponse>(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));
    return data.response;
  } 

  public static async Task<string> GasPrice(string _chain, string _network, string _rpc = "")
  {
    WWWForm form = new WWWForm();
    form.AddField("chain", _chain);
    form.AddField("network", _network);
    form.AddField("rpc", _rpc);
    string url = host + "/gasPrice";
    UnityWebRequest webRequest = UnityWebRequest.Post(url, form);
    await webRequest.SendWebRequest();
    StringResponse data = JsonUtility.FromJson<StringResponse>(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));
    return data.response;
  }

  public static async Task<string> GasLimit(string _chain, string _network, string _account, string _amount, string _transaction, string _rpc = "")
  {
    WWWForm form = new WWWForm();
    form.AddField("chain", _chain);
    form.AddField("network", _network);
    form.AddField("rpc", _rpc);
    string url = host + "/gasLimit";
    UnityWebRequest webRequest = UnityWebRequest.Post(url, form);
    await webRequest.SendWebRequest();
    StringResponse data = JsonUtility.FromJson<StringResponse>(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));
    return data.response;
  }

  public static async Task<string> CreateTransaction(string _chain, string _network, string _contract, string _abi, string _method, string _args, string _rpc = "")
  {
    WWWForm form = new WWWForm();
    form.AddField("chain", _chain);
    form.AddField("network", _network);
    form.AddField("contract", _contract);
    form.AddField("abi", _abi);
    form.AddField("method", _method);
    form.AddField("args", _args);
    form.AddField("rpc", _rpc);
    string url = host + "/createTransaction";
    UnityWebRequest webRequest = UnityWebRequest.Post(url, form);
    await webRequest.SendWebRequest();
    StringResponse data = JsonUtility.FromJson<StringResponse>(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));
    return data.response;
  }

  // public static string SignTransaction(string _privateKey, string _account, string _amount, string _nonce, string _gasPrice, string _gasLimit, string _data) {
  //   BigInteger amount = BigInteger.Parse(_amount);
  //   BigInteger nonce = BigInteger.Parse(_nonce);
  //   BigInteger gasPrice = BigInteger.Parse(_gasPrice);
  //   BigInteger gasLimit = BigInteger.Parse(_gasLimit);
  //   string signedTransaction = "0x" + Web3.OfflineTransactionSigner.SignTransaction(_privateKey, _account, amount, nonce, gasPrice, gasLimit, _data);
  //   return signedTransaction;
  // }

  public static async Task<string> BroadcastTransaction(string _chain, string _network, string _signedTransaction, string _rpc = "")
  {
    WWWForm form = new WWWForm();
    form.AddField("chain", _chain);
    form.AddField("network", _network);
    form.AddField("signedTransaction", _signedTransaction);
    form.AddField("rpc", _rpc);
    string url = host + "/broadcastTransaction";
    UnityWebRequest webRequest = UnityWebRequest.Post(url, form);
    await webRequest.SendWebRequest();
    StringResponse data = JsonUtility.FromJson<StringResponse>(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));
    return data.response;
  }
}

