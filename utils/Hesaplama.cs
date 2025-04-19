public static class Hesaplama
{
    public static decimal NetMaas(decimal maas, decimal mesaiUcreti, int mesaiSaat, decimal prim, decimal kesinti)
    {
        decimal mesaiToplam = mesaiUcreti * mesaiSaat;
        decimal brut = maas + mesaiToplam + prim;
        return brut - kesinti;
    }
}
