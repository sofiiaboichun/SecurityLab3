using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SecurityLab3
{
    class NetTask
    {

    public struct CasinoRes
    {
        public long realNumber;
        public string message;
        public Account account;
    }

    public struct Account
    {
        public string id;
        public int money;
        public string delTime;
    }

        public static async void CreateAcc(int id)
        {
            HttpClient httpClient = new HttpClient();
            var casinoUrl = $"http://95.217.177.249/casino/createacc?id={id}";
            var json = await httpClient.GetStringAsync(casinoUrl);
        }

        public static async Task<CasinoRes> EndRes(string gameName, int id, long number)
        {
            HttpClient httpClient = new HttpClient();
            var casinoUrl = $"http://95.217.177.249/casino/play{gameName}?id={id}&bet=1&number={number}";
            var json = await httpClient.GetStringAsync(casinoUrl);
            CasinoRes result = JsonConvert.DeserializeObject<CasinoRes>(json);

            return result;
        }

    }

   
}

