﻿namespace HiperMercado
{
    public class Item
    {
        public double Custo { get; set; }
        public int Validade { get; set; }
        public double? CustoRefrigeracao { get; set; }
        public double? Volume { get; set; }
        public double? CustoPorVolume { get; set; }
        public bool EhRefrigeracao { get; set; }
        public bool EhVolume { get; set; }

        public Item(double custo, int validade, bool ehRefrigeracao = false, double? custoRefrigeracao = null,
            bool ehVolume = false, double? volume = null, double? custoPorVolume = null)
        {
            Custo = custo;
            Validade = validade;
            EhRefrigeracao = ehRefrigeracao;
            CustoRefrigeracao = custoRefrigeracao;
            EhVolume = ehVolume;
            Volume = volume;
            CustoPorVolume = custoPorVolume;
        }
    }
}
